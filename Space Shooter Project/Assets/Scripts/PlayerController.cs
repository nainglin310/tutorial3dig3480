using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public Transform shotSpawn2;
    public Transform shotSpawn3;
    public float fireRate;
    private Rigidbody rb;
    private float nextFire;
    public AudioSource weaponSource;
    public AudioClip weaponSound;

    public bool doubleShot;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        doubleShot = false;
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            if (doubleShot)
            {
                FireBullet();
                StartCoroutine("DoubleCountdown", 0);
            }
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
            weaponSource.clip = weaponSound;
            weaponSource.Play();
        }


    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
             Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
             0.0f,
             Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DoubleShot")
        {
            doubleShot = true;
            Destroy(other.gameObject);
        }
    }

    void FireBullet()
    {
        GameObject Bullet1 = (GameObject)Instantiate(shot);
        Bullet1.transform.position = shotSpawn.transform.position;
        GameObject Bullet2 = (GameObject)Instantiate(shot);
        Bullet2.transform.position = shotSpawn2.transform.position;
        GameObject Bullet3 = (GameObject)Instantiate(shot);
        Bullet3.transform.position = shotSpawn3.transform.position;
    }
    IEnumerator DoubleCountdown()
    {
        yield return new WaitForSeconds(10f);
        doubleShot = false;
    }
} 