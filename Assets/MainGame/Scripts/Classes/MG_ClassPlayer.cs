/*
 * 		MG_CONTROL PLAYER
 * 
 * 		Summary:
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MG_ClassPlayer {
	
	public int playerNum;

	// HERO
	public string heroType;
	public MG_ClassUnit hero;

	// RELATIONSHIP BETWEEN OTHER PLAYERS
	public List<int> rel_friends;

	// CARDS AND DECK
	public List<string> card_inHand;

	public MG_ClassPlayer(int newPlayerNum, int[] friendlyPlayers){
		playerNum = newPlayerNum;
		rel_friends = new List<int> ();
		rel_friends.AddRange (friendlyPlayers.ToList());

		card_inHand = new List<string> ();
		// FOR TEST
		string[] cardsInHand = {"test", "test2"};
		card_inHand.AddRange(cardsInHand);
	}

	#region "Player Stat Controls"

	#endregion

	//Includes
	//	- _setHero()					- sets the hero type and details for this player
	//	- _createHero()					- creates the hero on a target point
	//	- _orderHero_MoveLeft()
	//	- _orderHero_UseCard()
	#region "Hero Controls"
	public void _setHero(string newHeroType){
		heroType = newHeroType;
	}

	public void _createHero(float newPosX, float newPosY, float newAngle){		
		MG_ControlUnit.I._createUnit (heroType, newPosX, newPosY, newAngle, playerNum);
		hero = MG_GetUnit.I._getLastCreatedUnit ();
	}

	public void _orderHero_Move(string moveType){
		if (!_orderConditions())
			return;

		switch(moveType){
			case "Up":
				hero._move_Increment (90);
			break;
			case "Down":
				hero._move_Increment (270);
			break;
			case "Left":
				hero._move_Increment (180);
			break;
			case "Right":
				hero._move_Increment (0);
			break;
		}
	}

	public void _orderHero_UseCard(int cardNum){
		if (!_orderConditions())
			return;

		MG_ControlCardEffect.I._useCard (card_inHand [cardNum], hero);
	}

	// Returns true if an order can be issued to the hero
	private bool _orderConditions(){
		if (hero == null)
			return false;

		return true;
	}
	#endregion
}
