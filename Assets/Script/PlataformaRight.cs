using UnityEngine;
using System.Collections;

public class PlataformaRight : MonoBehaviour
{

	public Vector3 PosicionActual;
	public Vector3 PosicionInicial;
	public Vector3 PosicionFinal;
	public int velocidad;
	public bool Llegada=false;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		PosicionActual = transform.position;

		if (Llegada == false) 
		{

			this.transform.position += transform.right * velocidad * Time.deltaTime;

			if (PosicionActual.x >= PosicionFinal.x)
			{
				Llegada = true;
			}

		} else
		{
			this.transform.position -= transform.right * velocidad * Time.deltaTime;


			if(PosicionActual.x <=PosicionInicial.x)
			{
				Llegada = false;
			}
		}
	
	}
}
