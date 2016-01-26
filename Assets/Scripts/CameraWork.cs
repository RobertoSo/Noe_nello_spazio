using UnityEngine;
using System.Collections;

public class CameraWork : MonoBehaviour
{
    public Transform target;
    public float cameraSmoothSpeed;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
       transform.position = Vector3.Lerp(transform.position, target.transform.position, cameraSmoothSpeed * Time.deltaTime);    
	}
}
