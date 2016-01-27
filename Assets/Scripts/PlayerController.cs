using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public float nextShoot;
    public float timeToKill;
    public float movementSpeed;
    public float shootForce;
    public GameObject projectilePrefab;
    public Transform[] projectileSpawnPoint;
    public float TimeToRotate;

    private GameObject[] projectiles;
    private float timer;
    private float timerProjectileKill;
    public Weapon weapon;
    public GameController gameController;
    public GameObject enemyGameobject;


    void Awake()
    {
        
    }
	// Use this for initialization
	void Start ()
    {
        gameController = Camera.main.GetComponent<GameController>();
        gameController.playerAdd(this.gameObject);
        //weapon = this.gameObject.GetComponent<Weapon>();
        projectiles = new GameObject[projectileSpawnPoint.Length];
        WhoIsEnemy(this.gameObject);
        //enemyGameobject =  gameController.GetEnemy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
        FirstShipMovement();
        SecondShipMovement();
        PlayerOneShoot();
        PlayerTwoShoot();
        ProjectileKill();
	}

    private void FirstShipMovement()
    {
        if (this.gameObject.CompareTag("PlayerOne"))
        {
            if (Input.GetKey(KeyCode.W))
            {
                Quaternion rotationUp = Quaternion.Euler(0, 90, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotationUp, TimeToRotate * Time.time);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Quaternion rotationDown = Quaternion.Euler(0, -90, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotationDown, TimeToRotate * Time.time);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Quaternion rotationLeft = Quaternion.Euler(0, 180, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotationLeft, TimeToRotate * Time.time);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Quaternion rotationRight = Quaternion.Euler(0, 0, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotationRight, TimeToRotate * Time.time);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
        }
       
    }
    private void SecondShipMovement()
    {
        if (this.gameObject.CompareTag("PlayerTwo"))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Quaternion rotationUp = Quaternion.Euler(0, 90, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotationUp, TimeToRotate * Time.time);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Quaternion rotationDown = Quaternion.Euler(0, -90, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotationDown, TimeToRotate * Time.time);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Quaternion rotationLeft = Quaternion.Euler(0, 180, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotationLeft, TimeToRotate * Time.time);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Quaternion rotationRight = Quaternion.Euler(0, 0, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotationRight, TimeToRotate * Time.time);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
        }
    }

    private void PlayerOneShoot()
    {
        if(this.gameObject.CompareTag("PlayerOne"))
        {
            weapon = this.gameObject.GetComponent<Weapon>();
            //gameController = Camera.main.GetComponent<GameController>();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(weapon);
                Debug.Log(gameController);
                Debug.Log(enemyGameobject);
                weapon.bullWeapon(projectileSpawnPoint[3], enemyGameobject.transform);
            }
        }
        
    }

    private void PlayerTwoShoot()
    {
        if (this.gameObject.CompareTag("PlayerTwo"))
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                weapon.bullWeapon(projectileSpawnPoint[3], enemyGameobject.transform);
            }
        }
    }

    private void ProjectileKill()
    {
            for(int i = 0 ; i < projectiles.Length; i++)
            {
                Destroy(projectiles[i], timeToKill);
            }
    }

    private void WhoIsEnemy(GameObject obj)
    {
        if (obj.CompareTag("PlayerOne"))
        {
            enemyGameobject = GameObject.FindGameObjectWithTag("PlayerTwo");
        }
        else
        {
            enemyGameobject = GameObject.FindGameObjectWithTag("PlayerOne");
        }
    }
}
