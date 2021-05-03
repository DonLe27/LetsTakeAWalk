using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Part01", LoadSceneMode.Additive);
        SceneManager.LoadScene("Part04", LoadSceneMode.Additive);
        SceneManager.LoadScene("Part02", LoadSceneMode.Additive);
        SceneManager.LoadScene("Part05", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
