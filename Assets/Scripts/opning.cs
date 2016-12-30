using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class opning : MonoBehaviour {
	public string nextlevel;
	public AudioSource se;
	public Transform loadingfile;
	public Image[] text;

	// Use this for initialization
	void Start () {
		loadingfile.gameObject.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			StartCoroutine(LoadScene());
		}
	}

	IEnumerator LoadScene(){
		se.PlayOneShot (se.clip);
		AsyncOperation async = Application.LoadLevelAsync(nextlevel);
		async.allowSceneActivation = false;    // シーン遷移をしない

		while (async.progress < 0.9f) {
			
			loadingfile.gameObject.SetActive(true);
			yield return new WaitForEndOfFrame();
			for(int i = 0; i < text.Length; i++){
				text [i].GetComponent<Rigidbody> ().velocity = Vector3.up * 3;
				if (async.progress > 0.8)break;
				yield return new WaitForSeconds(0.2f);
			}

		}
		yield return new WaitForSeconds(1);
		async.allowSceneActivation = true;    // シーン遷移許可

	}
}
