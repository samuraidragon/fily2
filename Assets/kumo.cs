using UnityEngine;
using System.Collections;

public class kumo : MonoBehaviour {
	public Transform ito;
	public Transform bottom;
	string bottomname;
	public Transform limit;
	string limitname;
	public float speed;
	bool movefalg;
	public string nextscene;

	GameObject fily;
	Animator anim;
	bool once;

	public AudioSource gameoveroto;
	// Use this for initialization
	void Start () {
		movefalg = false;
		bottomname = bottom.name;
		limitname = limit.name;
		once = false;
		fily = GameObject.FindWithTag ("Player");
		anim = fily.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if(movefalg == true){
			transform.Translate (Vector3.up * Time.deltaTime * -1 * speed);
			ito.transform.localScale += Vector3.up * Time.deltaTime * 1 * speed / 2;
		}else{
			transform.Translate (Vector3.up * Time.deltaTime * speed);
			ito.transform.localScale += Vector3.up * Time.deltaTime * -1 * speed / 2;
		}
		

	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && once == false) {
			StartCoroutine(gameover());
		}
		if (other.name == limitname) {
			movefalg = true;
			Debug.Log (limit);
		}
		if (other.name == bottomname) {
			movefalg = false;
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
