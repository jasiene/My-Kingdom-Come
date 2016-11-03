using UnityEngine;
using System.Collections;

namespace GameHelper{
	public static class GlobalVariables {
		
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
		//================================================================================================

	}

	public static class WorldInteraction{

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

}