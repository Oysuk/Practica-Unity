using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Prueba : MonoBehaviour
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnTriggerEnter2D (Collider2D info)
	{
		print (info.gameObject.layer);}
}
