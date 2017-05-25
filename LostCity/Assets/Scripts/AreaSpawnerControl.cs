using UnityEngine;

public class AreaSpawnerControl : MonoBehaviour {

    public GameObject Spawner3;
    public GameObject Spawner4;
    public GameObject Spawner5;
    public GameObject Spawner6;
    public GameObject Spawner7;
    public GameObject Spawner8;
    public GameObject Spawner9;
    public GameObject Spawner10;
    public GameObject Spawner11;
    public GameObject Spawner12;

    public static bool Spawner3Active = false;
    public static bool Spawner4Active = false;
    public static bool Spawner5Active = false;
    public static bool Spawner6Active = false;
    public static bool Spawner7Active = false;
    public static bool Spawner8Active = false;
    public static bool Spawner9Active = false;
    public static bool Spawner10Active = false;
    public static bool Spawner11Active = false;
    public static bool Spawner12Active = false;


    void Start()
    {
        Spawner3.SetActive(false);
        Spawner4.SetActive(false);
        Spawner5.SetActive(false);
        Spawner6.SetActive(false);
        Spawner7.SetActive(false);
        Spawner8.SetActive(false);
        Spawner9.SetActive(false);
        Spawner10.SetActive(false);
        Spawner11.SetActive(false);
        Spawner12.SetActive(false);
    }
    void Update()
    {
        if (Spawner3Active==true)
        {
            Spawner3.SetActive(true);
        }
        if (Spawner4Active==true)
        {
            Spawner4.SetActive(true);
        }
        if (Spawner5Active == true)
        {
            Spawner5.SetActive(true);
        }
        if (Spawner6Active == true)
        {
            Spawner6.SetActive(true);
        }
        if (Spawner7Active == true)
        {
            Spawner7.SetActive(true);
        }
        if (Spawner8Active == true)
        {
            Spawner8.SetActive(true);
        }
        if (Spawner9Active == true)
        {
            Spawner9.SetActive(true);
        }
        if (Spawner10Active == true)
        {
            Spawner10.SetActive(true);
        }
        if (Spawner11Active == true)
        {
            Spawner11.SetActive(true);
        }
        if (Spawner12Active == true)
        {
            Spawner12.SetActive(true);
        }
    }
}
