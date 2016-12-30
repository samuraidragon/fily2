using UnityEngine;
using System.Collections;

public class sponer : MonoBehaviour {

	public Transform fily;
	// Use this for initialization
	void Start () {
		StartCoroutine (spn ());
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	IEnumerator spn(){

		for (int i = 0; i <= 50; i++) {
			yield return new WaitForSeconds(0.5f);

			Instantiate (fily);

		}



	}
}
