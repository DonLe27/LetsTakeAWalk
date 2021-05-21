using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageJournal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private ManagePlayerData managePlayerData;
    public TMPro.TextMeshProUGUI textMeshPro;
    [SerializeField]
    private GameObject contentsComponent;
    private bool isOpen = false;
    void Start()
    {
        contentsComponent.SetActive(false);
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
        PlayerData playerData = managePlayerData.playerData;
        string journalPage = "";
        foreach (Entry entry in playerData.journal.entries)
        {
            journalPage += string.Format("{0}\n{1}", entry.title, entry.content);
        }
        textMeshPro.text = journalPage;
        contentsComponent.SetActive(true);
    }

    void CloseJournal()
    {
        contentsComponent.SetActive(false);
    }
}
