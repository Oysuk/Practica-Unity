using UnityEngine;
using System.Collections;

public class Vidas : MonoBehaviour 
{
	Heroe Contador;
	public GameObject Vida1;
	public GameObject Vida2;
	public GameObject Vida3;

	// Use this for initialization
	void Start ()
	{
		Contador = GameObject.Find("Heroe").GetComponent<Heroe>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Contador.vidas==2)
		{
			Destroy(Vida3);

		}

		if (Contador.vidas == 1) {
			Destroy (Vida2);
		}

		if (Contador.vidas == 0) {
			Destroy (Vida1);
		}
	}
}
