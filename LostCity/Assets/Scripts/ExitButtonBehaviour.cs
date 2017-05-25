
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonBehaviour : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        Application.Quit();
    }
    void OnMouseEnter()
    {
        transform.position = new Vector3(-47, 2, 1);
    }

    void OnMouseExit()
    {
        transform.position = new Vector3(-47, 2, -3);
    }
}
