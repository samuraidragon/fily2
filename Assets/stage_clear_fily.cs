using UnityEngine;
using System.Collections;

public class stage_clear_fily : MonoBehaviour {
	bool jumpfilyflag;
	// Use this for initialization
	void Start () {
		jumpfilyflag = false;	
	}
	
	// Update is called once per frame
	void Update () {
		if(jumpfilyflag == false){
		StartCoroutine (jumpfily ());
		}
	}
	IEnumerator jumpfily(){
		jumpfilyflag = true;
		//fily.transform.Translate (new Vector3 (0,0,0));
		/*xxxxxxxxx:GetComponent<Rigidbody> ().velocity = new Vector3 (0, 5, 0);
		yield return new WaitForSeconds(0.5f);
		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 5, 0);
		yield return new WaitForSeconds(1f);
		yield return new WaitForSeconds(0.5f); //処理を止める（）の中に止める秒数
		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 8, 0);
*/
		//fily.transform.Translate (new Vector3 (0,0,0));

		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 7, 0);
		yield return new WaitForSeconds(0.5f);
		yield return new WaitForSeconds(1f); //処理を止める（）の中に止める秒数
		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 7, 0);
		yield return new WaitForSeconds(0.5f);
		yield return new WaitForSeconds(1f); //処理を止める（）の中に止める秒数
		for(int i = 0;i < 100 ; i++ ){
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 4.5f, 0);
			yield return new WaitForSeconds(0.5f);
			yield return new WaitForSeconds(1f); //処理を止める（）の中に止める秒数
		}

	}

}
