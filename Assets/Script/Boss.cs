using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour 
{
	public int Vida;
	public Vector3 PosicionInicial;
	public Vector3 PosicionA;
	public Vector3 PosicionB;
	public Vector3 PosicionC;
	public Vector3 PosicionActual;
	public int Velocidad;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		PosicionActual = transform.position;

		if (PosicionActual==PosicionInicial)
		{
			this.transform.position += transform.right * Velocidad * Time.deltaTime;

		}
	}

	public void OnTriggerEnter2D(Collider2D obj)
	{
		if(obj.gameObject.layer == 10)
		{
			Vida--;

		}
	}
}
