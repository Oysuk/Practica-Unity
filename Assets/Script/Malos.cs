using UnityEngine;
using System.Collections;

public class Malos : MonoBehaviour 
{

	public Vector3 PosicionActual;
	public bool Cambio;
	public int Velocidad;
	public int Vida;
	public int Daño;

	#region "VARIABLES DISPAROS"

	//public GameObject BalaE;
	public int Bullet=3;
	public int Fire=0;
	public float TimeShooting;
	public float Reloading;

	#endregion

	public SpriteRenderer sp;

	// Use this for initialization
	void Start () 
	{
		
		Vida = 100;
		sp = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		Move ();
		sp = GetComponent<SpriteRenderer>();
		PosicionActual = transform.position;
		TimeShooting -= Time.deltaTime;
		//Shoot ();
	}



		
		 public void OnTriggerEnter2D(Collider2D obj)
	{

		if(obj.gameObject.layer == 10)
		{

			Daño = Random.Range (20, 50);

			Vida = Vida - Daño;

			print("Daño Recibido "+ Daño + "Vida= "+ Vida);

			//LugarTexto = transform.position;

			if (Vida <= 0)
			{
				Destroy(this.gameObject);
			}

		}
		}

	public void OnCollisionEnter2D (Collision2D info)
	{
		print ("entro");
		if (info.gameObject.layer == 19) 
		{
			print ("hicimos colision");

			if (sp.flipX == true) 
			{
				print ("hola");
				this.transform.position += transform.right * Velocidad * Time.deltaTime;
				sp.flipX = false;
			} else {
				print ("chau");
				this.transform.position -= transform.right * Velocidad * Time.deltaTime;
				sp.flipX = true;
			}
		}
	}

	public void Move()
	{
		this.transform.position -= transform.right * Velocidad * Time.deltaTime;
	}
}
