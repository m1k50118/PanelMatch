﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currect2 : MonoBehaviour {
	[SerializeField] public int Xcurrect;
	[SerializeField] public int Ycurrect;
	public Image currectimage;
	[SerializeField] GameObject panelcon;
	PanelController2 currectcolor;

	void Reset(){
		currectimage = GetComponent<Image> ();
	}

	void Start(){
		panelcon = GameObject.FindGameObjectWithTag ("PCon");
		currectcolor = panelcon.GetComponent<PanelController2> ();
		currectcolor.InitCurrectFlag ();
		currectcolor.SetCurrectFlag ();
	}
}