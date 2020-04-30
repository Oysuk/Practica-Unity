using UnityEngine;
using System.Collections;

public class PlataformaMovilUp : MonoBehaviour 
{
	public Vector3 PosicionActual;
	public Vector3 PosicionInicial;
	public Vector3 PosicionFinal;
	public int velocidad;
	public bool Baja=false;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		PosicionActual = transform.position;

		if (Baja == false) 
		{
			
			this.transform.position += transform.up * velocidad * Time.deltaTime;

			if (PosicionActual.y >= PosicionFinal.y) 
			{
				Baja = true;
			}

		} else
		{
			this.transform.position -= transform.up * velocidad * Time.deltaTime;


			if(PosicionActual.y <=PosicionInicial.y)
			{
				Baja = false;
			}
		}



	}
}
