using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_ClassUnit {

	public GameObject sprite;

	public int owner, id;
	public Rigidbody2D rigidBody;
	public string type;

	// MAIN STATS
	public int HP, HPmax;
	public float MS = 4.5f, MS_origin = 4.5f;	// TESTTTTTTTTTTTTTTTTTTTTTTTTTTT
	public float posX, posY;
	public bool isBumperCar = true;				// TESTTTTTTTTTTTTTTTTTTTTTTTTTTT

	// ANIMATION
	public string anim_status = "idleMove";
	public float angle;
	public string facing;

	// DEATH
	public bool isDead;
	/*
	 	LIST: idleMove = for bumper cars
	*/

	public MG_ClassUnit(string newType, float newPosX, float newPosY, float newAngle, int newPlayerOwner, int newID){
		owner = newPlayerOwner;
		posX = newPosX;
		posY = newPosY;
		angle = newAngle;
		type = newType;
		
		id = newID;
		_facingUpdate ();
		_changeSprite (newType);
	}

	#region "Sprite Changes"
	public void _changeSprite(string newSpriteName){
		if (isDead) 	return;

		if(sprite)
			MG_ControlUnit.I._destroySprite (sprite);
		
		sprite = MG_DB_Unit.I._getSprite (newSpriteName + " " + anim_status + " " + facing);
		sprite.transform.position = new Vector3 (posX, posY, posY - 3);
		sprite.transform.SetParent (GameObject.Find ("_MG_UNITS").transform);
		rigidBody = sprite.GetComponent<Rigidbody2D>();
	}
	#endregion

	#region "Update"
	public void _update(){
		if (isDead) {
			// Dead update
			
		} else {
			// Not dead update
			// Position set
			posX = sprite.transform.position.x;
			posY = sprite.transform.position.y;
			sprite.transform.position = new Vector3(sprite.transform.position.x, sprite.transform.position.y, sprite.transform.position.y - 3);
		}
	}
	#endregion

	//Includes:
	//	- _move_Increment()						= starts moving at an input angle
	#region "COMMANDS - Move"
	public void _move_Increment(float moveAngle){
		if(anim_status != "idle" && anim_status != "idleMove") return;

		angle = moveAngle;
		_facingUpdate ();
		_changeSprite (type);

		float 	moveX = MS * Mathf.Cos ((moveAngle * Mathf.PI) / 180),
				moveY = MS * Mathf.Sin ((moveAngle * Mathf.PI) / 180);

		rigidBody.velocity = new Vector3 (moveX, moveY);
	}
	#endregion

	#region "Physics"

	#endregion

	//Includes
	//	_facingUpdate()							= Updates the facing when the angle is changed
	#region "Misc"
	public void _facingUpdate(){
		// Angle update
		if (angle <= 45 || angle >= 315){
			facing = "Right";
		}else if (angle <= 135 && angle >= 45) {
			facing = "Up";
		}else if (angle <= 225 && angle >= 135) {
			facing = "Left";
		}else if (angle <= 315 && angle >= 225) {
			facing = "Down";
		}
	}
	#endregion
}
