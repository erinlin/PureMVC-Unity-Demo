using UnityEngine;
using System.Collections;

public interface IMediatorPlug{
	void Connect();
	void Disconnect();
	string GetName();
	string GetClassRef();
	UnityEngine.Object GetView();
}

public class MediatorPlug : MonoBehaviour, IMediatorPlug {

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
		UnityFacade.GetInstance().ConnectMediator( this );
	}

	public void Connect (  string mediatorClassRef ) {
		this.mediatorClassRef = mediatorClassRef;
		UnityFacade.GetInstance().ConnectMediator( this );
	}

	public void Connect ( string mediatorClassRef ,string mediatorName ) {
		this.mediatorName = mediatorName;
		this.mediatorClassRef = mediatorClassRef;

		UnityFacade.GetInstance().ConnectMediator( this );
	}

	public void Disconnect () {
		UnityFacade.GetInstance().DisconnectMediator( mediatorName );
	}

		
	public string GetName(){
		if( string.IsNullOrEmpty( mediatorName ) ){
			mediatorName = System.Guid.NewGuid().ToString();
		}
		return mediatorName;
	}

	public string GetClassRef(){
		return mediatorClassRef;
	}

	public UnityEngine.Object GetView(){
		return gameObject;
	}
}
