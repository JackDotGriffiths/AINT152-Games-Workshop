
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene("Main");
    } 
    void OnMouseEnter()
    {
        transform.position = new Vector3(-49, 2, 1);
    }

    void OnMouseExit()
    {
        transform.position = new Vector3(-49, 2, -1);
    }
}
