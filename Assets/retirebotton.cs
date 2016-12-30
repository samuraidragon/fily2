using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class retirebotton : MonoBehaviour {
	public Transform ui;
	public Transform yes;
	public Transform no;
	bool ritireflag;
	public AudioSource se;
	public Transform loadingfile;
	public Image[] text;
	// Use this for initialization
	void Start () {
		ui.gameObject.SetActive (false);
		yes.gameObject.SetActive (false);
		no.gameObject.SetActive (false);
		ritireflag = false;
		loadingfile.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (ritireflag == true) {
			ui.gameObject.SetActive (true);
			yes.gameObject.SetActive (true);
			no.gameObject.SetActive (true);
		} else {
			ui.gameObject.SetActive (false);
			yes.gameObject.SetActive (false);
			no.gameObject.SetActive (false);
		}
	}

	public void OnRetireClick() {
		se.PlayOneShot (se.clip);
		if (ritireflag == true) {
			ritireflag = false;
		} else {
			ritireflag = true;
		}
			
	}
	public void OnYesClick() {
		StartCoroutine(LoadScene());
	}
	public void OnNoClick() {
		se.PlayOneShot (se.clip);
		ritireflag = false;
	}	
	IEnumerator LoadScene(){
		se.PlayOneShot (se.clip);
		AsyncOperation async = Application.LoadLevelAsync("StageSelect_1_5");
		async.allowSceneActivation = false;    // シーン遷移をしない

		while (async.progress < 0.9f) {
			
			loadingfile.gameObject.SetActive(true);
			yield return new WaitForEndOfFrame();
			for(int i = 0; i < text.Length; i++){
				text [i].GetComponent<Rigidbody> ().velocity = Vector3.up * 3;
				yield return new WaitForSeconds(0.2f);
			}
		}
		yield return new WaitForSeconds(1);
		async.allowSceneActivation = true;    // シーン遷移許可

	}

}
