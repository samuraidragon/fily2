using UnityEngine;
using System.Collections;

public class goal_camerascript : MonoBehaviour {
	public clear c;
	int gf;
	Transform f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gf = c.goalflag;
		f = c.fily;
		if (gf == 3) {
			Debug.Log ("camera");
				
		}
		
	
	}
}
