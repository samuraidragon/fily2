using UnityEngine;
using System.Collections;

public class toge_migi : MonoBehaviour {
	double time;
	public float speed;
	public float interval;

	// Use this for initialization
	void Start () {
		time = -interval;
	}

	// Update is called once per frame
	void Update () {
		time += 1 * Time.deltaTime;
		if (time > 0.0f && time < interval) {

			this.transform.Translate (speed * Time.deltaTime,0,0);

		} 
		if (time >= interval) {
			time = -interval;
		}
		if (time < 0.0f && time > -interval) {
			this.transform.Translate (-speed * Time.deltaTime,0, 0);
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.name == "chara") {
			Application.LoadLevel ("GameOver");
		}

	}
}
