﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public class Player : Entity {

	//================================================================================================
	//[Player Variables]//
	//================================================================================================
	public string plyName;

	public SingletonRepository singletonRepo;

	public HUD hud;
	public Color color;
	[HideInInspector] public Material materialCircle;
	[HideInInspector] public Material materialSquare;
	public Texture circleTexture;
	public Texture squareTexture;

	public bool isHuman;
	public bool isInDirectMode; //check to see if player is directly controlling a character or not
	public bool isPlacingStructure; //check if player is currently in structure placement mode

	public OrderedDictionary selectedEntities = new OrderedDictionary();
	//================================================================================================



	//================================================================================================
	//[Awake]// --- Called before Start, used to initialise variables before game
	//================================================================================================
	protected override void Awake () {
		singletonRepo = GameObject.Find ("SingletonRepository").GetComponent<SingletonRepository> ();

		hud = transform.GetComponent<HUD> ();

		materialCircle = new Material (Shader.Find ("Unlit/ProjectorShader"));
		materialCircle.CopyPropertiesFromMaterial (singletonRepo.projectorCircle);
		materialCircle.color = color;

		materialSquare = new Material (Shader.Find ("Unlit/ProjectorShader"));
		materialSquare.CopyPropertiesFromMaterial (singletonRepo.projectorSquare);
		materialSquare.color = color;
	}
	//================================================================================================



	//================================================================================================
	//[Start]// --- Called before Update, used to pass any information after all initialisation
	//================================================================================================
	protected override void Start () {
		
	}
	//================================================================================================



	//================================================================================================
	//[Update]// --- Called every frame to implement game behaviour
	//================================================================================================
	protected override void Update () {
		
	}
	//================================================================================================



	//================================================================================================
	//[DeselectAllEntities]// --- 
	//================================================================================================
	public void DeselectAllEntities () {
		foreach(DictionaryEntry pair in selectedEntities){
			Entity ent = (Entity)pair.Value;
			if (ent) {
				ent.ChangeSelection (this, false, false);
			}
		}
		selectedEntities.Clear ();
	}
	//================================================================================================



	//================================================================================================
	//[DeselectAllEntities]// --- 
	//================================================================================================
	public bool CheckIfStructureIsSelected () {
		foreach(DictionaryEntry pair in selectedEntities){
			Entity ent = (Entity)pair.Value;
			if (ent.GetComponentInChildren<Structure>()) {
				return true;
			}
		}
		return false;
	}
	//================================================================================================



	//================================================================================================
	//[DeselectAllEntities]// --- 
	//================================================================================================
	public bool CheckIfAnotherPlayersEntityIsSelected () {
		foreach(DictionaryEntry pair in selectedEntities){
			Entity ent = (Entity)pair.Value;
			if (!ent.IsOwnedBy(this)) {
				return true;
			}
		}
		return false;
	}
	//================================================================================================

}
