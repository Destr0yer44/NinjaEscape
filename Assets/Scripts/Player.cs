using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
public float velocitat=2.0f;
public bool andar = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	void Update () {
			
			andar = false;
			if(Input.GetKey(KeyCode.A)) {
			andar = true;
			//transform.Rotate (0f,180, 0f);
			transform.rotation = new Quaternion(0,180,0,0);
			//transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * velocitat);
			transform.position = new Vector3(transform.position.x + (-1*velocitat * Time.deltaTime), transform.position.y, transform.position.z);
			}
			if(Input.GetKey(KeyCode.D)) {
			andar = true;
				transform.rotation = new Quaternion(0,0,0,0);
				transform.position = new Vector3(transform.position.x + (1*velocitat * Time.deltaTime), transform.position.y, transform.position.z);
				//transform.Translate(new Vector3( -1, 0, 0) * Time.deltaTime * velocitat);
			}
	}
}
