using UnityEngine;
using System.Collections;
using GameHelper;

[RequireComponent(typeof (Player))] //Unity specific, forces the object that uses PlayerInput to also attach a Player component (because we need one to have player input)
public class PlayerInput : MonoBehaviour {

	//================================================================================================
	//[PlayerInput Variables]//
	//================================================================================================
	public Player player;
	public Transform plyCamera;
	//================================================================================================



	//================================================================================================
	//[Awake]// --- Called before Start, used to initialise variables before game
	//================================================================================================
	void Awake () {

	}
	//================================================================================================



	//================================================================================================
	//[Start]// --- Called before Update, used to pass any information after all initialisation
	//================================================================================================
	void Start () {
		player = transform.GetComponent<Player> ();
		plyCamera = transform.FindChild ("Main Camera");
	}
	//================================================================================================



	//================================================================================================
	//[Update]// --- Called every frame to implement game behaviour
	//================================================================================================
	void Update () {
		if (player.isHuman) {
			if (player.isInDirectMode) {
				//DIRECT CONTROL
				DirectModeMouseActivity();
				DirectModeKeysActivity ();
			} else {
				//RTS CONTROL
				RTSModeCameraMovement();
				RTSModeCameraRotation ();
				RTSModeCameraZoom ();
				RTSModeMouseActivity ();
				RTSModeKeysActivity ();
			}
		}
	}
	//================================================================================================



	//================================================================================================
	//[RTSModeCameraMovement]// --- Camera movement controls when in RTS mode
	//================================================================================================
	private void RTSModeCameraMovement () {
		
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		Vector3 cameraMoveToPosition = new Vector3 (0, 0, 0);
		float cameraMovementSpeed = GlobalVariables.CAMERA_MOVEMENT_SPEED;

		//If SHIFT key is down, move camera 4 times quicker with arrow keys, else move it at default speed
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
			cameraMovementSpeed = GlobalVariables.CAMERA_MOVEMENT_SPEED * 4;
		} else {
			cameraMovementSpeed = GlobalVariables.CAMERA_MOVEMENT_SPEED;
		}

		//Vertical camera movement
		float moveDirectionHorizontal = Input.GetAxis("Horizontal");
		float moveDirectionVertical = Input.GetAxis("Vertical");

		if (Input.GetKey (KeyCode.A)) {
			plyCamera.transform.Translate(Vector3.right * cameraMovementSpeed * moveDirectionHorizontal * Time.deltaTime);
		}else if(Input.GetKey(KeyCode.D)){
			plyCamera.transform.Translate(Vector3.left * cameraMovementSpeed * -moveDirectionHorizontal * Time.deltaTime);
		}

		//Horizontal camera movement
		if (Input.GetKey (KeyCode.W)) {
			plyCamera.transform.Translate(Vector3.forward * cameraMovementSpeed * moveDirectionVertical * Time.deltaTime);
		}else if(Input.GetKey(KeyCode.S)){
			plyCamera.transform.Translate(Vector3.back * cameraMovementSpeed * -moveDirectionVertical * Time.deltaTime);
		}


	}
	//================================================================================================



	//================================================================================================
	//[RTSModeCameraRotation]// --- Camera rotation controls when in RTS mode
	//================================================================================================
	private void RTSModeCameraRotation () {

	}
	//================================================================================================



	//================================================================================================
	//[RTSModeCameraZoom]// --- Camera zoom controls when in RTS mode
	//================================================================================================
	private void RTSModeCameraZoom () {

	}
	//================================================================================================



	//================================================================================================
	//[RTSModeMouseActivity]// --- Mouse controls when in RTS mode
	//================================================================================================
	private void RTSModeMouseActivity () {

	}
	//================================================================================================



	//================================================================================================
	//[RTSModeKeysActivity]// --- Camera movement controls when in RTS mode
	//================================================================================================
	private void RTSModeKeysActivity () {

	}
	//================================================================================================



	//================================================================================================
	//[DirectModeMouseActivity]// --- Mouse controls when in direct mode
	//================================================================================================
	private void DirectModeMouseActivity () {

	}
	//================================================================================================



	//================================================================================================
	//[DirectModeKeysActivity]// --- Camera movement controls when in direct mode
	//================================================================================================
	private void DirectModeKeysActivity () {

	}
	//================================================================================================

}
