using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageJournal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private ManagePlayerData managePlayerData;
    public TMPro.TextMeshProUGUI leftPage;
    public TMPro.TextMeshProUGUI rightPage;
    [SerializeField]
    private GameObject contentsComponent;
    [SerializeField]
    private GameObject sketchComponent;
    private bool isOpen = false;
    private int curLeftPage = 0;
    private PlayerData playerData;
    [SerializeField] private CanvasGroup paintingCanvasGroup;
    [SerializeField] private float paintingFadeDuration = 3;
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
        if (isOpen && Input.GetKeyDown("a"))
        {
            TurnPageLeft();
        }
        if (isOpen && Input.GetKeyDown("d"))
        {
            TurnPageRight();
        }
    }
    void OpenJournal()
    {
        playerData = managePlayerData.playerData;
        GetLastQuestion();
        ShowQuestions();
        contentsComponent.SetActive(true);
    }

    void GetLastQuestion()
    {
        int numPages = playerData.journal.entries.Count;
        if (numPages <= 1)
        {
            curLeftPage = numPages;
        }
        else
        { // At least two pages
            if ((numPages) % 2 == 0)
            {
                curLeftPage = numPages - 1;
            }
            else
            {
                curLeftPage = numPages;
            }
        }
    }

    public void TurnSketchToPainting()
    {
        isOpen = true;
        sketchComponent.SetActive(true);
        StartCoroutine(DoPaintingFadeIn());

    }

    public void OpenSketchComponent()
    {
        isOpen = true;
        sketchComponent.SetActive(true);
        Debug.Log("sketch: opened");
    }

    public void ShowQuestions()
    {
        List<Entry> entries = playerData.journal.entries;
        if (curLeftPage < 1)
        {
            leftPage.text = "entry 0\nmaybe I should interact with some spirits...";
            rightPage.text = "";
        }
        else
        {
            leftPage.text = string.Format("entry {0}\n{1}", curLeftPage, entries[curLeftPage - 1].title);
            rightPage.text = curLeftPage == entries.Count ? "" : string.Format("entry {0}\n{1}", curLeftPage + 1, entries[curLeftPage].title);
        }

    }

    public void TurnPageLeft()
    {
        curLeftPage -= 2;
        if (curLeftPage < 1)
        {
            curLeftPage = 1;
        }
        ShowQuestions();
    }
    public void TurnPageRight()
    {
        curLeftPage += 2;
        if (curLeftPage > playerData.journal.entries.Count)
        {
            GetLastQuestion();
        }
        ShowQuestions();
    }

    void CloseJournal()
    {
        contentsComponent.SetActive(false);
        sketchComponent.SetActive(false);
        isOpen = false;
    }

    public IEnumerator DoPaintingFadeIn()
    {
        float counter = 0f;
        while (counter < paintingFadeDuration)
        {
            counter += Time.deltaTime;
            paintingCanvasGroup.alpha = Mathf.Lerp(0, 1, counter / paintingFadeDuration);
            yield return null;
        }
    }
}
