using UnityEngine;
using System.Collections;

public class moveyuka_sayuu : MonoBehaviour {

	// Use this for initialization
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

			this.transform.Translate (speed * Time.deltaTime,0, 0);

		} 
		if (time >= interval) {
			time = -interval;
		}
		if (time < 0.0f && time > -interval) {
			this.transform.Translate (-speed * Time.deltaTime,0, 0);
		}
	}
}
