using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Villanos : MonoBehaviour 
{
	/*
	 * // variable to hold a reference to our SpriteRenderer component
	private SpriteRenderer mySpriteRenderer;

	// This function is called just one time by Unity the moment the game loads
	private void Awake()
	{
		// get a reference to the SpriteRenderer component on this gameObject
		mySpriteRenderer = GetComponent<SpriteRenderer>();
	}

	// This function is called by Unity every frame
	private void Update()
	{
		// if the variable isn't empty (we have a reference to our SpriteRenderer)
		if(mySpriteRenderer != null)
		{
			// if the A key was pressed this frame
			if(Input.GetKeyDown(KeyCode.A))
			{
				// flip the sprite
				mySpriteRenderer.flipX = true;
			}
		}
	}
	*/
	// private SpriteRenderer mySpriteRenderer;

	//public SpriteRenderer Xpositivo;

	public Vector3 PosicionActual;
	public bool Prueba;
	public int Velocidad;
	public int Vida;
	public int Daño;

	Main ScriptMain;
	Balas ScriptBalas;

	public GameObject BalaE;
	public int Bullet=3;
	public int Fire=0;
	public float TimeShooting;
	public float Reloading;

	public bool test;

	public Vector3 LugarTexto;

	public SpriteRenderer sp;



	// Use this for initialization
	void Start () 
	{
		ScriptMain = GameObject.Find ("Main Camera").GetComponent<Main> ();
		sp = GetComponent<SpriteRenderer>();

		Prueba = false;

		//mySpriteRenderer = GetComponent<SpriteRenderer>();
//		Xpositivo=GetComponent<SpriteRenderer>();
		Vida = 100;
	}
	
	// Update is called once per frame
	void Update ()
	{
//		ScriptBalas= GameObject.Find("Bala").GetComponent<Balas> ();
		PosicionActual = transform.position;
		TimeShooting -= Time.deltaTime;
		Shoot ();
	}



	public void OnTriggerEnter2D(Collider2D obj)
	{
		

		if(obj.gameObject.layer == 10)
		{
			
			Daño = Random.Range (20, 50);

			Vida = Vida - Daño;

			print("Daño Recibido "+ Daño + "Vida= "+ Vida);

			Prueba = true;
			print (Prueba);

			//LugarTexto = transform.position;

			if (Vida <= 0)
			{
				Destroy(this.gameObject);
			}

		

		
		   
		}
 		/* if (ScriptMain.LevelName == "Nivel2") 
		{
			
		}
		*/

	}

	public void Shoot()
	{
		

		if (Fire < Bullet) {


			GameObject objeto = Instantiate (BalaE);

			objeto.transform.position = transform.position;

			Fire++;
			//Daño = Random.Range (20,50);

			//print (Fire);

			BalasE aux = objeto.GetComponent<BalasE> ();

			/*if(test== true)
			{
				aux.direccion = -1;

			}*/

		}

		
	}

	public void PATO()
	{
		
	}
}