using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PureMVC.Interfaces;

public class MediatorPlugCommand : PureMVC.Patterns.SimpleCommand {

	public override void Execute(INotification notification)
	{
		switch( notification.Name ){
		case UnityFacade.CONNECT_MEDIATOR:
			INotification item = (INotification)notification.Body;
			System.Type mediatorType = System.Type.GetType( item.Type );
			if( mediatorType!=null){
				IMediator mediatorPlug = (IMediator)System.Activator.CreateInstance( mediatorType, item.Name, item.Body ) ;
				Facade.RegisterMediator( mediatorPlug );
			}
			break;
		case UnityFacade.DISCONNECT_MEDIATOR:
			Facade.RemoveMediator( (string)notification.Body );
			break;
		}
	}
}
