using UnityEngine;
using System.Collections;

public class moveyuka : MonoBehaviour {
	public int i = -50;
	// Use this for initialization
	void Start () {
		int i = -50;
	}

	// Update is called once per frame
	void Update () {

		i+=1;
		if (i > 0 && i < 50) {

			this.transform.Translate (0.01f, 0, 0);

		} 
		if (i == 50) {
			i = -50;
		}
		if (i < 0 && i > -50){
			this.transform.Translate (-0.01f, 0, 0);
		}



	}
}

