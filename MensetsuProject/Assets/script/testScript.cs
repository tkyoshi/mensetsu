using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testScript : MonoBehaviour {

	string[] Test = {
		"これから面接を始めます",
		"局長のパンツです",
		"力30、HP100って\n中盤くらいの強さだよね？",
		"そのステータスで\nやっていけると思ってるの？",
		"今日はありがとうございました\n採用です。",
	};
	public int textSpd=10;
	public int txtSpace=180;
	int lineCount = 0;
	int lineSize = 0;
	int txtcount = 0;
	int txtSize = 0;

	int endCount = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GameObject canvas = GameObject.Find ("Canvas/Image/Text_TalkMessage");
		GameObject ushiBlack = GameObject.Find ("BlackUshi/HeadPos/Head");
		GameObject ushi1 = GameObject.Find ("ushi_1/HeadPos/Head");
		GameObject ushi2 = GameObject.Find ("ushi_2/HeadPos/Head");

		Transform targetTransform = canvas.transform;
		Transform ushiTransForm = ushiBlack.transform;
		Transform ushi1TransForm = ushi1.transform;
		Transform ushi2TransForm = ushi2.transform;

		Animator ushiAnim = ushiTransForm.GetComponent<Animator> ();
		Animator ushi1Anim = ushi1TransForm.GetComponent<Animator> ();
		Animator ushi2Anim = ushi2TransForm.GetComponent<Animator> ();
		string anim = "Stop";

		string currentText = Test [lineSize];

		if (txtSize < currentText.Length) 
		{
			anim = "Shaberi";
		}

		txtcount++;
		if (txtcount > textSpd && txtSize < currentText.Length) 
		{
			txtcount = 0;
			txtSize++;
		}
		else if(txtSize == currentText.Length)
		{
			if( lineSize < Test.Length-1 )
			{
				lineCount++;
				if( lineCount >= txtSpace )
				{
					lineSize++;
					lineCount = 0;
					txtSize = 0;
				}
				else if (lineSize == 3) 
				{
					anim = "Kashige";
				}
			}
		}

		if (lineSize == Test.Length-1) 
		{
			anim = "Saiyou";

			endCount++;
			if( endCount == 300 )
			{
				Application.LoadLevel("testSaiyou");
			}
		}

		//if (ushiAnim.GetCurrentAnimatorStateInfo (0).IsName ("kashige.anm"))
		//{
		ushiAnim.SetTrigger (anim);
		ushi1Anim.SetTrigger (anim);
		ushi2Anim.SetTrigger (anim);
		//}
		targetTransform.GetComponent<Text>().text = currentText.Substring(0,txtSize);
		
	}
}
