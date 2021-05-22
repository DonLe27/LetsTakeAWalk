using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class CustomNetworkManager : NetworkManager
{
    [SerializeField] private bool usingSteamworks = false;


    public override void Start()
    {
        base.Start();
    }
    public override void OnStartServer()
    {
        base.OnStartServer();

        // Spawn Canoe
        GameObject canoe = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Canoe"));
        NetworkServer.Spawn(canoe);

        //Spawn ingredient
        // GameObject ingredient = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ingredient"));
        // ingredient.transform.position = new Vector3(320, 10, 200);
        // NetworkServer.Spawn(ingredient);
        SpawnIngredients();

    }
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        // Add player at spawn position
        Transform startPos = GetStartPosition();
        GameObject player = startPos != null
            ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
            : Instantiate(playerPrefab);

        // instantiating a "Player" prefab gives it the name "Player(clone)"
        // => appending the connectionId is WAY more useful for debugging!
        player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
        NetworkServer.AddPlayerForConnection(conn, player);
    }


    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
    }



    public void SpawnIngredients(){
        Vector3 offset = new Vector3(-555, -169, -234);
        GameObject[] smallMushroomSpawns;
        GameObject[] bigMushroomSpawns;
        Debug.Log("finding ingredint spawns");
        smallMushroomSpawns = GameObject.FindGameObjectsWithTag("SmallMushroomSpawn");
        foreach(GameObject spawn in smallMushroomSpawns){
            Debug.Log("Making an ingredient");
            GameObject ingredient = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ingredient"));
            ingredient.transform.position = spawn.GetComponent<Transform>().position;
            ingredient.transform.Translate(offset);
            NetworkServer.Spawn(ingredient);
            Debug.Log(spawn.GetComponent<Transform>().position);
        }
    }




}
