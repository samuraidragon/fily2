using UnityEngine;
using System.Collections;

public class sita : MonoBehaviour {
	public string nextscene;
	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {

			StartCoroutine(LoadStage());

		}

	}
	IEnumerator LoadStage(){


		AudioSource audioSource = GetComponent<AudioSource>();
		audioSource.Play();
		yield return new WaitForSeconds(1.0f); //処理を止める（）の中に止める秒数
		Application.LoadLevel(nextscene);
	}

}
