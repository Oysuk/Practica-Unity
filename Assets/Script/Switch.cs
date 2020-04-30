using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Switch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void ChangeScene(string Nivel2)
	{
		SceneManager.LoadScene(Nivel2);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
