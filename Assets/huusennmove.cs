using UnityEngine;
using System.Collections;

public class huusennmove : MonoBehaviour {
	float y_pos;
	// Use this for initialization
	void Start () {
		
		y_pos = 100;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(100, y_pos, 0);

		if (y_pos < 400f) {
			y_pos += 4f;
		}

	}
}
