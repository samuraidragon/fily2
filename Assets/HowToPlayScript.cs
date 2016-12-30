using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HowToPlayScript : MonoBehaviour {
	public GameObject[] UI;
	public GameObject next;
	public GameObject back;
	public AudioSource mekuri;
	int Count;
	int maxcount;

	// Use this for initialization
	void Start () {
		Count = 0;
		maxcount = UI.Length - 1;
		Debug.Log (maxcount);

		UI[Count].gameObject.SetActive (true);
		for(int i = 0; i < Count; i++ ){
			UI[i].gameObject.SetActive (false);
		}
		for (int p = Count + 1; Count < p && p < UI.Length; p++) {
			UI[p].gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Count == 0) {
			back.gameObject.SetActive (false);
		} else {
			back.gameObject.SetActive (true);
		}
		if (Count == maxcount ) {
			next.gameObject.SetActive (false);
		} else {
			next.gameObject.SetActive (true);
		}
	
	}
	public void OnNextClick() {
		Count += 1;
		mekuri.PlayOneShot (mekuri.clip);
		UI[Count].gameObject.SetActive (true);
		for(int i = 0; i < Count; i++ ){
			UI[i].gameObject.SetActive (false);
		}
		for (int p = Count + 1; Count < p && p < UI.Length; p++) {
			UI[p].gameObject.SetActive (false);
		}
		
	}
	public void OnBackClick() {
		Count -= 1;
		mekuri.PlayOneShot (mekuri.clip);
		UI[Count].gameObject.SetActive (true);
		for(int i = 0; i < Count; i++ ){
			UI[i].gameObject.SetActive (false);
		}
		for (int p = Count + 1; Count < p && p < UI.Length; p++) {
			UI[p].gameObject.SetActive (false);
		}

	}
}
