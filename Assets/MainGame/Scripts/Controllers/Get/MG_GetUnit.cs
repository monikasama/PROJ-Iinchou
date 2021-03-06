﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_GetUnit : MonoBehaviour {
	public static MG_GetUnit I;
	public void Awake(){ I = this; }

	#region "Get Last Created Unit"
	public MG_ClassUnit _getLastCreatedUnit(){
		return MG_Globals.I.unitsTemp [MG_Globals.I.unitsTemp.Count - 1];
	}
	#endregion

	//Includes:
	//	- _doesUnitExist			- Returns true if a unit with an input ID exists
	//	- _getUnitFromID			- Returns the unit with the input ID
	#region "Get Unit from ID"
	public bool _doesUnitExist(int unitID){
		bool retVal = false;
		foreach (MG_ClassUnit uL in MG_Globals.I.units) {
			if (uL.id == unitID) {
				retVal = true;
				break;
			}
		}
		if (!retVal) {
			foreach (MG_ClassUnit uL in MG_Globals.I.unitsTemp) {
				if (uL.id == unitID) {
					retVal = true;
					break;
				}
			}
		}
		return retVal;
	}

	public MG_ClassUnit _getUnitFromID(int unitID){
		MG_ClassUnit retVal = MG_Globals.I.units[0];
		bool hasUnit = false;
		foreach (MG_ClassUnit uL in MG_Globals.I.units) {
			if (uL.id == unitID) {
				retVal = uL; hasUnit = true;
				break;
			}
		}
		if (!hasUnit) {
			foreach (MG_ClassUnit uL in MG_Globals.I.unitsTemp) {
				if (uL.id == unitID) {
					retVal = uL;
					break;
				}
			}
		}
		return retVal;
	}
	#endregion
}
