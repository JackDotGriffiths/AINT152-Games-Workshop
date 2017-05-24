using UnityEngine;
using System.Collections;
public class ShootBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public static float fireTime = 1f;
    private bool isFiring = false;
    void SetFiring()
    {
        isFiring = false;
    }
    void Fire()
    {
        //http://answers.unity3d.com/questions/175995/can-i-play-multiple-audiosources-from-one-gameobje.html
        var aSources = GetComponents<AudioSource>(GameObject);
        isFiring = true;
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Invoke("SetFiring", fireTime);
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }

    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                Fire();
            }
        }
    }
}
