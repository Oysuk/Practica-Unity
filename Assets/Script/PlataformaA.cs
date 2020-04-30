using UnityEngine;
using System.Collections;

public class PlataformaA : MonoBehaviour {


	Botton ScriptB;
	public Vector3 PosicionFinal;
	public Vector3 PosicionActual;
	public int velocidad;

	// Use this for initialization
	void Start () 
	{
		
		PosicionFinal = new Vector3 (10, 0, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		ScriptB = GameObject.Find("Botton (1)").GetComponent<Botton>();

		if (ScriptB.Activado == true) 
		{
			if (this.transform.position.y >= PosicionFinal.y) 
			{
					
				transform.position -= transform.up * velocidad * Time.deltaTime;

			}
			//transform.position -= transform.right * velocidad * Time.deltaTime;
		}
	}


	public void MoverPlataforma ()
	{
		
	}


}
