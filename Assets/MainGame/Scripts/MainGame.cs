using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MG_Globals.I._start ();
		MG_ControlPlayer.I._setupPlayers ();
		MG_ControlHero.I._setupHeroes ();
	}
	
	// Update is called once per frame
	void Update () {
		/*Inputs*/										MG_Inputs.I._checkPress ();
		/*Temp to main list*/							_tempToMainList ();
		/*Update objects*/								_updateObjects ();
		/*Destroy Update*/								_destroyUpdate ();
	}

	#region "Update objects"
	public void _updateObjects(){
		// Units
		foreach(MG_ClassUnit unit in MG_Globals.I.units){
			unit._update ();
		}

		// Missile
		foreach(MG_ClassMissile missile in MG_Globals.I.missiles){
			missile._update ();
		}
	}
	#endregion

	#region "Temp to main list"
	public void _tempToMainList(){
		// Units
		if(MG_Globals.I.unitsTemp.Count > 0){
			MG_Globals.I.units.AddRange (MG_Globals.I.unitsTemp);
			MG_Globals.I.unitsTemp.Clear ();
		}

		// Missiles
		if(MG_Globals.I.missilesTemp.Count > 0){
			MG_Globals.I.missiles.AddRange (MG_Globals.I.missilesTemp);
			MG_Globals.I.missilesTemp.Clear ();
		}
	}
	#endregion

	#region "Destroy Update"
	private void _destroyUpdate(){
		/*Missiles*/									MG_ControlMissile.I._destroyListed ();
	}
	#endregion
}
