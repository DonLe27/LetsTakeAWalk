using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SpiritSpawner : MonoBehaviour
{

    /* =========================================================================================================== *
     * =============================================  Spirit Spawner ============================================= *
     * =========================================================================================================== *
        Spirit Spawner randomly spawns spirits around the player

        Values Customizable from the Unity Inspector:
            - Spirits: List of spirit prefabs containing all possible spirit spawns
                - Spawn rate weighted evenly among all spirits
                - Add duplicates of the same prefab to increase its likelihood
            - Max Spirits: Maximum number of spirits in the world at any time
            - Spawn Delay: Range indicating min/max time in between new spirit spawns (in seconds)
            - Height Offset: Range indicating min/max height off the ground for spirits to spawn
            - Spawn Radius: Range indicating min/max distance from player for spirits to spawn
            - Despawn Radius: Distance at which spirits will start to despawn

        Values Visible form the Unity Inspector
            - Spawn Timer: Time (seconds) until next spawn/despawn 
            - Live Spirits: List of all spirits currently in the world, also contains number of spirits

        Spawn Timer
            - The Spawn Timer is updated on every Update()
            - When the Spawn Timer reaches 0:
                - Any spirits outside of the Despawn Radius are despawned
                - If the number of spirits is below maximum, a new random spirit from Spirits is spawned

        Spawning a Spirit
            - The spirit spawns in the region within the Spawn Radius
            - The y-level the spirit spawns at is equal to the y-level of the terrain at its spawn location
                - Can use Height Offset so that spirits are not spawning in the terrain
            - The spirit is added to the Live Spirits list

        Despawning a Spirit
            - The spirit is removed from the Live Spirits list
            - The spirit GameObject is destroyed

        Creating New Spirit Prefabs
            - Spirit Prefabs should have the SpiritBase component
                - SpiritBase lets the SpiritManager know to destroy the spirit when it connects with the player
                **SpiritCollider is very similar, may need to transfer over some functionality

        Notes:
            - TreeSpirit does not have SpiritBase, so it cannot be collected and destroyed
            - Not tested on networking yet
            - May be able to have identical spirits for both players by using NetworkServer.Spawn()?
            - Notifying the server that the player has collected a spirit likely goes in SpiritBase.cs

     * =========================================================================================================== */

    private GameObject Player;

    public List<GameObject> spirits = new List<GameObject>();   // List of possible spirits to spawn 
    public int maxSpirits;          // maximum spirits at a given time
    public Vector2 spawnDelay;      // Min/Max time in between spirit spawns
    public Vector2 heightOffset;    // Min/Max height offset from ground for spirit spawn
    public Vector2 spawnRadius;     // Min/Max spawn radius for spirits
    public float despawnRadius;     // Despawn radius for spirits

    [SerializeField] private float spawnTimer;  // Time til next spirit spawn

    [SerializeField]
    private List<GameObject> liveSpirits = new List<GameObject>();

    void Start()
    {
        spawnTimer = Random.Range(spawnDelay.x, spawnDelay.y);  // Initialize spawn timer
    }

    void Update()
    {
        if (spawnTimer <= 0) {

            // Despawn any spirits further than despawnRadius
            Vector3 playerLocation = ClientScene.localPlayer.gameObject.transform.position;
            foreach (GameObject spirit in liveSpirits) {
                Vector3 spiritLocation = spirit.transform.position;
                float distance = Vector3.Distance(playerLocation, spiritLocation);
                if (distance > despawnRadius) {
                    DespawnSpirit(spirit);
                }
            }

            // If under maxSpirits, spawn a random spirit
            if (GetSpiritCount() < maxSpirits) {
                SpawnSpirit(spirits[Random.Range(0, spirits.Count)]);
                spawnTimer = Random.Range(spawnDelay.x, spawnDelay.y);
            }

        }
        // Else count down spawn timer
        else {
            spawnTimer -= Time.deltaTime;
        }
    }

    public void SpawnSpirit(GameObject spirit)
    {
        Vector3 playerLocation = ClientScene.localPlayer.gameObject.transform.position;
        float radius = Random.Range(spawnRadius.x, spawnRadius.y);
        float angle = Random.Range(0, 2*Mathf.PI);
        Vector3 spawnLocation = playerLocation + new Vector3(radius * Mathf.Cos(angle), 100, radius * Mathf.Sin(angle));
        spawnLocation.y = Terrain.activeTerrain.SampleHeight(spawnLocation) + Random.Range(heightOffset.x, heightOffset.y);

        GameObject newSpirit = Instantiate(spirit, spawnLocation, Quaternion.identity);
        // Could use NetworkServer.Spawn() to have shared spirits??

        liveSpirits.Add(newSpirit);
    }

    public void DespawnSpirit(GameObject spirit)
    {
        liveSpirits.Remove(spirit);
        Destroy(spirit);
    }

    public int GetSpiritCount() { return liveSpirits.Count; }
}
