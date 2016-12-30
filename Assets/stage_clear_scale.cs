using UnityEngine;
using System.Collections;

public class stage_clear_scale : MonoBehaviour {
	bool scaleflag;
	// Use this for initialization
	void Start () {
		//StartCoroutine (scale ());
	}
	
	// Update is called once per frame
	void Update () {
		if (scaleflag == false) {
			StartCoroutine (scale ());
		}
	
	}
	IEnumerator scale(){
			transform.localScale += new Vector3 (0.0015f,0.0015f,0);
		yield return new WaitForSeconds(1.3f);
		    scaleflag = true;
			//transform.localScale -= new Vector3 (0.002f,0.002f,0);
			//yield return new WaitForSeconds(1f);

	}
}
