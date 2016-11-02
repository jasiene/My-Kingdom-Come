using UnityEngine;
using System.Collections;

public class Player : Entity {

	//================================================================================================
	//[Player Variables]//
	//================================================================================================
	public string plyName;

	public HUD hud;

	public bool isHuman;

	public bool isInDirectMode; //check to see if player is directly controlling a character or not
	public bool isPlacingStructure; //check if player is currently in structure placement mode

	public Color color;
	//================================================================================================



	//================================================================================================
	//[Awake]// --- Called before Start, used to initialise variables before game
	//================================================================================================
	protected override void Awake () {

	}
	//================================================================================================



	//================================================================================================
	//[Start]// --- Called before Update, used to pass any information after all initialisation
	//================================================================================================
	protected override void Start () {
		hud = transform.GetComponent<HUD> ();
	}
	//================================================================================================



	//================================================================================================
	//[Update]// --- Called every frame to implement game behaviour
	//================================================================================================
	protected override void Update () {
		
	}
	//================================================================================================

}
