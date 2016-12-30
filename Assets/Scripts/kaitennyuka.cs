using UnityEngine;
using System.Collections;

public class kaitennyuka : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0.0f,0.0f,25.0f * Time.deltaTime);
	
	}
}
