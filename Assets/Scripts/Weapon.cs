using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
    public GameObject bullPrefab;
    public GameObject hedgehogPrefab;
    public GameObject cheetaPrefab;
    public GameObject giraffePrefab;
    public GameObject turtlePrefab;
    public float bullAccelForce;

    private List<GameObject> shooted;
    private GameObject obj;

    enum weapons
    {
        bull,
        hedgehog,
        cheeta,
        giraffe,
        turtle
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void bullWeapon(Transform transform)
    {

        obj = Instantiate(bullPrefab, transform.position, Quaternion.identity) as GameObject;
        shooted.Add(obj);
        obj.GetComponent<Rigidbody>().AddForce(bullAccelForce * Vector3.forward, ForceMode.Acceleration);
    }

    public void hedgehogWeapon()
    {

    }

    public void cheetaWeapon()
    {

    }

    public void giraffeWeapon()
    {

    }
    public void turtleWeapon()
    {

    }

    /*GameObject projectile;
                for (int i = 0; i<projectileSpawnPoint.Length; i++)
                {
                    projectile = Instantiate(projectilePrefab, projectileSpawnPoint[i].position, Quaternion.identity) as GameObject;
                    projectiles[i] = projectile;
                    Vector3 relativeShootDir = projectileSpawnPoint[i].TransformDirection(Vector3.forward);
    projectile.GetComponent<Rigidbody>().AddRelativeForce(shootForce* relativeShootDir, ForceMode.Impulse);
}
timer = 0;
if(timer >= nextShoot)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
               
            }
            
        }
        else
        {
            timer += Time.deltaTime;
        }*/
}
