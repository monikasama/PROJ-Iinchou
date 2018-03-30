using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_ControlPlayer : MonoBehaviour {
	public static MG_ControlPlayer I;
	public void Awake(){ I = this; }

	public void _setupPlayers(){
		MG_Globals.I.players.Add (new MG_ClassPlayer (0, new int[]{0,6}));			// Unused
		MG_Globals.I.players.Add (new MG_ClassPlayer (1, new int[]{0,6}));			// Actual Player (PLAYER or CPU)
		MG_Globals.I.players.Add (new MG_ClassPlayer (2, new int[]{0,6}));			// Actual Player (PLAYER or CPU)
		MG_Globals.I.players.Add (new MG_ClassPlayer (3, new int[]{0,6}));			// Actual Player (PLAYER or CPU)
		MG_Globals.I.players.Add (new MG_ClassPlayer (4, new int[]{0,6}));			// Actual Player (PLAYER or CPU)

		MG_Globals.I.players.Add (new MG_ClassPlayer (5, new int[]{0,6}));						// Hostile Player
		MG_Globals.I.players.Add (new MG_ClassPlayer (6, new int[]{0,1,2,3,4,5,6}));			// Passive Player
	}

	public MG_ClassPlayer _getPlayer(int targetNum){
		MG_ClassPlayer retVal = MG_Globals.I.players[0];
		foreach(MG_ClassPlayer pL in MG_Globals.I.players){
			if (pL.playerNum == targetNum) {
				retVal = pL;
				break;
			}
		}

		return retVal;
	}
}
