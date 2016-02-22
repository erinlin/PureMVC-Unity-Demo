using UnityEngine;
using System.Collections;
using PureMVC.Patterns;

//拿掉 ImediatorPlug interface
//public interface IMediatorPlug{
//	void Connect();
//	void Disconnect();
//}

public class MediatorPlug : MonoBehaviour {

	[SerializeField]
	private string mediatorName;
	[SerializeField]
	private string mediatorClassRef;
	// Use this for initialization

	void OnEnable () {
		if( !string.IsNullOrEmpty( mediatorClassRef ) )
			Connect();
	}

	void OnDisable(){
		if( !string.IsNullOrEmpty( mediatorClassRef ) )
			Disconnect();
	}
	
	// 
	public void Connect () {
		if( string.IsNullOrEmpty( mediatorName ) ){
			mediatorName = System.Guid.NewGuid().ToString();
		}
		UnityFacade.GetInstance().SendNotification( UnityFacade.CONNECT_MEDIATOR, new Notification( mediatorName, gameObject, mediatorClassRef  ));
//		UnityFacade.GetInstance().ConnectMediator( new Notification( mediatorName, gameObject, mediatorClassRef ) );
	}

	public void Connect (  string mediatorClassRef ) {
		this.mediatorClassRef = mediatorClassRef;
		Connect ();
	}

	public void Connect ( string mediatorClassRef ,string mediatorName ) {
		this.mediatorName = mediatorName;
		this.mediatorClassRef = mediatorClassRef;
		Connect ();
	}

	public void Disconnect () {
		UnityFacade.GetInstance().SendNotification( UnityFacade.DISCONNECT_MEDIATOR, mediatorName );
//		UnityFacade.GetInstance().DisconnectMediator( mediatorName );
	}

}
