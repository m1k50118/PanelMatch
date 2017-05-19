using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (ResetPanel ());
	}
	
	IEnumerator ResetPanel(){
		yield return new WaitForSeconds (2f);
		Debug.Log ("2病後");
	}
}
