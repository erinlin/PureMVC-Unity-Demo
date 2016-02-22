using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		UnityFacade.GetInstance().StartUp();
	}
	 
	public void GotoNextScene () {
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1);
	}
}
