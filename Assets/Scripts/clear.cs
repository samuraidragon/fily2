using UnityEngine;
using System.Collections;

public class clear : MonoBehaviour {
	public Transform fily;
	public Transform effect;
	public int goalflag;
	public string nextscene;

	// Use this for initialization
	void Start () {
		
		goalflag = 0;
		effect.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		
		
	}
	void OnTriggerEnter(Collider other){
		
		if (other.tag == "Player" && goalflag == 0) {
			goalflag = 1;

		}
		if (goalflag == 1) {
			goalflag = 3;
			effect.gameObject.SetActive (true);
			StartCoroutine(LoadStage());
		}
	}
	IEnumerator LoadStage(){
		
		fily.transform.Translate (new Vector3 (0,0,0));
		AudioSource audioSource = GetComponent<AudioSource>();
		audioSource.Play();
		fily.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 5, 0);
		yield return new WaitForSeconds(1f);
		fily.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 5, 0);
		yield return new WaitForSeconds(1f);
		yield return new WaitForSeconds(0.5f); //処理を止める（）の中に止める秒数
		Application.LoadLevel(nextscene);
	}

}
