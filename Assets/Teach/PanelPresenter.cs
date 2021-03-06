﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Teach{
	/// <summary>
	/// パネルを押した時に起こること(モデル)とコントローラーを接続するやつ
	/// </summary>
	public class PanelPresenter : MonoBehaviour {

		public PanelViewController con;

		void Start () {
			con.OnClickPanelEvent.AddListener (OnClickPanel);
			con.Initialize ();
		}

		// モデルつくるの面倒だったので省略
		#region model
		void OnClickPanel(int id){
			Debug.Log (id);
		}
		#endregion
	}
}
