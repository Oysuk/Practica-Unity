using UnityEngine;
using System.Collections;

public class Botton : MonoBehaviour 
{
	public bool Activado=false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void OnTriggerEnter2D(Collider2D info)
	{
		if (info.gameObject.layer == 8)
		{
			Activado = true;

		}
	}
}
