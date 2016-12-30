using UnityEngine;
using System.Collections;

public class surinuke_floor : MonoBehaviour {
	public Collider col;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
			col.isTrigger = true;

		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			col.isTrigger = false;
		}
	}
}
