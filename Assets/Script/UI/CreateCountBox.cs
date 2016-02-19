using UnityEngine;
using System.Collections;

public class CreateCountBox : MonoBehaviour {

	public GameObject countBoxPrefab;

	//Create from prefab
	public void CreateCount1Box () {
		Transform group1 = transform.Find("Count1Group");
		MediatorPlug box1 = Instantiate(countBoxPrefab).GetComponent<MediatorPlug>();
		box1.transform.parent = group1;
		box1.transform.localScale = Vector3.one;
		box1.Connect( "Count1Mediator" );
	}

	public void CreateCount2Box () {
		Transform group1 = transform.Find("Count2Group");
		MediatorPlug box1 = Instantiate(countBoxPrefab).GetComponent<MediatorPlug>();
		box1.transform.parent = group1;
		box1.transform.localScale = Vector3.one;
		box1.Connect( "Count2Mediator" );
	}

}
