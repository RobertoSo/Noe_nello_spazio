using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision coll)
    {
        if (CompareTag("Enemy"))
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}
