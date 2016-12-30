using UnityEngine;
using System.Collections;

public class kyaraokimono : MonoBehaviour {
	



		int mabatakiflag;

		
		public int touchCount = 0;
		

		float time;
		float timecount;
		
		public Animator anim;
		

		

		// Use this for initialization
		void Start () {
			time = 0.0f;
		}

		// Update is called once per frame
		void Update () {
			Debug.Log (mabatakiflag);
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

			
			moveleft ();
				
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
			/*if (timecount >= 1.0f && timecount <1.017f) {
			asioto.PlayOneShot (asioto.clip);
			
		}*/

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
		
		

	}
