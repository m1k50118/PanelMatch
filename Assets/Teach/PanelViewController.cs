using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Teach
{
	// UniRxで書きたさ
	public class IntUnityEvent : UnityEvent<int>{
	}

	/// <summary>
	/// パネルの見た目を管理するやつ．パネルを押した時のイベントも持つ
	/// </summary>
	public class PanelViewController : MonoBehaviour
	{
		// パネルをタッチしたときのイベント　　UniRx使ったほうがいいけどこっちの方が少しだけ簡単
		private IntUnityEvent onClickPanelEvent = new IntUnityEvent();
		public IntUnityEvent OnClickPanelEvent{
			get{ return onClickPanelEvent; }
		}
			
		public Panel panel;
		//private List<Panel> panelList = new List<Panel>();

		public void Initialize(){
			panel.Initialize (DoClickPanelEvent, Color.red);
		}

		void DoClickPanelEvent(int id){
			onClickPanelEvent.Invoke (id);
		}
	}
}
