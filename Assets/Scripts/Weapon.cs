using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
    public GameObject bullPrefab;
    public GameObject hedgehogPrefab;
    public GameObject turtlePrefab;
    public float bullLerpTime;
    public PlayerController playerController;
    public Transform[] projectileSpawnPoint;
    public float bullTimeToDestroy;

    private GameObject[] projectiles;
    private float timer;
    private float timerProjectileKill;
    public float timeToKill;
    public float nextShoot;
    public List<GameObject> shooted;
    public GameObject projectilePrefab;
    public float shootForce;
    public float turtleShootForce;
    //private GameObject obj;

    enum weapons
    {
        bull,
        hedgehog,
        turtle
    }
    // Use this for initialization
    void Start()
    {
        projectiles = new GameObject[projectileSpawnPoint.Length];
    }

    // Update is called once per frame
    void Update()
    {
        HedgehogProjectileKill();
    }

    public void bullWeapon(Transform playerPos, Transform enemyPos)
    {
        GameObject obj = Instantiate(bullPrefab, playerPos.position, Quaternion.identity) as GameObject;
        shooted.Add(obj);
        //obj.GetComponent<Rigidbody>().AddForce(bullAccelForce * Vector3.forward, ForceMode.Acceleration);
        StartCoroutine(bullPath(enemyPos));
    }

    private IEnumerator bullPath(Transform enemyPos)
    {
        while (true)
        {
            shooted[0].transform.position = Vector3.Lerp(shooted[0].transform.position, enemyPos.position, bullLerpTime * Time.time);
            yield return null;
        }
        
    }

    public void hedgehogWeapon()
    {
        GameObject projectile;
        for (int i = 0; i < projectileSpawnPoint.Length; i++)
        {
            projectile = Instantiate(projectilePrefab, projectileSpawnPoint[i].position, Quaternion.identity) as GameObject;
            projectiles[i] = projectile;
            Vector3 relativeShootDir = projectileSpawnPoint[i].TransformDirection(Vector3.forward);
            projectile.GetComponent<Rigidbody>().AddRelativeForce(shootForce * relativeShootDir, ForceMode.Impulse);
        }
    }
    private void HedgehogProjectileKill()
    {
        for (int i = 0; i < projectiles.Length; i++)
        {
            Destroy(projectiles[i], timeToKill);
        }
    }

    private void BullProjectileKill()
    {
        StopAllCoroutines();
        Destroy(shooted[0], bullTimeToDestroy);
        shooted.Remove(shooted[0]);
    }

   
    public void turtleWeapon()
    {
        GameObject projectile;
        projectile = Instantiate(projectilePrefab, projectileSpawnPoint[2].position, Quaternion.identity) as GameObject;
        projectile.GetComponent<Rigidbody>().AddForce(Vector3.forward * turtleShootForce , ForceMode.Impulse);
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
