using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	//================================================================================================
	//[HUD Variables]//
	//================================================================================================
	Player player;

	public string temp = "";

	[HideInInspector] private static float TOP_BAR_HEIGHT = 32f;
	[HideInInspector] private static float BOTTOM_BAR_HEIGHT = 144f;
	[HideInInspector] private static float ENTITY_INFO_SIZE = 192f;
	[HideInInspector] private static int MAX_ROWS_FOR_MULTIPLE_SELECTION = 5;
	[HideInInspector] private static int MAX_COLUMNS_FOR_MULTIPLE_SELECTION = 4;
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
		GUI.Box (new Rect (0, Screen.height - ENTITY_INFO_SIZE, ENTITY_INFO_SIZE, ENTITY_INFO_SIZE), "Entity Info");
		if (player.selectedEntities.Count == 1) {
			foreach(DictionaryEntry pair in player.selectedEntities){
				Entity ent = (Entity)pair.Value;
				if (ent) {
					GUI.Label (new Rect (88, Screen.height - ENTITY_INFO_SIZE + 32, 112, 24), (ent.curHealth+ "/" + ent.baseHealth));
					if (ent.GetComponentInChildren<Character> ()) {
						temp = ent.GetComponentInChildren<Character> ().characterName;
					} else {
						temp = "";
					}
					GUI.DrawTexture (new Rect (16, Screen.height - ENTITY_INFO_SIZE + 32, 64, 64), ent.image);
					GUI.Label (new Rect (16, Screen.height - ENTITY_INFO_SIZE + 96, 112, 48), ent.displayName + "\n" + temp);
				}
			}
		} else if (player.selectedEntities.Count > 1) {
			int rows = 0;
			int columns = 0;
			foreach(DictionaryEntry pair in player.selectedEntities){
				Entity ent = (Entity)pair.Value;
				if (ent) {
					GUI.DrawTexture (new Rect (16 + (32 * columns), Screen.height - ENTITY_INFO_SIZE + 16 + (32 * rows), 32, 32), ent.image);
					columns++;
					if (columns == MAX_COLUMNS_FOR_MULTIPLE_SELECTION) {
						columns = 0;
						rows++;
					}
				}
			}
		}
		//================================[BOTTOM BAR]====================================================
		GUI.Box (new Rect (ENTITY_INFO_SIZE, Screen.height - BOTTOM_BAR_HEIGHT, (Screen.width - ENTITY_INFO_SIZE*2)/5*2, BOTTOM_BAR_HEIGHT), "Entity Commands/Player Actions");
		//================================[BOTTOM BAR]====================================================
		GUI.Box (new Rect (ENTITY_INFO_SIZE + (Screen.width - ENTITY_INFO_SIZE*2)/5*2, Screen.height - BOTTOM_BAR_HEIGHT, (Screen.width - ENTITY_INFO_SIZE*2)/5*3, BOTTOM_BAR_HEIGHT), "World Stats/Politics (unsure as of yet)");
		//================================[BOTTOM BAR]====================================================
		GUI.Box (new Rect (Screen.width - ENTITY_INFO_SIZE, Screen.height - ENTITY_INFO_SIZE, ENTITY_INFO_SIZE, ENTITY_INFO_SIZE), "Mini Map");
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
		return (
			(Input.mousePosition.y >= ENTITY_INFO_SIZE && Input.mousePosition.y <= Screen.height - TOP_BAR_HEIGHT) ||
			(
				(Input.mousePosition.y >= BOTTOM_BAR_HEIGHT && Input.mousePosition.y <= Screen.height - ENTITY_INFO_SIZE) &&
				(Input.mousePosition.x >= ENTITY_INFO_SIZE && Input.mousePosition.x <= Screen.width - ENTITY_INFO_SIZE)
			)
		);
	}
	//================================================================================================


}
