using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public class Player : MonoBehaviour {

	//================================================================================================
	//[Player Variables]//
	//================================================================================================
	public string plyName;
	public House plyHouse;

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
	protected void Awake () {
		
		hud = transform.GetComponent<HUD> ();

		plyHouse = new House ("House " + plyName, this);

		materialCircle = new Material (Shader.Find ("Unlit/ProjectorShader"));
		materialCircle.CopyPropertiesFromMaterial (GameHelper.GlobalVariables.SINGLETON_REPOSITORY_REFERENCE.PROJECTOR_CIRCLE);
		materialCircle.color = color;

		materialSquare = new Material (Shader.Find ("Unlit/ProjectorShader"));
		materialSquare.CopyPropertiesFromMaterial (GameHelper.GlobalVariables.SINGLETON_REPOSITORY_REFERENCE.PROJECTOR_SQUARE);
		materialSquare.color = color;

	}
	//================================================================================================



	//================================================================================================
	//[Start]// --- Called before Update, used to pass any information after all initialisation
	//================================================================================================
	protected void Start () {
		
	}
	//================================================================================================



	//================================================================================================
	//[Update]// --- Called every frame to implement game behaviour
	//================================================================================================
	protected void Update () {
		
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
