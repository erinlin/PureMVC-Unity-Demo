using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartUpCommand : PureMVC.Patterns.SimpleCommand {

	public override void Execute(PureMVC.Interfaces.INotification notification)
	{
		Debug.Log("Execute StartUpCommand");
		//Register default proxies and commands
		Facade.RegisterProxy( new CountProxy( CountProxy.NAME ) );
		Facade.RegisterProxy( new Count2Proxy( Count2Proxy.NAME ) );
	}
}
