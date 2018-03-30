using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_ControlUnit : MonoBehaviour {
	public static MG_ControlUnit I;
	public void Awake(){ I = this; }

	public int unitCnt;

	#region "Creation Codes"
	public void _createUnit(string newUnitType, float newPosX, float newPosY, float newAngle, int newOwner){
		MG_Globals.I.unitsTemp.Add(new MG_ClassUnit(newUnitType, newPosX, newPosY, newAngle, newOwner, unitCnt));
		unitCnt++;
	}
	#endregion

	public void _destroySprite(GameObject sprite){
		Destroy (sprite);
	}

}
