﻿/*
 * 		MG_CONTROL MISSILE
 * 
 * 		Summary:
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_ControlMissile : MonoBehaviour {
	public static MG_ControlMissile I;
	public void Awake(){ I = this; }

	private int missileCnt;
	public List<int> toDestroy;

	#region "Creation Codes"
	public void _createMissile(string newType, float newPosX, float newPosY, int ownerID, float newAngle){
		MG_Globals.I.missilesTemp.Add (new MG_ClassMissile (newType, newPosX, newPosY, newAngle, ownerID, missileCnt));
		missileCnt++;
	}
	#endregion

	#region "Destroy Codes"
	public void _addToDestroyList(MG_ClassMissile targetMissile){
		toDestroy.Add (targetMissile.id);
	}

	public void _destroyListed(){
		if (toDestroy.Count > 0) {
			for (int i = 0; i < toDestroy.Count; i++) {
				_destroyMissile (i);
			}
		}
	}

	public void _destroyMissile(int targetUnitIndex){
		int indexToRemove = -1;
		for(int i = MG_Globals.I.missiles.Count - 1; i >= 0; i--){
			if(toDestroy[targetUnitIndex] == MG_Globals.I.missiles[i].id){
				indexToRemove = i;
				break;
			}
		}
		if(indexToRemove > -1){
			Destroy (MG_Globals.I.missiles [indexToRemove].sprite);
			MG_Globals.I.missiles.RemoveAt(indexToRemove);
		}
	}
	#endregion
}
