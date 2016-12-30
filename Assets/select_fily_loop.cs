using UnityEngine;
using System.Collections;

public class select_fily_loop : MonoBehaviour {

	public Transform sponer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.transform.position = new Vector3(sponer.position.x,sponer.position.y,0.0f);
			Debug.Log ("hit");
		}
	}
}
