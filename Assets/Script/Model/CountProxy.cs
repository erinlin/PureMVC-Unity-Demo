using UnityEngine;
using System.Collections;

public class CountProxy : PureMVC.Patterns.Proxy {

	public const string NAME = "CountProxy";
	public const string UPDATED = "CountProxy.Updated";

	private int m_count;

	public CountProxy(string proxyName)
		: base(proxyName, null)
	{
	}

	public override void OnRegister()
	{
		Debug.Log( "CountProxy OnRegister");
	}

	/// <summary>
	/// Called by the Model when the Proxy is removed
	/// </summary>
	public override void OnRemove()
	{
	}

	public int GetCount(){
		return m_count;
	}

	public void Add(){
		m_count ++;
		SendNotification( UPDATED );
	}
}
