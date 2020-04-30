using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Almas : MonoBehaviour
{
	//public Text Score;
	//public int number=5;
	//public int puntos=0;
	public int Daño;



	// Use this for initialization
	void Start () 
	{
		Daño = Random.Range (20,50);
		//Score.text = Convert.ToString (puntos);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	public void OnCollisionEnter2D (Collision2D info)
	{
		
		if (info.gameObject.layer == 8)
		{
			
			Destroy (this.gameObject);

		}
		}



}
