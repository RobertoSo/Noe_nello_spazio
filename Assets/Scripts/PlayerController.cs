using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
   
    
    public float movementSpeed;
    public float TimeToRotate;
    public Weapon weapon;
    public GameController gameController;
    public GameObject enemyGameobject;
    private int myWeapon;
    public float slowTime;
    public float slowedShipSpeed;
    

    private bool bullWeapon = false;
    private bool turtleWeapon = false;
    private bool hedgehogWeapon = true;
    private bool shootedPickupWeapon = false;


    public int ScoreForAnimal;
    private bool AnimalPickedUpOne;
    private bool AnimalPickedUpTwo;
    public float CounterRotation;
    private float previousSpeed;
    private float slowTimeCounter;
    private bool slowed = false;

    public Transform MinX;
    public Transform MaxX;
    public Transform MinZ;
    public Transform MaxZ;

    void Awake()
    {
        
    }
	// Use this for initialization
	void Start ()
    {
        gameController = Camera.main.GetComponent<GameController>();
        gameController.playerAdd(this.gameObject);
        weapon = this.gameObject.GetComponent<Weapon>();
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
        TurtleEffect();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX.position.x, MaxX.position.x), 0, Mathf.Clamp(transform.position.z, MinZ.position.z, MaxZ.position.z));

    }

    private void FirstShipMovement()
    {
        if (this.gameObject.CompareTag("PlayerOne"))
        {
            if (Input.GetKey(KeyCode.W))
            {
                Quaternion rotationUp = Quaternion.Euler(0, 90, 0);

                for (float i = 0; i <= 1; i += CounterRotation)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotationUp, i);
                }
               transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Quaternion rotationDown = Quaternion.Euler(0, -90, 0);
                for (float i = 0; i <= 1; i += CounterRotation)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotationDown, i);
                }
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Quaternion rotationLeft = Quaternion.Euler(0, 180, 0);
                for (float i = 0; i <= 1; i += CounterRotation)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotationLeft, i);
                }
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Quaternion rotationRight = Quaternion.Euler(0, 0, 0);
                for (float i = 0; i <= 1; i += CounterRotation)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotationRight, i);
                }
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

                for (float i = 0; i <= 1; i += CounterRotation)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotationUp, i);
                }
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Quaternion rotationDown = Quaternion.Euler(0, -90, 0);
                for (float i = 0; i <= 1; i += CounterRotation)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotationDown, i);
                }
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Quaternion rotationLeft = Quaternion.Euler(0, 180, 0);
                for (float i = 0; i <= 1; i += CounterRotation)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotationLeft, i);
                }
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Quaternion rotationRight = Quaternion.Euler(0, 0, 0);
                for (float i = 0; i <= 1; i += CounterRotation)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotationRight,i);
                }
                    transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            
        }
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX.position.x, MaxX.position.x), 0, Mathf.Clamp(transform.position.z, MinZ.position.z, MaxZ.position.z));
    }

    private void PlayerOneShoot()
    {
        if(this.gameObject.CompareTag("PlayerOne"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if ((bullWeapon) && (!hedgehogWeapon))
                {
                    weapon.bullWeapon(weapon.projectileSpawnPoint[2], enemyGameobject.transform);
                    bullWeapon = false;
                    hedgehogWeapon = true;
                }
                else if((turtleWeapon)&& (!hedgehogWeapon))
                {
                    weapon.turtleWeapon();
                    turtleWeapon = false;
                    hedgehogWeapon = true;
                }
                else
                {
                    weapon.hedgehogWeapon();
                }
                
            }
        }
        
    }

    private void PlayerTwoShoot()
    {
        if (this.gameObject.CompareTag("PlayerTwo"))
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if ((bullWeapon) && (!hedgehogWeapon))
                {
                    weapon.bullWeapon(weapon.projectileSpawnPoint[2], enemyGameobject.transform);
                    bullWeapon = false;
                    hedgehogWeapon = true;
                }
                else if ((turtleWeapon) && (!hedgehogWeapon))
                {
                    weapon.turtleWeapon();
                    turtleWeapon = false;
                    hedgehogWeapon = true;
                }
                else
                {
                    weapon.hedgehogWeapon();
                }
            }
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
   /* void OnCollisionEnter(Collision coll)
    {
        if (CompareTag("PlayerOne"))
        {
            if (CompareTag("Bull"))
            {
                AnimalPickedUpOne = false;
            }
            if (CompareTag("Turtle"))
            {
                slowed = true;
                AnimalPickedUpOne = false;
            }
            if (CompareTag("HedgehogBullet"))
            {
                AnimalPickedUpOne = false;
                Destroy(gameObject);
            }
        }
        if (CompareTag("PlayerTwo"))
        {
            if (CompareTag("Bull"))
            {
                AnimalPickedUpOne = false;
            }
            if (CompareTag("Turtle"))
            {
                slowed = true;
                AnimalPickedUpOne = false;
            }
            if (CompareTag("HedgehogBullet"))
            {
                AnimalPickedUpOne = false;
                Destroy(coll.gameObject);
            }
        }
        
    }*/

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Bull" && gameObject.tag == "PlayerOne")
        {
            hedgehogWeapon = false;
            bullWeapon = true;
            AnimalPickedUpOne = true;
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "Turtle" && gameObject.tag == "PlayerOne")
        {
            hedgehogWeapon = false;
            turtleWeapon = true;
            AnimalPickedUpOne = true;
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "Bull" && gameObject.tag == "PlayerTwo")
        {
            hedgehogWeapon = false;
            bullWeapon = true;
            AnimalPickedUpTwo = true;
            Destroy(coll.gameObject);
        }
        AnimalPickedUpTwo = true;

        if (coll.gameObject.tag == "Turtle" && gameObject.tag == "PlayerTwo")
        {
            hedgehogWeapon = false;
            turtleWeapon = true;
            AnimalPickedUpTwo = true;
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "Planet" && AnimalPickedUpOne == true && gameObject.tag == "PlayerOne")
        {
            AnimalPickedUpOne = false;
            GameController.ScorePlayerOne += ScoreForAnimal;
        }
        if (coll.gameObject.tag == "Planet" && AnimalPickedUpTwo == true && gameObject.tag == "PlayerTwo")
        {
            AnimalPickedUpTwo = false;
            GameController.ScorePlayerTwo += ScoreForAnimal;

        }
        if (CompareTag("PlayerOne"))
        {
            if (CompareTag("Bull"))
            {
                AnimalPickedUpOne = false;
            }
            if (CompareTag("Turtle"))
            {
                slowed = true;
                AnimalPickedUpOne = false;
            }
            if (CompareTag("HedgehogBullet"))
            {
                AnimalPickedUpOne = false;
                Destroy(gameObject);
            }
        }
        if (CompareTag("PlayerTwo"))
        {
            if (coll.gameObject.CompareTag("Bull"))
            {
                AnimalPickedUpOne = false;
            }
            if (coll.gameObject.CompareTag("Turtle"))
            {
                slowed = true;
                AnimalPickedUpOne = false;
            }
            if (coll.gameObject.CompareTag("HedgehogBullet"))
            {
                AnimalPickedUpOne = false;
                Destroy(coll.gameObject);
            }
        }
    }

    private void TurtleEffect()
    {
       
        if (slowed)
        {
            previousSpeed = movementSpeed;
            if (slowTimeCounter >= slowTime)
            {
                movementSpeed = previousSpeed;
                slowed = false;
            }
            
            else
            {
                slowTimeCounter += Time.deltaTime;
                movementSpeed = slowedShipSpeed;
            }
        }
        
        
    }

   
}
