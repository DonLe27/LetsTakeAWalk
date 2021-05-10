using UnityEngine;

// Changes during the game will change this playerData object
// On unload it will use the data manager to write out
public class ManagePlayerData : MonoBehaviour
{
    public PlayerData playerData;
    void Start()
    {
        playerData = DataManager.Load();
    }

    // Write the data to file
    void OnDestroy()
    {
        DataManager.Save(playerData);
    }

    public void ReceivePrompt(string prompt)
    {
        // Check if prompt has been received
        foreach (Entry entry in playerData.journal.entries)
        {
            if (prompt == entry.title) return;
        }
        playerData.journal.entries.Add(new Entry(prompt));

    }

    //function for updating the players ingredient inventory given the id of 
    //the ingredient to be updated
    //isAdding is a bool to tell if the item is being added to players inventory
    //if !isAdded item is being removed from players inventory
    public void updateIngredients(IngredientID id, bool isAdding){
        if(isAdding){
            playerData.ingredients[(int)id]+=1;
        }
        else{
            playerData.ingredients[(int)id]-=1;
        }
    }

    //returns how many units of a given item the player has in their inventory based on the ingredient ID
    public int getIngredientCount(int index){
        return playerData.ingredients[index];
    }

}
