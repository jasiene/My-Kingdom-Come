using UnityEngine;
using System.Collections;

public class Hovel : Structure{

	//================================================================================================
	//[Hovel Variables]//
	//================================================================================================

	//================================================================================================



	//================================================================================================
	//[Awake]// --- Called before Start, used to initialise variables before game
	//================================================================================================
	protected override void Awake () {
		base.Awake ();
	}
	//================================================================================================



	//================================================================================================
	//[Start]// --- Called before Update, used to pass any information after all initialisation
	//================================================================================================
	protected override void Start () {
		base.Start ();

		performableActions.Add (new Place ("Place Hovel", 0, GameHelper.GlobalVariables.SINGLETON_REPOSITORY_REFERENCE.GetEntityImage("hovel"), false, "hovel"));
		performableActions.Add (new Place ("Place Keep", 0, GameHelper.GlobalVariables.SINGLETON_REPOSITORY_REFERENCE.GetEntityImage("keep"), false, "keep"));
		performableActions.Add (new Create ("Create Yeoman", 5, GameHelper.GlobalVariables.SINGLETON_REPOSITORY_REFERENCE.GetEntityImage("yeoman"), true, "yeoman"));
	}
	//================================================================================================



	//================================================================================================
	//[Update]// --- Called every frame to implement game behaviour
	//================================================================================================
	protected override void Update () {
		base.Update ();
	}
	//================================================================================================

}
