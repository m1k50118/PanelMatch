using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currect5 : MonoBehaviour {
	[SerializeField] public int Xcurrect;
	[SerializeField] public int Ycurrect;
	public Image currectimage;
	[SerializeField] GameObject panelcon;
	PanelController5 currectcolor;

	void Reset(){
		currectimage = GetComponent<Image> ();
	}

	void Start(){
		panelcon = GameObject.FindGameObjectWithTag ("PCon");
		currectcolor = panelcon.GetComponent<PanelController5> ();
		currectcolor.InitCurrectFlag ();
		currectcolor.SetCurrectFlag ();
	}
}
