using UnityEngine;
using System.Collections;

public class BoardSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ClickPoster(string posterId)
	{
		if (posterId == "Ushi")
		{
			Application.LoadLevel ("test");
		}
	}
}
