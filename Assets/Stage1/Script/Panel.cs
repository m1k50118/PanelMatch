﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class Panel : MonoBehaviour {

	public int id;
	[SerializeField] public int X;
	[SerializeField] public int Y;

	[SerializeField] public Button button;
	[SerializeField] public  Image image;

	[SerializeField] GameObject countcon;
	[SerializeField] GameObject panelcon;
	Count decrese;
	PanelController FlagChange;

	void Start(){
		panelcon = GameObject.FindGameObjectWithTag ("PCon");
		countcon = GameObject.FindGameObjectWithTag ("Count");
		FlagChange = panelcon.GetComponent<PanelController> ();
		FlagChange.InitFlag ();
		FlagChange.SetPanelFlag ();
		decrese = countcon.GetComponent<Count> ();
	}

	void Reset(){
		button = GetComponent<Button> ();
		image = GetComponent<Image> ();
	}

	public void OnClick(){
		FlagChange.PutFlag (this.X, this.Y);
		decrese.Decrese ();
		if (decrese.Max <= 0) {
			FlagChange.isFlag ();
		}
		if (FlagChange.isFlag()) {
			Invoke ("Load", 3.5f);
		} else {
			FlagChange.ResetFlag ();
			decrese.ResetCount ();
		} 
	}

	void Load(){
		SceneManager.LoadScene ("stage2");
	}
}
