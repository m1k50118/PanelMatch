using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Teach
{

	/// <summary>
	/// パネルにつけるコンポーネント．
	/// </summary>
	[RequireComponent(typeof(Button))]
	[RequireComponent(typeof(Image))]
	public class Panel : MonoBehaviour
	{
		public int id = 0;
		private UnityAction<int> onClick;

		[SerializeField]
		private Button button;

		[SerializeField]
		private Image image;

		void Reset(){
			button = this.GetComponent<Button> ();
			image = this.GetComponent<Image> ();
		}

		// 初期化
		public void Initialize(UnityAction<int> action, Color color){
			onClick = action;
			image.color = color;
			button.onClick.RemoveAllListeners ();
			button.onClick.AddListener (DoClick);
		}

		// 表示させる
		public void Show(){
			this.gameObject.SetActive (true);
		}

		void DoClick(){
			if (onClick != null) {
				onClick(id);
			}
		}
	}
}
