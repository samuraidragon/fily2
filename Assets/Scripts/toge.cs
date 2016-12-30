using UnityEngine;
using System.Collections;

public class toge : MonoBehaviour {
	public string nextscene;
	GameObject fily;
	Animator anim;
	bool once;
	public AudioSource togeoto;
	public AudioSource gameoveroto;
	// Use this for initialization
	void Start () {
		once = false;
		fily = GameObject.FindWithTag ("Player");
		anim = fily.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && once == false) {
			togeoto.PlayOneShot (togeoto.clip);
			StartCoroutine(gameover());

		}
		
	}

	IEnumerator gameover(){
		once = true;
		AsyncOperation async = Application.LoadLevelAsync(nextscene);
		async.allowSceneActivation = false;    // シーン遷移をしない
		fily.GetComponent<Rigidbody> ().velocity = Vector3.up * 6;
		anim.SetBool ("gameover", true);
		fily.GetComponent<SphereCollider>().enabled = false;
		fily.GetComponent<SpriteRenderer> ().sortingOrder = 10;
		gameoveroto.PlayOneShot (gameoveroto.clip);
		//AudioSource audioSource = GetComponent<AudioSource>();
		//audioSource.Play();
		yield return new WaitForSeconds(4);
		async.allowSceneActivation = true;    // シーン遷移許可

	}

}
