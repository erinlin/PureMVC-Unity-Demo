using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

//ViewComponent 細節不需要由 Mediator 實作，Mediator 只需要更新與介接 Action 即可
public class MyBox : MonoBehaviour {

	private Text label;

	public System.Action onClick;
	// Use this for initialization

	void Start(){
		Button btn = GetComponentInChildren<Button>();
		btn.onClick.AddListener( OnClick );
	}

	void OnClick(){
		if( onClick!= null) onClick();
	}

	public void UpdateLabel ( string text ) {
		if(label==null)
			label = transform.Find("Label").GetComponent<Text>();

		label.text = text;
	}

}
