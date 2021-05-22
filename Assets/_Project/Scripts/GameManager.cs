using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool loadScenes = true;
    void Start()
    {
        if (!loadScenes) return;
        List<string> scenes = new List<string> {
            "Part01",
            "Part02",
            "Part04",
            "Part05",
            "Spirits"
        };
        for (int i = 0; i < scenes.Count; i++)
        {
            SceneManager.LoadScene(scenes[i], LoadSceneMode.Additive);

        }
    }

}
