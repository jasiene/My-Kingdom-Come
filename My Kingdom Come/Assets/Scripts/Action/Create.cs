using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : Action {

	//================================================================================================
	//[Create Variables]//
	//================================================================================================
	string entityToCreate;
	Vector3 entitySpawnPosition;
	Quaternion entityRotation;
	//================================================================================================



	//================================================================================================
	//[Constructor]// ---
	//================================================================================================
	public Create(Player player, string actionName, float actionLength, Texture2D actionImage, bool isQueueable, string entityToCreate, Vector3 entitySpawnPosition, Quaternion entityRotation) : base(player, actionName, actionLength, actionImage, isQueueable){
		this.entityToCreate = entityToCreate;
		this.entitySpawnPosition = entitySpawnPosition;
		this.entityRotation = entityRotation;
	}
	//================================================================================================



	//================================================================================================
	//[PerformAction]// ---
	//================================================================================================
	public override void PerformAction(){
		player.SpawnEntity (entityToCreate, entitySpawnPosition, entityRotation);
	}
	//================================================================================================

}
