using UnityEngine;
using System.Collections;

public class Poli : MonoBehaviour {
	public Transform Inici;
	public Transform Final;
	public bool visto = false;
	public int velocidad;
	public bool Derecha, Izquierda;
	private Animator animator;
	public Sprite alerta;


	// Use this for initialization
	void Start () {
		Derecha = true;
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		RayCast ();
		Andar ();
		Ver ();
	}

	void RayCast()
	{
		Debug.DrawLine (Inici.position, Final.position, Color.white);
		visto = Physics2D.Linecast(Inici.position, Final.position, 1 << LayerMask.NameToLayer("Player"));
	}

	void Andar(){
		if (Derecha) {
			transform.position = new Vector3 (transform.position.x + (1 * velocidad * Time.deltaTime), transform.position.y, transform.position.z);
		}

		else if (!Derecha) {
			transform.position = new Vector3 (transform.position.x + (-1 * velocidad * Time.deltaTime), transform.position.y, transform.position.z);
		}


	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Rebote") {
			if (Derecha)
			{
				Derecha=false;
				transform.rotation = new Quaternion(0, 180, 0 , 0);



			

			}
			else if (!Derecha)
			{
				Derecha=true;
				transform.rotation = new Quaternion(0, 0, 0 , 0);

			}

		}
		if (other.tag == "Shuriken")
		{
			
			animator.SetBool("muerto",true);
			velocidad=0;
			
		}
	}

	void Ver ()
	{

		if (visto) {
		
			animator.SetBool("alerta",true);
			velocidad=0;

		}
	}

}
