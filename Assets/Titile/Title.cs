using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour {

	void Start(){
		this.GetComponent<Button> ().onClick.AddListener (OnClick);
	}

	void OnClick(){
		SceneManager.LoadScene ("stage1");
	}
}
