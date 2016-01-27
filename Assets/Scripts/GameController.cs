using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    
    public GameObject[] playerTrace = new GameObject[2];
    public GameObject enemy ;
    private int index = 0;
    public float MinimunXAxys;
    public float MaxXAxys;
    public float MinYAxys;
    public float MaxYAxys;
    private bool IsSpawned;
    public int MaxNumberOfAnimals;
    public GameObject animalPowerUp;
    public GameObject[] Animals;
    private GameObject[] AnimalsInScene;

<<<<<<< HEAD

=======
>>>>>>> origin/master

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        InstantiateEnemy();
<<<<<<< HEAD
    }
=======
	}
>>>>>>> origin/master

    public void playerAdd(GameObject playerGameobject)
    {
        playerTrace[index] = playerGameobject;
        index++;
    }

    public void InstantiateEnemy()
    {
        if (IsSpawned == false)
        {
            for (int i = 0; i < MaxNumberOfAnimals; i++)
            {
                GameObject obj;
                int AnimalToSpawn = Random.Range(0, 1);

                Vector3 PositionToSpawn = new Vector3(Random.Range(MinimunXAxys, MaxXAxys), 0, Random.Range(MinYAxys, MaxYAxys));
                obj = Instantiate(Animals[AnimalToSpawn], PositionToSpawn, transform.rotation) as GameObject;
                AnimalsInScene[i] = obj;
                if (i < 5)
                {
                    IsSpawned = true;
                }
            }
        }
    }
<<<<<<< HEAD


=======
    public void InstantiateEnemy()
    {
        if (IsSpawned == false)
        {
            for (int i = 0; i < MaxNumberOfAnimals; i++)
            {
                GameObject obj;
                int AnimalToSpawn = Random.Range(0, 1);

                Vector3 PositionToSpawn = new Vector3(Random.Range(MinimunXAxys, MaxXAxys), 0, Random.Range(MinYAxys, MaxYAxys));
                obj = Instantiate(Animals[AnimalToSpawn], PositionToSpawn, transform.rotation) as GameObject;
                AnimalsInScene[i] = obj;
                if (i < 5)
                {
                    IsSpawned = true;
                }
            }
        }
    }
>>>>>>> origin/master
}
