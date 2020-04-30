using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Heroe : MonoBehaviour 
{

	#region Variables
	public Vector3 nuevaPosicion;
	public Vector3 nuevaEscala;
	public float velocidad;
	public Vector3 PosicionActual;
	public Rigidbody2D rb;
    //public Animator anim;
	public SpriteRenderer sp;
	public int Villanos = 9;
	public int Caida = 14;
	public int Pinches = 15;
	public bool ColisionDoor;


	#region Variables Salto
	public Vector3 LimiteSalto;
	//public Vector3 PosActualSalto;
	//public Vector3 PosInicialSalto;
	//public Vector3 PosFinalSalto;
	public float TimeJump=0.0f;
	public float DelayJump;
	public float ForceJump;
	public bool Jump=false;
	#endregion

	#region Variables Shoot
	public GameObject Bala;
	public int Bullet=3;
	public int Fire=0;
	public float TimeShooting;
	public float Reloading;
	#endregion

	public Text ContadorDeVidas;
	public int vidas=3;

	public int score=0;

	Main ScriptMain;
	#endregion

	public GameObject HeroeDown;
	public GameObject PrefabHeroe;

	public int Daño;

	// Use this for initialization
	void Start () 
	{
		//ContadorDeVidas.text=Convert.ToString(vidas);
		//nuevaPosicion =  (-10, -3, 0);
		sp = GetComponent<SpriteRenderer>();
		transform.position = nuevaPosicion;
		rb = GetComponent<Rigidbody2D>();
		//scriptA = GameObject.Find("Heroe").GetComponent<Heroe>();
		ScriptMain = GameObject.Find ("Main Camera").GetComponent<Main> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		TimeJump -= Time.deltaTime;
		TimeShooting -= Time.deltaTime;


		if (ScriptMain.LevelName == "Nivel2") 
		{
			if (Input.GetKeyUp (KeyCode.DownArrow)) 
			{
				PrefabHeroe = Instantiate (PrefabHeroe);
				PrefabHeroe.transform.position = ScriptMain.PosicionHeroe;
				Destroy (this.gameObject);
			}
			if (Input.GetKeyDown (KeyCode.DownArrow)) 
			{
				HeroeDown = Instantiate (HeroeDown);
				HeroeDown.transform.position = ScriptMain.PosicionHeroe;
				Destroy (this.gameObject);

			}
		} else 
		{
			
		}


		#region Acciones

		#region Movimiento
	
		//Movimiento Izquierda
		if(Input.GetKey(KeyCode.LeftArrow))

		{
			transform.position -= transform.right * velocidad * Time.deltaTime;
			sp.flipX = true;
		}

		//Movimiento Derecha
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += transform.right * velocidad * Time.deltaTime;
			sp.flipX=false;
		}

		//Salto
		if (Input.GetKeyDown (KeyCode.Space)) 
		{ 
			Saltar();
			#region ERROR
			// PosInicialSalto= transform.position;


			//			do{
			//				PosicionActual = transform.position;
			//			}while (PosicionActual==PosInicialSalto);


			/*	PosInicialSalto = transform.position;

			PosFinalSalto = PosInicialSalto;

			PosFinalSalto.y= PosInicialSalto.y + LimiteSalto.y;

            PosActualSalto = PosInicialSalto;

			do {
				PosActualSalto += transform.up * 1* Time.deltaTime;
				transform.position = PosActualSalto;
				print ("chau" + PosActualSalto);
				velocidad--;
			} while (PosActualSalto.y >= PosFinalSalto.y);
//			velocidad = 0;
//
//			do {
//				PosActualSalto -= transform.up * 5 * Time.deltaTime;
//				transform.position = PosActualSalto;
//				print ("chau" + PosActualSalto);
//				numero++;
//				velocidad++;
//
//			} while (PosActualSalto.y <= PosInicialSalto.y || numero==10 );

			//transform.position = PosInicialSalto;

			print ("hola"+ PosActualSalto);
			*/
			#endregion
		}

		#endregion 

		#region Disparar
		if (Input.GetKeyDown(KeyCode.Return))
		{	
			Shoot();
		}
		#endregion



	}

	public void Shoot()
	{
		if(Fire<Bullet)
		{
			

			GameObject objeto = Instantiate(Bala);

			objeto.transform.position = transform.position;

			Fire++;
			//Daño = Random.Range (20,50);

			//print (Fire);

			Balas aux = objeto.GetComponent<Balas>();

			if(sp.flipX == true)
			{
				aux.direccion = -1;

			}

		}

		if (Fire == Bullet && TimeShooting < Reloading) 
		{
			TimeShooting = 0;
			Fire = 0;
		}


	}
			

	public void Saltar()
	{

		/*if(Jump==false)
		{
				Jump = true;

				rb.AddForce(Vector3.up * ForceJump, ForceMode2D.Impulse);

				TimeJump = 0;
				

		}


		if (Jump ==true && TimeJump<DelayJump) 
		{
			
			Jump = false;

		}
		*/
		if(TimeJump<DelayJump)
		{
			TimeJump=0;
			rb.AddForce(Vector3.up * ForceJump, ForceMode2D.Impulse);
		}

	}

	#endregion


	#region COLISIONES

	public void OnCollisionEnter2D (Collision2D info)
	{

		#region Vidas
		if (info.gameObject.layer == Villanos|| info.gameObject.layer == Caida||info.gameObject.layer==Pinches)
		{
			vidas--;
			transform.position = nuevaPosicion;
			//ContadorDeVidas.text=Convert.ToString(vidas);
			if (vidas == 0)
			{
					SceneManager.LoadScene ("GAME OVER");
			}
		}

		#endregion

		#region PUNTOS
		if (info.gameObject.layer == 11) 
		{
			score++;
			print ("Puntos= "+ score);
		}

		#endregion
	}

	#region PUERTA
	public void OnTriggerEnter2D(Collider2D info)
	{

		if (info.gameObject.layer == 13)
		{
			ColisionDoor = true;
		}
	}

	public void OnTriggerExit2D (Collider2D info)
	{
		if (info.gameObject.layer == 13) 
		{
			ColisionDoor = false;

		} 

	}
	#endregion

	#endregion


}


