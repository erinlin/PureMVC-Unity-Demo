using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PureMVC.Interfaces;

public class UnityFacade : PureMVC.Patterns.Facade {

	public const string STARTUP = "UnityFacade.StartUp";

	public const string CONNECT_MEDIATOR = "connectToMediator";
	public const string DISCONNECT_MEDIATOR = "disconnectFromMediator";

	static UnityFacade()
	{
		m_instance = new UnityFacade();
    }
	 
	// Override Singleton Factory method 
	public static UnityFacade GetInstance() {
		return m_instance as UnityFacade;
	}

	protected override void InitializeController() {
		base.InitializeController();
		RegisterCommand( STARTUP, typeof(StartUpCommand)  );
		RegisterCommand( CONNECT_MEDIATOR, typeof(MediatorPlugCommand)  );
		RegisterCommand( DISCONNECT_MEDIATOR, typeof(MediatorPlugCommand)  );
	}

	public void StartUp()
	{
		SendNotification( STARTUP );
	}
	//Handle MediatorPlug connection, params 修改成 INotification
//	public void ConnectMediator( INotification item )
//	{
//		Type mediatorType = Type.GetType( item.Type );
//		if( mediatorType!=null){
//			IMediator mediatorPlug = (IMediator)Activator.CreateInstance( mediatorType, item.Name, item.Body ) ;
//			RegisterMediator( mediatorPlug );
//		}
//	}
//
//	public void DisconnectMediator( string mediatorName )
//	{
//		RemoveMediator( mediatorName );
//	}
}
