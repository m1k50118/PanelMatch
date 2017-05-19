using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (ReturnSceneCorutine ());
	}
	
	IEnumerator ReturnSceneCorutine(){
		yield return new WaitForSeconds (3.0f);
		SceneManager.LoadScene ("Title");
	}
}
