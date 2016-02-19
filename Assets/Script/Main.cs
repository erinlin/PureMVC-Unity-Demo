using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		UnityFacade.GetInstance().StartUp();
	}
	
	// Update is called once per frame
	public void GotoNextScene () {
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1);
	}
}
