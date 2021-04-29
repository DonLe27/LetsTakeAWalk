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

}
