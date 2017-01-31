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

	[HideInInspector] private static int MAINMENU_WIDTH = 256;
	[HideInInspector] private static int MAINMENU_HEIGHT = 384;

	[HideInInspector] private bool showMainMenu = false;
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

		if (GUI.Button (new Rect (Screen.width - 144, 0, 128, TOP_BAR_HEIGHT), "Main Menu")) {
			showMainMenu = true;
			GameHelper.GameState.PauseGame ();
		}
		if (showMainMenu) {
			DrawMainMenuPopup ();
		}
		//================================================================================================


		//================================[BOTTOM BAR]====================================================
		GUI.Box (new Rect (0, Screen.height - ENTITY_INFO_SIZE, ENTITY_INFO_SIZE, ENTITY_INFO_SIZE), "");
		if (player.selectedEntities.Count == 1) {
			foreach(DictionaryEntry pair in player.selectedEntities){
				Entity ent = (Entity)pair.Value;
				if (ent) {
					GUI.Label (new Rect (16, Screen.height - ENTITY_INFO_SIZE + 8, 112, 24), ent.player.plyName);

					GUI.DrawTexture (new Rect (16, Screen.height - ENTITY_INFO_SIZE + 32, 64, 64), ent.image);

					GUI.Label (new Rect (88, Screen.height - ENTITY_INFO_SIZE + 48, 112, 24), (ent.curHealth+ "/" + ent.baseHealth));

					if (ent.GetComponentInChildren<Character> ()) {
						temp = ent.GetComponentInChildren<Character> ().characterName;
					} else {
						temp = "";
					}
					GUI.Label (new Rect (16, Screen.height - ENTITY_INFO_SIZE + 96, 112, 112), ent.displayName + "\n" + temp);
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
		//================================================================================================


		//================================[BOTTOM BAR]====================================================
		GUI.Box (new Rect (ENTITY_INFO_SIZE, Screen.height - BOTTOM_BAR_HEIGHT, (Screen.width - ENTITY_INFO_SIZE*2)/5*2, BOTTOM_BAR_HEIGHT), "");
		//================================================================================================
		if (player.selectedEntities.Count == 1) {
			foreach (DictionaryEntry pair in player.selectedEntities) {
				Entity ent = (Entity)pair.Value;
				if (ent && ent.IsOwnedBy(player)) {
					int i = 0;
					foreach (Action action in ent.performableActions) {
						if (GUI.Button (new Rect (ENTITY_INFO_SIZE + 8 + i*64, Screen.height - BOTTOM_BAR_HEIGHT + 8, 56, 56), action.GetActionName ())) {
							action.PerformAction ();
						}
						i++;
					}
				}
			}
		}
		//================================[BOTTOM BAR]====================================================
		GUI.Box (new Rect (ENTITY_INFO_SIZE + (Screen.width - ENTITY_INFO_SIZE*2)/5*2, Screen.height - BOTTOM_BAR_HEIGHT, (Screen.width - ENTITY_INFO_SIZE*2)/5*3, BOTTOM_BAR_HEIGHT), "");
		//================================================================================================


		//================================[BOTTOM BAR]====================================================
		GUI.Box (new Rect (Screen.width - ENTITY_INFO_SIZE, Screen.height - ENTITY_INFO_SIZE, ENTITY_INFO_SIZE, ENTITY_INFO_SIZE), "");
		//================================================================================================
		//================================================================================================
		GUI.EndGroup();

	}
	//================================================================================================



	//================================================================================================
	//[DrawMainMenuPopup]// --- 
	//================================================================================================
	public void DrawMainMenuPopup () {
		GUI.Box (new Rect (Screen.width/2 - MAINMENU_WIDTH/2, Screen.height/2 - MAINMENU_HEIGHT/2, MAINMENU_WIDTH, MAINMENU_HEIGHT), "");

		// CLOSE BUTTON
		if (GUI.Button (new Rect (Screen.width / 2 - MAINMENU_WIDTH / 2 + 16, Screen.height / 2 + MAINMENU_HEIGHT / 2 - MAINMENU_HEIGHT / 8 - 16, MAINMENU_WIDTH - 32, MAINMENU_HEIGHT / 8), "Resume Game")) {
			showMainMenu = false;
			GameHelper.GameState.ResumeGame ();
		}
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
