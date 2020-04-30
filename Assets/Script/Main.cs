using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour 
{
	public GameObject Villano;
	public GameObject Almas;
	public GameObject FirstHeroe;
	Heroe scriptA;
	Villanos ScriptVilanos;
	public float Unidades;
	public SpriteRenderer sp;

	#region VIDAS

	public GameObject Vidas;
	public GameObject Vida1;
	public GameObject Vida2;
	public GameObject Vida3;

	#endregion

	public GameObject HeroeDown;
	public GameObject Boss;
	#region ARRAYS

	public GameObject[] Malos=new GameObject[3];
	public Vector3[] PosicionM = new Vector3[3];
	public SpriteRenderer[] Xpositivo = new SpriteRenderer[3]; 

	public GameObject[] Almas1= new GameObject[4];
	public Vector3[] PosicionA = new Vector3[4];

	//movimiento Villanos
	public bool[] Llegada= new bool[3];
	public Vector3[] PosicionFinal = new Vector3[3];
	public Vector3[] PosicionInicial = new Vector3[3];
	public Vector3[] PosicionActual = new Vector3[3];
	public int VelocidadVillanos;

	#endregion

	#region SEGUIR HEROE

	public Transform Heroe;
	public float separaciony=0f;
	public float separacion = 6f;
	public Vector3 PosicionHeroe;
	#endregion

	//public Transform Vidas2;

	#region VARIABLE TEXTOS

	public Text textTime;
	public float timeLeft;
	public Text GameOver;
	public Text VIDAS;
	public Vector3 posicion;
	public Text Puntuacion;
	public Text NotEnd;
	Balas ScriptBalas;
	public Text DañoRecibido;

	#endregion

	public string LevelName;

	// Use this for initialization
	void Start () 
	{
		
//		FirstHeroe= Instantiate(Heroe);
		sp = GetComponent<SpriteRenderer>();
	

		#region ARRAY VILLANOS
		for (int i=0;i<Malos.Length;i++) 
		{
			 Malos[i]= Instantiate(Villano);


			Malos[i].transform.position =PosicionM[i];

			Llegada[i]=false;


			//Xpositivo[i]=GetComponent<Spr>();

			//Xpositivo[i].flipX=false;

		}

		#endregion

		//llama a otro script
		scriptA = GameObject.Find("Heroe").GetComponent<Heroe>();

		ScriptVilanos = GameObject.Find ("Villano").GetComponent<Villanos>();

		#region ARRAY ALMAS
		for (int a=0;a<Almas1.Length;a++) 
		{

			Almas1[a]= Instantiate(Almas);


			Almas1[a].transform.position =PosicionA[a];


		}

		#endregion



	}
	
	// Update is called once per frame
	void Update ()
	{


		//Heroe.position = scriptA.PosicionActual;
		//Heroe.transform.position = FirstHeroe.transform.position;
		//Actualiza la posicion del Personaje
		transform.position = new Vector3 (Heroe.position.x + separacion, Heroe.transform.position.y + 1f, transform.position.z);
		//En que Escena se encuentra
		LevelName = Application.loadedLevelName;
		PosicionHeroe = scriptA.transform.position;
		//ScriptBalas= GameObject.Find("Bala").GetComponent<Balas> ();
		#region MOVIMIENTO DE ENEMIGOS

		for (int i = 0; i < Malos.Length; i++) 
		{
			if(Malos[i]!= null)
			{
			print ("MALOS"+ Malos.Length);
			PosicionActual [i] = Malos [i].transform.position;
			Unidades = Random.Range (1, 5);


			if (Llegada [i] == false) 
			{

				Malos [i].transform.position += Malos [i].transform.right * VelocidadVillanos * Time.deltaTime;



				if (PosicionActual [i].x >= PosicionFinal [i].x) 
				{
					
					Llegada [i] = true;


				}

			} else
			{
				Malos [i].transform.position -= Malos [i].transform.right * VelocidadVillanos * Time.deltaTime;


				if (PosicionActual [i].x <= PosicionInicial [i].x)
				{
					Llegada [i] = false;
					ScriptVilanos.test = false;
				}
			}
			}
		}

			


		#endregion
		print ("flag"+ scriptA.vidas);
		#region VIDAS
		if (scriptA.vidas == 2) 
		{
			print ("flag"+ scriptA.vidas);
			Destroy (Vida3);
		}

		if (scriptA.vidas == 1)
		{
			Destroy (Vida2);
		}

		if (scriptA.vidas == 0) 
		{
			Destroy (Vida1);
		}
		#endregion

		#region TEXTOS

		#region TIEMPO
		timeLeft -= Time.deltaTime;

		textTime.text = "time: " + (int)timeLeft;

		if (timeLeft <= 0) {
//			GameOver.text=("Game Over");
			textTime.text = ("time:0");
		}

		#endregion

		#region AUN NO HAY FINAL

		if (LevelName == "GAME1") {
			if (scriptA.score < 5 && scriptA.ColisionDoor == true) {
				NotEnd.text = "Se necesitan 5 almas para poder avazar, en este momento tienes:" + scriptA.score;

			} else {
				NotEnd.text = "   ";	
			}
		}
		#endregion

		#region Puntos TEXT

		Puntuacion.text = "Score: " + (int)scriptA.score;
		#endregion



		#endregion

		#region CAMBIAR ESCENA
		if (scriptA.score == 5 && scriptA.ColisionDoor == true) 
		{
			SceneManager.LoadScene ("Nivel2");
		}

		#endregion


		if (ScriptVilanos.Prueba == true) 
		{
			print ("auch");
			DañoRecibido.text = "¡" + (int)ScriptVilanos.Daño + "!";
			DañoRecibido.color = Color.red;
			//DañoRecibido.rectTransform.localPosition=ScriptBalas.PosicionActual;


		}

		if (LevelName == "Nivel2") 
		{
			/* Unidades= Random.Range (1f, 5f);

			for (int i = 0; i < Unidades; i++) 
			{
				Boss.transform.position=
			}
			*/
		}
	}
	
	void LoadScene()
	{
		SceneManager.LoadScene("GAME1");
	}


}
