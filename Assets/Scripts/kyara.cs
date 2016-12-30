
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class kyara : MonoBehaviour {
	bool once;
	int mabatakiflag;
	bool goal;
	int hanntoumeiflag;
	public int touchCount = 0;
	GameObject obj;
	GameObject obj2;
	GameObject black;
	GameObject kurayami;
	public float kaihukudennryoku;
	public int[] flag;
	float time;
	float timecount;
	public Transform dennryoku;
	public GameObject[] dennkidama;
	public AudioSource asioto;
	public AudioSource BGM;
	public AudioSource dennryokukaihuku;
	public Animator anim;
	public AudioSource rakka;
	public AudioSource change;
	public AudioSource gameoveroto;
	public string GameOver;
	public float maxdennryoku;
	public float syouhidennryoku = 0.5f;

	// Use this for initialization
	void Start () {
		once = false;
		BGM.pitch = 1f;
		goal = false;
		hanntoumeiflag = 0;
	    obj = GameObject.Find ("cover");
		obj2 = GameObject.Find ("cover2");
		black = GameObject.Find ("BlackLight");
		kurayami = GameObject.Find ("kurayami");
		obj2.gameObject.SetActive (false);
		time = 0.0f;
		asioto = GetComponent<AudioSource> ();
		anim.SetBool ("gameover", false);
	
	}

	// Update is called once per frame
	void Update () {
		
		if(mabatakiflag == 2){
			anim.SetInteger ("mabataki",2);
		}
		if(mabatakiflag == 1){
			anim.SetInteger ("mabataki",1);
		}
		if(mabatakiflag == 0){
			anim.SetInteger ("mabataki",0);
		}

        timecount = time % 2;
		time += 1 * Time.deltaTime;
		if (time > 2) {
			time = 0;

		}

		for (int i = 0; i <= flag.Length ; i+=2) {
			if (flag [i/2] == 0) {
				dennkidama [i].gameObject.SetActive (false);
				dennkidama [i + 1].gameObject.SetActive (false);
			}
			if (flag [i/2] == 1) {
				dennkidama [i].gameObject.SetActive (true);
				dennkidama [i + 1].gameObject.SetActive (true);
			}
			if (flag [i/2] == 3) {
				dennkidama [i].gameObject.SetActive (false);
				dennkidama [i + 1].gameObject.SetActive (false);
			}
		}

		if (maxdennryoku <= 0f && once == false){
			StartCoroutine (gameover ());
		}
		if (Input.GetMouseButtonDown(0)) {
			change.PlayOneShot (change.clip);
			touchCount += 1;

		}
		dennryoku.transform.localScale = new Vector3 (maxdennryoku, 1, 1);
		if (touchCount % 2 == 0) {
			GetComponent<SpriteRenderer> ().sortingOrder = 2;
			mabatakiflag = 2;
			BGM.pitch = 1f;
			obj.gameObject.SetActive (false);
			black.gameObject.SetActive (false);
			if (hanntoumeiflag == 1) {
				StartCoroutine (hanntoumei ());
				hanntoumeiflag = 0;
			}


			if (flag[0] == 1) {
				flag[0] = 0;
			}
			if (flag[1] == 1) {
				flag[1] = 0;
			}
			if(maxdennryoku > 0){	
			maxdennryoku -= syouhidennryoku * Time.deltaTime;

				//maxdennryoku = 0;
			}
			//dennryoku.transform.localScale = new Vector3 (maxdennryoku, 0.7f, 0.7f);
			//dennryoku.transform.position -= new Vector3 (syouhidennryoku * 3.2f * Time.deltaTime, 0, 0);
			if (goal == false) {
				moveleft ();
			}


        } else{
			BGM.pitch = 0.8f;
			obj.gameObject.SetActive (true);
			black.gameObject.SetActive (true);
			kurayami.gameObject.SetActive (true);


			if(mabatakiflag == 2){
				mabatakiflag = 1;
				if (touchCount % 2 == 0) {
					GetComponent<SpriteRenderer> ().sortingOrder = 2;
					mabatakiflag = 2;
				} else {
					GetComponent<SpriteRenderer> ().sortingOrder = 7;
					Invoke ("mabatakistop", 1f);
				}
			}


			hanntoumeiflag = 1;

			if (flag[0] == 0) {
				flag[0] = 1;
			}

			if (flag[1] == 0) {
				flag[1] = 1;
			}
		
			if (goal == false) {
				moveright ();
			}
			


        }
	}
	//バネの挙動
	void OnTriggerEnter(Collider other){
		if (other.name == "goal") {
			anim.SetBool ("yorokobiani", true);
			goal = true;

		}
		if (other.tag == "bane") {
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 6, 0);
		}
		if (other.gameObject == dennkidama [0]) {
			flag [0] = 3;

			maxdennryoku += kaihukudennryoku;

			dennryokukaihuku.PlayOneShot (dennryokukaihuku.clip);
			if (maxdennryoku > 1f) {
				maxdennryoku = 1f;

			}

		}
		if (other.gameObject == dennkidama [2]) {
			flag [1] = 3;

			maxdennryoku += kaihukudennryoku;

			dennryokukaihuku.PlayOneShot (dennryokukaihuku.clip);
			if (maxdennryoku > 1f) {
				maxdennryoku = 1f;

			}

		}
			

	}
	void OnCollisionEnter(Collision other){
		
		if (other.gameObject.tag == "floor") {
			rakka.PlayOneShot (rakka.clip);

		}
	}


			
		
	void mabatakistop (){
		GetComponent<SpriteRenderer> ().sortingOrder = 2;
		mabatakiflag = 0;

	}

	IEnumerator mabatakistop2(){
		GetComponent<SpriteRenderer> ().sortingOrder = 2;
		mabatakiflag = 2;
		yield return new WaitForSeconds(0.01f);
		mabatakiflag = 0;

	}


    void moveleft(){
		
        if (timecount >= 0.0f && timecount  < 1.0f)
         
            {
			anim.SetInteger ("wark", 1);
			this.transform.Translate(-0.1f * Time.deltaTime, 0.0f, 0.0f);

        }
        else {
			anim.SetInteger ("wark", 0);
			this.transform.Translate(-1.0f * Time.deltaTime, 0.0f, 0.0f);
        }

    }
    void moveright(){
		
        if (timecount >= 0.0f && timecount < 1.0f)
            
            {
			anim.SetInteger ("wark", 1);
			this.transform.Translate(0.1f * Time.deltaTime, 0.0f, 0.0f);
       }
        else {
			anim.SetInteger ("wark", 0);
			this.transform.Translate(1.0f * Time.deltaTime, 0.0f, 0.0f);
       }

    }

	IEnumerator hanntoumei(){
		obj2.gameObject.SetActive (true);
		yield return new WaitForSeconds(0.05f);
		obj2.gameObject.SetActive (false);
		obj.gameObject.SetActive (false);
		yield return new WaitForSeconds(0.05f);
		obj2.gameObject.SetActive (true);
		yield return new WaitForSeconds(0.05f);
		yield return new WaitForSeconds(0.1f); //処理を止める（）の中に止める秒数

		obj2.gameObject.SetActive (false);
	}
	IEnumerator gameover(){
		once = true;
		AsyncOperation async = Application.LoadLevelAsync(GameOver);
		async.allowSceneActivation = false;    // シーン遷移をしない
		GetComponent<Rigidbody> ().velocity = Vector3.up * 6;
		anim.SetBool ("gameover", true);
		GetComponent<SphereCollider>().enabled = false;
		GetComponent<SpriteRenderer> ().sortingOrder = 10;
		gameoveroto.PlayOneShot (gameoveroto.clip);
		yield return new WaitForSeconds(4);
		async.allowSceneActivation = true;    // シーン遷移許可

	}

}
