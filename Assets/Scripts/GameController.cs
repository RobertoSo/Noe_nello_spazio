﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    
    public GameObject[] playerTrace = new GameObject[2];
    public GameObject enemy ;
    private int index = 0;
    public Transform MinX;
    public Transform MaxX;
    public Transform MinZ;
    public Transform MaxZ;
    private bool IsSpawned = false;
    public int MaxNumberOfAnimals;
    //public GameObject animalPowerUp;
    public GameObject[] Animals;
    private GameObject[] AnimalsInScene;
    public static int ScorePlayerOne;
    public static int ScorePlayerTwo;
    private int animalCounter = 0;



    // Use this for initialization
    void Start ()
    {
        AnimalsInScene = new GameObject[MaxNumberOfAnimals];
	}
	
	// Update is called once per frame
	void Update ()
    {
        InstantiateEnemy();
    }
	


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
                int AnimalToSpawn = Random.Range(0, 2);

                Vector3 PositionToSpawn = new Vector3(Random.Range(MinX.position.x, MaxX.position.x), 0, Random.Range(MinZ.position.z, MaxZ.position.z));
                obj = Instantiate(Animals[AnimalToSpawn], PositionToSpawn,Quaternion.identity) as GameObject;
                AnimalsInScene[i] = obj;
                animalCounter++;
            }
        }
        if (animalCounter >= MaxNumberOfAnimals - 1)
        {
            IsSpawned = true;
            animalCounter = 0;
        }

    }
}
