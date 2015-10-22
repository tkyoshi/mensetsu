using UnityEngine;
using System.Collections;
//using BoardSystem;

public class BoardPicture : MonoBehaviour {

	public string PosterID = "None";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0))
		{
			
			Vector3 aTapPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Collider2D aCollider2d = Physics2D.OverlapPoint (aTapPoint);
			Collider2D myCol = GetComponent<Collider2D>();
			
			if (aCollider2d == myCol)
			{
				GameObject obj = GameObject.Find ("System");
				BoardSystem system = obj.transform.GetComponent<BoardSystem> ();
				system.ClickPoster (PosterID);
			}
		}
	}
}
