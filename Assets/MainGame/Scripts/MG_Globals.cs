using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_Globals : MonoBehaviour {
	public static MG_Globals I;
	public void Awake(){ I = this; }

	public List<MG_ClassUnit> units, unitsTemp;
	public List<MG_ClassPlayer> players;
	public List<MG_ClassMissile> missiles, missilesTemp;

	public void _start(){
		// LISTS
		units 							= new List<MG_ClassUnit>();
		unitsTemp 						= new List<MG_ClassUnit>();
		players 						= new List<MG_ClassPlayer> ();
		missiles 						= new List<MG_ClassMissile> ();
		missilesTemp 					= new List<MG_ClassMissile> ();
	}
}
