using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class Panel : MonoBehaviour {


	private UnityAction<int> onClick;
	public int id;
	public Color color;

	[SerializeField]
	private Button button;

	[SerializeField]
	private  Image image;

	void Reset(){
		button = GetComponent<Button> ();
		image = GetComponent<Image> ();
	}

	public void Initialize(UnityAction<int> action,Color color ){
		onClick = action;
		image.color = color;
		button.onClick.RemoveAllListeners ();
		button.onClick.AddListener (DoClick);
	}

	public void Show(){
		this.gameObject.SetActive (true);
	}

	void DoClick(){
		if(onClick!=null){
			onClick(id);
		}
	}
}
