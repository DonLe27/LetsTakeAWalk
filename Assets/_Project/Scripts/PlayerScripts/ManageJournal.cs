using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageJournal : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerData playerData;
    public TMPro.TextMeshProUGUI textMeshPro;
    public GameObject journalUI;
    private bool isOpen = false;
    void Start()
    {
        playerData = GetComponent<ManagePlayerData>().playerData;
        journalUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("n"))
        {
            if (isOpen)
            {
                CloseJournal();
                isOpen = false;
            }
            else
            {
                OpenJournal();
                isOpen = true;
            }
        }
    }
    void OpenJournal()
    {
        journalUI.SetActive(true);
        playerData = GetComponent<ManagePlayerData>().playerData;
        string journalPage = "";
        foreach (Entry entry in playerData.journal.entries)
        {
            journalPage += string.Format("{0}\n{1}\n\n ", entry.title, entry.content);
        }
        textMeshPro.text = journalPage;

    }

    void CloseJournal()
    {
        journalUI.SetActive(false);
    }
}
