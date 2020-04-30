using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadScene()
	{
		SceneManager.LoadScene("GAME1");
	}
}
