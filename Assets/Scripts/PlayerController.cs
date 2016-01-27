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
<<<<<<< HEAD
    private bool bullWeapon;
    private bool turtleWeapon;

=======
    public int ScoreForAnimal;
    private bool AnimalPickedUpOne;
    private bool AnimalPickedUpTwo;
>>>>>>> origin/master
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                /* Debug.Log(weapon);
                 Debug.Log(gameController);
                 Debug.Log(enemyGameobject);
                 weapon.bullWeapon(weapon.projectileSpawnPoint[3], enemyGameobject.transform);*/
                weapon.turtleWeapon();
            }
        }
        
    }

    private void PlayerTwoShoot()
    {
        if (this.gameObject.CompareTag("PlayerTwo"))
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                weapon.bullWeapon(weapon.projectileSpawnPoint[3], enemyGameobject.transform);
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
    void OnCollisionEnter(Collision coll)
    {
        if (CompareTag("Bull"))
        {

        }
    }

<<<<<<< HEAD
    private void MyWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

=======
    /* private void MyWeapon()
     {
         if(Input.GetKeyDown(KeyCode.))
     }*/
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Bull" && gameObject.tag == "PlayerOne")
        {

            AnimalPickedUpOne = true;
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "Turtle" && gameObject.tag == "PlayerOne")
        {
            AnimalPickedUpOne = true;
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "Bull" && gameObject.tag == "PlayerTwo")
        {
            AnimalPickedUpTwo = true;
            Destroy(coll.gameObject);
        }
        AnimalPickedUpTwo = true;

        if (coll.gameObject.tag == "Turtle" && gameObject.tag == "PlayerTwo")
        {
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
>>>>>>> origin/master
        }
    }
}
