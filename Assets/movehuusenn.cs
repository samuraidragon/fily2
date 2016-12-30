using UnityEngine;
using System.Collections;

public class movehuusenn : MonoBehaviour {
	public Transform stoppos;
	public Transform stoppos2;
	public Transform destroyr;
	public Transform destroyed;
	string pos;
	string pos2;
	string des;
	int stopflag;

	public float speed;
	// Use this for initialization
	void Start () {
		stopflag = 0;
		pos = stoppos.name;
		pos2 = stoppos2.name;
		des = destroyr.name;
		//StartCoroutine (change ());
	}
	
	// Update is called once per frame
	void Update () {
		
		if(stopflag == 0){
			
			//transform.position = new Vector3(transform.position.x, transform.position.y + speed,transform.position.z);
			//transform.Translate(Vector3.up * speed * 60 * Time.deltaTime);
			GetComponent<Rigidbody>().AddForce(Vector3.up * speed * 10 * Time.deltaTime);

		}
		if(stopflag == 1){
			//transform.position = new Vector3(transform.position.x, transform.position.y - speed/5f,transform.position.z);
			//transform.Translate(Vector3.up * speed * 60 /5 * -1 * Time.deltaTime);
			GetComponent<Rigidbody>().AddForce(Vector3.up * speed * 15 * -1 *  Time.deltaTime / 5);
		}
		if(stopflag == 2){
			//transform.position = new Vector3(transform.position.x, transform.position.y + speed/5f,transform.position.z);
			GetComponent<Rigidbody>().AddForce(Vector3.up * speed * 15 *  Time.deltaTime / 5);
		}
	}
	void OnTriggerEnter(Collider other){
		
		if (other.name == pos && stopflag == 0) {
			
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			//GetComponent<Rigidbody>().AddForce(Vector3.up * -speed * 3000 * Time.deltaTime);
			stopflag = 1;

		}
		if (other.name == pos && stopflag == 2) {
			
			//GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().AddForce(Vector3.up * -speed * 220 * Time.deltaTime);
			stopflag = 1;

		}
		if (other.name == pos2 && stopflag == 1) {
			//GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().AddForce(Vector3.up * speed * 220 * Time.deltaTime);
			stopflag = 2;
		}
		if (other.name == des) {
			Destroy (destroyed.gameObject);
		}
	}

}
