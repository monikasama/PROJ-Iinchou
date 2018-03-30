using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_DB_Unit : MonoBehaviour {
	public static MG_DB_Unit I;
	public void Awake(){ I = this; }

	public GameObject dummy;
	#region "testYou"
	/*IdleMove*/			public GameObject testYou_idleMove_Left, testYou_idleMove_Right, testYou_idleMove_Up, testYou_idleMove_Down;
	#endregion
	#region "testYou P2"
	/*IdleMove*/			public GameObject testYouP2_idleMove_Left, testYouP2_idleMove_Right, testYouP2_idleMove_Up, testYouP2_idleMove_Down;
	#endregion

	public GameObject _getSprite(string newSpriteName){
		GameObject retVal = GameObject.Instantiate (dummy, new Vector3 (0, 0, 0), Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject;
		Destroy (retVal);
		switch (newSpriteName) {
			#region "testYouP1"
			case "testYouP1 idleMove Left": retVal = GameObject.Instantiate (testYou_idleMove_Left, new Vector3 (0, 0, 0), Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject; break;
			case "testYouP1 idleMove Right": retVal = GameObject.Instantiate (testYou_idleMove_Right, new Vector3 (0, 0, 0), Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject; break;
			case "testYouP1 idleMove Up": retVal = GameObject.Instantiate (testYou_idleMove_Up, new Vector3 (0, 0, 0), Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject; break;
			case "testYouP1 idleMove Down": retVal = GameObject.Instantiate (testYou_idleMove_Down, new Vector3 (0, 0, 0), Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject; break;
			#endregion

			#region "testYouP2"
			case "testYouP2 idleMove Left": retVal = GameObject.Instantiate (testYouP2_idleMove_Left, new Vector3 (0, 0, 0), Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject; break;
			case "testYouP2 idleMove Right": retVal = GameObject.Instantiate (testYouP2_idleMove_Right, new Vector3 (0, 0, 0), Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject; break;
			case "testYouP2 idleMove Up": retVal = GameObject.Instantiate (testYouP2_idleMove_Up, new Vector3 (0, 0, 0), Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject; break;
			case "testYouP2 idleMove Down": retVal = GameObject.Instantiate (testYouP2_idleMove_Down, new Vector3 (0, 0, 0), Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject; break;
			#endregion
		}

		return retVal;
	}
}
