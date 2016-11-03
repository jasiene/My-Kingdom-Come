using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	//================================================================================================
	//[HUD Variables]//
	//================================================================================================
	Player player;

	public string str = "none";

	[HideInInspector] private static float TOP_BAR_HEIGHT = 32f;
	[HideInInspector] private static float BOTTOM_BAR_HEIGHT = 144f;
	//================================================================================================



	//================================================================================================
	//[Awake]// --- Called before Start, used to initialise variables before game
	//================================================================================================
	protected virtual void Awake () {

	}
	//================================================================================================



	//================================================================================================
	//[Start]// --- Called before Update, used to pass any information after all initialisation
	//================================================================================================
	protected virtual void Start () {
		player = transform.GetComponentInParent<Player> ();
	}
	//================================================================================================



	//================================================================================================
	//[OnGUI]// --- Called for GUI implementation (Update should not be used for GUI)
	//================================================================================================
	protected virtual void OnGUI () {
		if (player.isHuman) {
			if (player.isInDirectMode) {
				DrawDirectModeHUD ();
			} else {
				DrawRTSModeHUD ();
			}
		}
	}
	//================================================================================================


	//================================================================================================
	//[DrawDirectModeHUD]//
	//================================================================================================
	private void DrawDirectModeHUD () {
		
	}
	//================================================================================================



	//================================================================================================
	//[DrawDirectModeHUD]//
	//================================================================================================
	private void DrawRTSModeHUD () {

		GUI.BeginGroup (new Rect(0, 0, Screen.width, Screen.height));
		//================================================================================================
		//================================================================================================
		//=================================[TOP BAR]======================================================
		GUI.Box (new Rect (0, 0, Screen.width, TOP_BAR_HEIGHT), "");
		//================================================================================================
		//================================================================================================
		//================================[BOTTOM BAR]====================================================
		GUI.Box (new Rect (0, Screen.height - Screen.width/7, Screen.width/7, Screen.width/7), "Entity Info");
		GUI.Box (new Rect (Screen.width/7, Screen.height - BOTTOM_BAR_HEIGHT, Screen.width/7*2, BOTTOM_BAR_HEIGHT), "Entity Commands/Player Actions");
		GUI.Box (new Rect (Screen.width/7*3, Screen.height - BOTTOM_BAR_HEIGHT, Screen.width/7*3, BOTTOM_BAR_HEIGHT), "World Stats/Politics (unsure as of yet)");
		GUI.Box (new Rect (Screen.width/7*6, Screen.height - Screen.width/7, Screen.width/7+1, Screen.width/7), "Mini Map");





		/*
		str = "";
		GUI.Box (new Rect (0, Screen.height - BOTTOM_BAR_HEIGHT, Screen.width/3, BOTTOM_BAR_HEIGHT), "");
		foreach(DictionaryEntry pair in player.selectedEntities){
			Entity ent = (Entity)pair.Value;
			if (ent) {
				if (ent.GetComponentInChildren<Structure> ()) {
					str = str + ent.GetComponentInChildren<Structure> ().structureName + ", ";
				} else if (ent.GetComponentInChildren<Character> ()) {
					str = str + ent.GetComponentInChildren<Character> ().characterName + ", ";
				} else {
					str = str + ent.entName + ", ";
				}
			}
		}
		GUI.Label (new Rect (4, Screen.height - BOTTOM_BAR_HEIGHT + 4, Screen.width/3 - 8, 24), str);
		*/
		//================================================================================================
		//================================================================================================
		//================================================================================================
		GUI.EndGroup();

	}
	//================================================================================================



	//================================================================================================
	//[MouseOutsideHUD]// --- Camera movement controls when in direct mode
	//================================================================================================
	public bool IsMouseOutsideHUD () {
		return (Input.mousePosition.y >= BOTTOM_BAR_HEIGHT && Input.mousePosition.y <= Screen.height - TOP_BAR_HEIGHT);
	}
	//================================================================================================


}
