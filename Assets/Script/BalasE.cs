using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BalasE : MonoBehaviour 
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

}
