using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    
    public GameObject[] playerTrace = new GameObject[2];
    public GameObject enemy ;
    private int index = 0;
    

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void playerAdd(GameObject playerGameobject)
    {
        playerTrace[index] = playerGameobject;
        index++;
    }

    public GameObject GetEnemy(GameObject playerGameobject)
    {
        if(playerGameobject.CompareTag("PlayerOne"))
        {
            enemy = playerTrace[1];
        }
        else
        {
            enemy = playerTrace[0];
        }
        return enemy;
    }
}
