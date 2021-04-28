using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections.Generic;
// Referenced: https://blogs.unity3d.com/2020/07/01/achieve-better-scene-workflow-with-scriptableobjects/?utm_source=youtube&utm_medium=social&utm_campaign=engine_global_generalpromo_2020-07-01_scene-workflows&utm_content=blog
public class MainMenu : MonoBehaviour
{
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    public GameObject menu;
    public void StartGame()
    {
        // TODO: Add loading bar based of tutorial
        HideMenu();
        SceneManager.LoadSceneAsync("Gameplay");
        SceneManager.LoadSceneAsync("Part01");
        SceneManager.LoadSceneAsync("Part04");
        SceneManager.LoadSceneAsync("Part02");
        SceneManager.LoadSceneAsync("Part05");

    }

    public void HideMenu()
    {
        menu.SetActive(false);
    }
}
