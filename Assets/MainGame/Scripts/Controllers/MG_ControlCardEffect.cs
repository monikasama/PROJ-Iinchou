using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_ControlCardEffect : MonoBehaviour {
	public static MG_ControlCardEffect I;
	public void Awake(){ I = this; }

	public void _useCard(string cardName, MG_ClassUnit caster){
		switch (cardName) {
			case "test":
				MG_ControlMissile.I._createMissile ("testMissile", caster.posX, caster.posY, caster.owner, _getAngleFromFacing (caster.facing));
			break;
		}
	}

	private float _getAngleFromFacing(string facing){
		if (facing == "Up")
			return 90;
		else if (facing == "Down")
			return 270;
		else if (facing == "Left")
			return 180;
		else
			return 0;
	}
}
