using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController3 : MonoBehaviour {

	int n;
	public int num;
	private int[,] flag;
	private int[,] currectflag;
	public GameObject objPref;
	public GameObject currectPref;
	public GameObject clear;
	public Transform canvas;
	List<Panel3> panels =new List<Panel3>();
	List<Currect3> currects = new List<Currect3> ();

	void Start(){
		CreatePanel (num);
		CreateCurrect (num);
	}

	void CreatePanel(int num){
		for (int v = 0; v < num; v++) {
			for (int h = 0; h < num; h++) {
				var newobj = Instantiate (objPref, this.transform) as GameObject;
				newobj.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-110f+h*110 , -150f+v*110);
				var panel = newobj.GetComponent<Panel3> ();
				panel.image.color = Color.red;
				panels.Add (panel);
				n += 1;
				panel.id += n;
				panel.X = h;
				panel.Y = v;
			}
		}
	}

	void CreateCurrect(int num){
		for (int v = 0; v < num; v++) {
			for (int h = 0; h < num; h++) {
				var newcurrect = Instantiate (currectPref, this.transform) as GameObject;
				newcurrect.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-490f + h * 60, 110 + v * 60);
				var currect = newcurrect.GetComponent<Currect3> ();
				currects.Add (currect);
				currect.Xcurrect += h;
				currect.Ycurrect += v;
			}
		}
	}

	public void InitCurrectFlag(){
		currectflag = new int[num, num];
		for (int i = 0; i < num; i++) {
			for (int j = 0; j < num; j++) {
				currectflag [i, j] = 0;
			}
		}
	}

	void CurrectColor(){
		for (int i = 0; i < num; i++) {
			for (int j = 0; j < num; j++) {
				switch (currectflag[i,j]) {
				case 0:
					currects [num * j + i].GetComponent<Currect3> ().currectimage.color = Color.red;
					break;
				case 1:
					currects [num * j + i].GetComponent<Currect3> ().currectimage.color = Color.blue;
					break;
				default:
					currects [num * j + i].GetComponent<Currect3> ().currectimage.color = Color.white;
					break;
				}
			}
		}
	}

	public void InitFlag(){
		flag = new int[num, num];
		for (int i = 0; i < num; i++) {
			for (int j = num; j < num; j++) {
				flag [i, j] = 0;
			}
		}
	}

	public void ResetFlag(){
		StartCoroutine (ResetCoroutine());
	}

	IEnumerator ResetCoroutine(){
		//matu
		yield return new WaitForSeconds(1.5f);
		InitFlag ();
		SetPanelFlag ();
	}

	public void SetPanelFlag(){
		ChangeFlag (0,0);
		ChangeFlag (1,1);
		ChangeFlag (1,2);
		ChangeFlag (1,3);
		ChangeFlag (2,0);
		ChangeFlag (2,1);
		ChangeFlag (2,2);
		ChangeFlag (3,3);
	}

	public void SetCurrectFlag(){
		currectflag = new int[num, num];
		currectflag [0, 1] = 1;
		currectflag [0, 2] = 1;
		currectflag [1, 0] = 1;
		currectflag [1, 3] = 1;
		currectflag [2, 0] = 1;
		currectflag [2, 3] = 1;
		currectflag [3, 1] = 1;
		currectflag [3, 2] = 1;
		CurrectColor ();
	}

	public void PutFlag(int x,int y){
		ChangeFlag (x, y);
		ChangeFlag (x, y+1);
		ChangeFlag (x, y - 1);
		ChangeFlag (x+1, y);
		ChangeFlag (x+1, y+1);
		ChangeFlag (x+1, y-1);
		ChangeFlag (x-1, y);
		ChangeFlag (x-1, y+1);
		ChangeFlag (x-1, y-1);
	}

	public void ChangeFlag(int x,int y){
		if (x >= 0 && x < num && y >= 0 && y < num) {
			flag [x, y] = 1 - flag [x, y];
		}
		ChangeColor ();
	}

	void ChangeColor(){
		for (int i = 0; i < num; i++) {
			for (int j = 0; j < num; j++) {
				switch (flag[i,j]) {
				case 0:
					panels [num * j + i].GetComponent<Panel3> ().image.color = Color.red;
					break;
				case 1:
					panels [num * j + i].GetComponent<Panel3> ().image.color = Color.blue;
					break;
				default:
					break;
				}
			}
		}
	}

	public bool isFlag(){
		for (int i = 0; i < num; i++) {
			for (int j = 0; j < num; j++) {
				if (flag [i, j] != currectflag [i, j]) {
					return false;
				}
			}
		}
		clear.SetActive (true);
		return true;
	}
}
