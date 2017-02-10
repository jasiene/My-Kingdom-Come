using UnityEngine;
using System.Collections;

namespace GameHelper{
	//====================================================================================================
	public class GlobalVariables {
		
		//================================================================================================
		//[RTS Camera Variables]//
		//================================================================================================
		public static float CAMERA_MOVEMENT_SPEED = 60f;
		public static float CAMERA_MOVEMENT_SPEED_SHIFT_MODIFIER = 120f;
		public static float CAMERA_ROTATION_SPEED = 90f;
		public static float CAMERA_SCROLL_ZOOM_SPEED = 350f;

		public static float SCREEN_EDGE_WIDTH_FOR_CAMERA_MOVEMENT = 10f;
		public static float CAMERA_MAX_HEIGHT = 50f;
		public static float CAMERA_MIN_HEIGHT = 10f;

		public static Vector3 UNREACHABLE_VECTOR = new Vector3(-99999, -99999, -99999);

		public static int MAX_ENTITY_SELECTION = 24;

		public static bool GAME_PAUSED = false;

		public static float DEFAULT_TIMESCALE = Time.timeScale;

		public static string[] CHARACTER_FIRST_NAMES = {
			"John", "Arthur", "William", "Robert", "Ricard", "Rauf",
			"Walter", "Thomas", "Henry", "Adam", "Roger", "Stephen", "Gilbert", "Hugh", "Jeffrey",
			"Simon", "Alan", "Peter", "Edmund", "Phelip", "Jake", "Laurence", "Paul", "Clement", "Arnaud",
			"Elyas", "Lucas", "Martin", "Giles", "Lambert", "Marc", "Randulf", "Vincent"
		};

		public static string[] CHARACTER_LAST_NAMES = {
			"Burrel", "Capron", "Challener", "Draper", "Dyer", "Fuller",
			"Hatter", "Hood", "Napier", "Parmenter", "Quilter", "Webber", "Becker", "Alder", "Dean",
			"Ford", "Forrest", "Garside", "Hawthorne", "Johnston", "Millerchip", "Ridge", "Underwood",
			"West", "Woodrow", "Gregory", "Rolfe", "Ward", "Brickenden", "Browne", "Baker", "Adamson",
			"Alfson"
		};

		public static SingletonRepository SINGLETON_REPOSITORY_REFERENCE = 
			GameObject.Find ("SingletonRepository").GetComponent<SingletonRepository> ();
		//================================================================================================

	}
	//====================================================================================================
	public class WorldInteraction{

		//================================================================================================
		//[FindObjectAt2DPoint]//
		//================================================================================================
		public static GameObject FindObjectAt2DPoint(Vector2 point){
			Ray ray = Camera.main.ScreenPointToRay (point);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 500f)) {
				return hit.collider.gameObject;
			}
			return null;
		}
		//================================================================================================

		public static bool mouseIsOutsideScreen() {
			return Input.mousePosition.x <= 0f
			|| Input.mousePosition.x >= Screen.width
			|| Input.mousePosition.y <= 0f
			|| Input.mousePosition.y >= Screen.height;
		}

		//================================================================================================
		//[Find3DVectorAt2DPoint]//
		//================================================================================================
		public static Vector3 Find3DVectorAt2DPoint(Vector2 point){
			Ray ray = Camera.main.ScreenPointToRay (point);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 500f)) {
				return hit.point;
			}
			return GlobalVariables.UNREACHABLE_VECTOR;
		}
		//================================================================================================


	}
	//====================================================================================================
	public class GameState{

		//================================================================================================
		//[PauseGame]//
		//================================================================================================
		public static void PauseGame(){
			GlobalVariables.GAME_PAUSED = true;
			Time.timeScale = 0;
		}
		//================================================================================================



		//================================================================================================
		//[ResumeGame]//
		//================================================================================================
		public static void ResumeGame(){
			GlobalVariables.GAME_PAUSED = false;
			Time.timeScale = GlobalVariables.DEFAULT_TIMESCALE;
		}
		//================================================================================================

	}
	//====================================================================================================
}