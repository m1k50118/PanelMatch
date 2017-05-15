using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class IntUnityEvent:UnityEvent<int>{
	
}

public class PanelController : MonoBehaviour {
	//touchされた時のイベント
	private IntUnityEvent onClickPanelEvent = new IntUnityEvent ();
	public IntUnityEvent OnClickPanelEvent {
		get{ return onClickPanelEvent;}
	}

	int n;
	public int num;
	public GameObject obj;
	public Transform canvas;
	List<Panel> panels =new List<Panel>();
	public Color color;

	[SerializeField] 
	private Image image;

	void Start(){
		CreatePanel (num);
	}

	void CreatePanel(int num){
		for (int v = 0; v < num; v++) {
			for (int h = 0; h < num; h++) {
				var newobj = Instantiate (obj, this.transform) as GameObject;
				newobj.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-110f+h*110 , -150f+v*110);
				var panel = newobj.GetComponent<Panel> ();
				panels.Add (panel);
				n += 1;
				panel.id += n;
			}
		}
	}

	void Initialize(UnityAction<int>){
	
	}

	void DoClickPanelEvent(int id){
		onClickPanelEvent.Invoke (id);
	}

	public void OnClick(){
		ChangeColor ();
	}

	void ChangeColor(){
		if (image.color != Color.red) {
			image.color = Color.red;
		} else
			image.color = Color.blue;
	}
}
