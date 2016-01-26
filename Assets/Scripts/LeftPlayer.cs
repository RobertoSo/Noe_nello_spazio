using UnityEngine;
using System.Collections;

public class LeftPlayer : MonoBehaviour 
{
    public float nextShoot;
    public float timeToKill;
    public float movementSpeed;
    public float shootForce;
    public GameObject projectilePrefab;
    public Transform[] projectileSpawnPoint;
    private GameObject[] projectiles;
    private float timer;
    private float timerProjectileKill;
    private Weapon weapon;


    void Awake()
    {
        weapon = new Weapon();
    }
	// Use this for initialization
	void Start ()
    {
        projectiles = new GameObject[projectileSpawnPoint.Length];
	}
	
	// Update is called once per frame
	void Update ()
    {
        ShipMovement();
        Shoot();
        ProjectileKill();
	}

    private void ShipMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }

    }

    private void Shoot()
    {
        weapon.bullWeapon(projectileSpawnPoint[3]);
    }

    private void ProjectileKill()
    {
            for(int i = 0 ; i < projectiles.Length; i++)
            {
            Destroy(projectiles[i], timeToKill);

            }
    }
}
