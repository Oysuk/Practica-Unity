using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GAMEOVER : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if( Input.GetKeyDown(KeyCode.Return))
		{
			print ("pasa por aca");
			SceneManager.LoadScene ("GAME1");

		

		}

	}
}
