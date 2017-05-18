using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class Panel : MonoBehaviour {

	public int id;
	[SerializeField] public int X;
	[SerializeField] public int Y;

	[SerializeField] public Button button;
	[SerializeField] public  Image image;

	[SerializeField] GameObject panelcon;
	PanelController FlagChange;

	void Start(){
		panelcon = GameObject.FindGameObjectWithTag ("PCon");
		FlagChange = panelcon.GetComponent<PanelController> ();
		FlagChange.InitFlag ();
		FlagChange.SetPanelFlag ();
	}

	void Reset(){
		button = GetComponent<Button> ();
		image = GetComponent<Image> ();
	}

	public void OnClick(){
		FlagChange.PutFlag (this.X, this.Y);
		FlagChange.FlagCom ();
	}
}
