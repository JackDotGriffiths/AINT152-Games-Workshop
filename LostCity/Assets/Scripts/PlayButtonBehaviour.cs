
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonBehaviour : MonoBehaviour {



    void OnMouseDown()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("Main");
    } 
    void OnMouseEnter()
    {
        transform.position = new Vector3(-50, 2, 1);
    }

    void OnMouseExit()
    {
        transform.position = new Vector3(-50, 2, -3);
    }
}
