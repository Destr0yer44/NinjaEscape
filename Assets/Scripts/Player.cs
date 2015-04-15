using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D rigidBodyp;
	public float velocidad=2.0f;
	private int cont = 0;
	private bool andar = false;
	public bool saltar = false;
	public int jumpcount = 0;
	public bool puedosalt = true;
	public Transform startPos;
	public Transform endPos;
	public LayerMask groundLayer;

	private bool isGrounded;
	private Animator _anim;


	// Use this for initialization
	void Start () {
		_anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame

	void Update () {
		//isGrounded = true;
		andar = false;
		saltar = false;
		movimiento ();
		salto ();
		Debug.DrawLine (startPos.position, endPos.position, Color.red);
	}


	void movimiento(){

		/*float movimiento = Input.GetAxisRaw ("Horizontal");
		rigidBodyp.velocity = new Vector2 (movimiento * velocidad, rigidBodyp.velocity.y);*/

		if(Input.GetKey(KeyCode.A)) {
			andar = true;
			//transform.Rotate (0f,180, 0f);
			transform.rotation = new Quaternion(0,180,0,0);
			//transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * velocitat);
			transform.position = new Vector3(transform.position.x + (-1*velocidad * Time.deltaTime), transform.position.y, transform.position.z);
		}
		else if(Input.GetKey(KeyCode.D)) {
			andar = true;
			transform.rotation = new Quaternion(0,0,0,0);
			transform.position = new Vector3(transform.position.x + (1*velocidad * Time.deltaTime), transform.position.y, transform.position.z);
			//transform.Translate(new Vector3( -1, 0, 0) * Time.deltaTime * velocitat);
		}
		//if(isGrounded)
			_anim.SetBool ("andar", andar);
	}


	void salto(){

		RaycastHit2D hit = Physics2D.Linecast (startPos.position, endPos.position, groundLayer.value);

		Debug.Log (puedosalt);

		if (hit.collider != null) {
			_anim.SetBool ("saltar", false);
			puedosalt = true;
				}
	
	
		if (Input.GetKeyDown (KeyCode.Space) && puedosalt == true) {
				saltar = true;
				rigidbody2D.AddForce(Vector3.up * 22 /** Time.deltaTime*/, ForceMode2D.Impulse);
				//isGrounded = false;
				puedosalt = false;
		
		}
		//while (!isGrounded)
			//saltar = true;
		//}
		_anim.SetBool ("saltar", saltar);
		
	}
	/*void OnColliderStay2D(Collider2D collisionInfo)
	{
		Debug.Log ("collision");
		isGrounded = true;
	}*/
  }

