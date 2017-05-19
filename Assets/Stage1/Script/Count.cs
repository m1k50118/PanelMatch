using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour {
	
	public int Max;
	public	int maxcount;
	Text text;

	void Start(){
		text = GetComponent<Text> ();
		text.text = "あと" + Max.ToString() + "回";
		maxcount = Max;
	}

	public void Decrese(){
		Max = Max-1;
		text.text = "あと" + Max + "回";
	}

	public void ResetCount(){
		StartCoroutine (ResetCorutine ());
	}

	IEnumerator ResetCorutine(){
		yield return new WaitForSeconds (1.5f);
		Max = maxcount;
		text.text = "あと" + Max + "回";
	}
}
