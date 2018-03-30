using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_Inputs : MonoBehaviour {
	public static MG_Inputs I;
	public void Awake(){ I = this; }

	public bool IS_MULTIDIRECTIONAL;

	public void _start(){
		IS_MULTIDIRECTIONAL = false;
	}

	/// <summary>
	/// Called from MainGame.cs -> Update()
	/// </summary>
	public void _checkPress(){
		// In game
		_controls_inGame();
	}

	private void _controls_inGame(){
		// P1 Move
		if (Input.GetButtonDown ("P1_MoveUp"))
			MG_ControlPlayer.I._getPlayer (1)._orderHero_Move ("Up");
		if (Input.GetButtonDown ("P1_MoveDown"))
			MG_ControlPlayer.I._getPlayer (1)._orderHero_Move ("Down");
		if (Input.GetButtonDown ("P1_MoveLeft"))
			MG_ControlPlayer.I._getPlayer (1)._orderHero_Move ("Left");
		if (Input.GetButtonDown ("P1_MoveRight"))
			MG_ControlPlayer.I._getPlayer (1)._orderHero_Move ("Right");
		// P1 Misc
		if (Input.GetButtonDown ("P1_Card1"))
			MG_ControlPlayer.I._getPlayer (1)._orderHero_UseCard (0);


		if (Input.GetButtonDown ("P2_MoveUp"))
			MG_ControlPlayer.I._getPlayer (2)._orderHero_Move ("Up");
		if (Input.GetButtonDown ("P2_MoveDown"))
			MG_ControlPlayer.I._getPlayer (2)._orderHero_Move ("Down");
		if (Input.GetButtonDown ("P2_MoveLeft"))
			MG_ControlPlayer.I._getPlayer (2)._orderHero_Move ("Left");
		if (Input.GetButtonDown ("P2_MoveRight"))
			MG_ControlPlayer.I._getPlayer (2)._orderHero_Move ("Right");
	}
}
