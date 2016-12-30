using UnityEngine;
using System.Collections;

public class up_down_floor : MonoBehaviour {
	public Transform bottom;
	string bottomname;
	public Transform limit;
	string limitname;
	public float speed;
	bool movefalg;

	// Use this for initialization
	void Start () {
		movefalg = false;
		bottomname = bottom.name;
		limitname = limit.name;
	}

	// Update is called once per frame
	void Update () {
		if(movefalg == true){
			transform.Translate (Vector3.up * Time.deltaTime * -1 * speed);

		}else{
			transform.Translate (Vector3.up * Time.deltaTime * speed);

		}


	}
	void OnTriggerEnter(Collider other){
		if (other.name == limitname) {
			movefalg = true;
			Debug.Log (limit);
		}
		if (other.name == bottomname) {
			movefalg = false;
		}
	}

}
