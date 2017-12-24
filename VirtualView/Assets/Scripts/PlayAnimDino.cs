using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayAnimDino : MonoBehaviour {

	public Animation anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void animIdle(){
		anim.Play ("idle");
	}

	public void animHit(){
		anim.Play ("hit");
	}

}
