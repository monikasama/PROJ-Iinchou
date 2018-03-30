using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_ClassMissile {

	public GameObject sprite;
	public Rigidbody2D rigidBody;

	public int playerOwner, unitOwnerID, id;

	public float posX, posY, angle, speed;
	public string type;
	public bool isDead;

	// ANIMATION
	public string facing;

	public MG_ClassMissile(string newType, float newPosX, float newPosY, float newAngle, int newOwnerID, int newID){
		Debug.Log (newType);

		unitOwnerID = newOwnerID;
		if (MG_GetUnit.I._doesUnitExist (newOwnerID))
			playerOwner = MG_GetUnit.I._getUnitFromID (newOwnerID).owner;
		else
			playerOwner = 0;
		posX = newPosX;
		posY = newPosY;
		angle = newAngle;
		type = newType;
		speed = 10f;

		id = newID;
		_facingUpdate ();
		_changeSprite (newType);
	}

	#region "Sprite Changes"
	public void _changeSprite(string newSpriteName){
		if (isDead) 	return;

		if(sprite)
			MG_ControlUnit.I._destroySprite (sprite);

		sprite = MG_DB_Missile.I._getSprite (newSpriteName);
		sprite.transform.position = new Vector3 (posX, posY, posY - 3);
		sprite.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));
		sprite.transform.SetParent (GameObject.Find ("_MG_MISSILES").transform);
		rigidBody = sprite.GetComponent<Rigidbody2D>();
	}
	#endregion

	//Includes
	//	_update()
	//	_changeMoveAngle()
	#region "Update"
	public void _update(){
		float speedX = speed * Mathf.Cos ((angle * Mathf.PI) / 180);
		float speedY = speed * Mathf.Sin ((angle * Mathf.PI) / 180);
		rigidBody.velocity = new Vector3 (speedX, speedY);

		posX = sprite.transform.position.x;
		posY = sprite.transform.position.y;
		sprite.transform.position = new Vector3(sprite.transform.position.x, sprite.transform.position.y, sprite.transform.position.y - 4);
	}

	public void _changeMoveAngle(float newAngle){
		angle = newAngle;
		_facingUpdate ();
	}
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
