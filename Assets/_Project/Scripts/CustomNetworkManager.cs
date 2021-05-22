using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class CustomNetworkManager : NetworkManager
{
    [SerializeField] private bool usingSteamworks = false;
    [SerializeField] private int numberOfPlayers = 0;

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
        numberOfPlayers++;

        // Add player at spawn position
        Transform startPos = GetStartPosition();
        GameObject player = startPos != null
            ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
            : Instantiate(playerPrefab);

        // instantiating a "Player" prefab gives it the name "Player(clone)"
        // => appending the connectionId is WAY more useful for debugging!
        player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
        NetworkServer.AddPlayerForConnection(conn, player);

        // Spawn Spirits
        if (numberOfPlayers > 1)
            FindObjectOfType<SpiritSpawner>().SpawnSpirits();
    }
    
    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
    }

    public void SpawnIngredients(){
        //spawn each ingredient specifying ingredient name and number to spawn
        SpawnSpecificIngredient("SmallMushroom", 300);
        SpawnSpecificIngredient("BigMushroom", 100);
        SpawnSpecificIngredient("LotusRoot", 100);
        SpawnSpecificIngredient("BokChoy", 100);
        SpawnSpecificIngredient("Gyoza", 100);
        SpawnSpecificIngredient("NormalSoupBase", 100);
        SpawnSpecificIngredient("SpicySoupBase", 100);
    }

    public void SpawnSpecificIngredient(string ingredientName, int n){
        Vector3 offset = new Vector3(-555, -169, -234);
        GameObject[] ingredientSpawns;
        HashSet<int> chosenIndices;
        int length;
        ingredientSpawns = GameObject.FindGameObjectsWithTag(ingredientName+"Spawn");
        length = ingredientSpawns.Length;
        chosenIndices = GenerateRandomNums(n, length);
        foreach(int i in chosenIndices){
            GameObject spawn = ingredientSpawns[i];
            GameObject ingredient = Instantiate(spawnPrefabs.Find(prefab => prefab.name == ingredientName));
            ingredient.transform.position = spawn.GetComponent<Transform>().position;
            ingredient.transform.Translate(offset);
            NetworkServer.Spawn(ingredient);
            //Debug.Log(spawn.GetComponent<Transform>().position);
        }
    }

    //takes in number of random ints to generate as well as maxExclusive in range
    //returns a HashSet of n unique randomly generated numbers
    public HashSet<int> GenerateRandomNums(int n, int maxExclusive){
        HashSet<int> result = new HashSet<int>();
        
        int num;
        if(n>=maxExclusive){ //if n>= the max, create a set of all numbers up to maxExclusive
            for (int i = 0; i < maxExclusive; i++){
                result.Add(i);
            }
        }
        else
        { //otherwise randomly choose n unique numbers from 0 to maxExclusive-1
            while (result.Count < n)
            {
                num = Random.Range(0, maxExclusive);
                if (!result.Contains(num))
                {
                    result.Add(num);
                }
            }
        }
        return result;
    }




}
