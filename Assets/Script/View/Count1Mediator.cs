using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;

public class Count1Mediator : PureMVC.Patterns.Mediator {

	public new const string NAME = "Count1Mediator";

	private MyBox box{
		get{ return ((GameObject)ViewComponent).GetComponent<MyBox>(); }
	}

	private CountProxy proxy;
	//IMediatorPlug needs
	public Count1Mediator(string mediatorName, object viewComponent ):base(mediatorName, viewComponent ) {}

	public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>();
		list.Add(CountProxy.UPDATED);
        return list;
    }

	public override void HandleNotification(INotification notification)
	{                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
		switch( notification.Name ){
		case  CountProxy.UPDATED:
			box.UpdateLabel( proxy.GetCount().ToString() );
			break;
		}
	}

	public override void OnRegister()
	{
		Debug.Log("OnRegister:" + MediatorName );
		proxy = Facade.RetrieveProxy( CountProxy.NAME ) as CountProxy;
		box.onClick = OnClick;
		box.UpdateLabel( proxy.GetCount().ToString() );
	}

	//Add count number
	void OnClick(){
		proxy.Add();
	}

	public override void OnRemove()
	{
		Debug.Log("Remove:" + MediatorName );
	}
}
