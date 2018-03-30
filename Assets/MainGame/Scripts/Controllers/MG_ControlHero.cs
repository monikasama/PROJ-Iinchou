/*
 * 		MG_CONTROL HERO
 * 
 * 		Summary:
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_ControlHero : MonoBehaviour {
	public static MG_ControlHero I;
	public void Awake(){ I = this; }

	public void _setupHeroes(){
		// Player 1
		MG_ClassPlayer curPlayer = MG_ControlPlayer.I._getPlayer(1);
		curPlayer._setHero("testYouP1");
		curPlayer._createHero (6, -3, 180);

		// Player 2
		curPlayer = MG_ControlPlayer.I._getPlayer(2);
		curPlayer._setHero("testYouP2");
		curPlayer._createHero (-6, 3, 0);
	}
}
