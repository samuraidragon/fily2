using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class stageUI : MonoBehaviour {
	float alfa;
	float hennka;
	public Image i;
	// Use this for initialization
	void Start () {
		alfa = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//i.color.a += alfa;
		if (alfa > 200) {
			alfa *= -1;
		}
	
	}
}
