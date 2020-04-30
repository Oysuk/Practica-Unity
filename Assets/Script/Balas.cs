using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Balas : MonoBehaviour 
{

	public float speed;
	public float lifeTime;
	public int direccion = 1;
	// Use this for initialization
	public Vector3 PosicionActual;

	public GameObject target;
	public int Daño;

	void Start ()
	{
		Destroy(this.gameObject, lifeTime);

	}

	// Update is called once per frame
	void Update () 
	{
		
		transform.position += transform.right * speed * Time.deltaTime* direccion;

	}

	public void OnTriggerEnter2D(Collider2D info)
	{
		if (info.gameObject.layer == 9|| info.gameObject.layer==12)
		{
			PosicionActual = transform.position;
			Destroy (this.gameObject);

		}
	}


	/*public void OnCollisionEnter2D (Collision2D info)
	{
		print ("paso por aca"+info.gameObject.layer);
		if (info.gameObject.layer == 9)
		{
			Destroy (this.gameObject);
			print ("bala choco con enemigo");
		}
	}*/
}

