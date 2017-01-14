using UnityEngine;
using System.Collections;

public class bane : MonoBehaviour {
    SpriteRenderer MainSpriteRenderer;
    public Sprite s1;
    public Sprite s2;
	public AudioSource baneoto;

    
    

	// Use this for initialization
	void Start () {

        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		baneoto = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
  
        

    }
    void OnTriggerStay(Collider other)
    {
		if(other.tag == "Player" )
        {
            ChangeSprites2();
        }
    }

    void OnTriggerExit(Collider other)
    {
		if (other.tag == "Player")
        {
            ChangeSprites1();
			baneoto.PlayOneShot (baneoto.clip);
        }
    }

    void ChangeSprites1()
    {
       MainSpriteRenderer.sprite = s1;
    }
    void ChangeSprites2()
    {
        MainSpriteRenderer.sprite = s2;
    }

}
