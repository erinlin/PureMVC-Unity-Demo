using UnityEngine;
using System.Collections;

public class Count2Proxy : PureMVC.Patterns.Proxy {

	public const string NAME = "Count2Proxy";
	public const string UPDATED = "Count2Proxy.Updated";

	private int m_count;

	public Count2Proxy(string proxyName)
		: base(proxyName, null)
	{
	}

	public override void OnRegister()
	{
		Debug.Log( "Count2Proxy OnRegister");
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
		m_count += 2;
		SendNotification( UPDATED );
	}
}
