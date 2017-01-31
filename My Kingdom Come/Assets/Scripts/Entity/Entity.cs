using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity : MonoBehaviour {

	//================================================================================================
	//[Entity Variables]//
	//================================================================================================
	public string entName;
	public string displayName;
	public string description;

	public float baseHealth;
	public float curHealth;

	public bool isSelected;

	public Texture2D image;

	private Projector projector;

	public Player player;

	public List<Action> performableActions;
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
		
		player = transform.root.GetComponent<Player> ();

		projector = transform.FindChild ("Projection").GetComponentInChildren<Projector> ();

		performableActions = new List<Action> ();

		if (transform.GetComponentInParent<UnitsManager> () != null) {
			Player ply = transform.GetComponentInParent<UnitsManager> ().GetComponentInParent<Player> ();
			projector.material = ply.materialCircle;
		} else if (transform.GetComponentInParent<StructuresManager> () != null) {
			Player ply = transform.GetComponentInParent<StructuresManager> ().GetComponentInParent<Player> ();
			projector.material = ply.materialSquare;
		}

	}
	//================================================================================================



	//================================================================================================
	//[Update]// --- Called every frame to implement game behaviour
	//================================================================================================
	protected virtual void Update () {

	}
	//================================================================================================


	//================================================================================================
	//[ChangeSelection]// --- Select or deselect an entity based upon whether it already is selected
	//================================================================================================
	public void ChangeSelection (Player plyWhoPressed, bool alterPlayerSelectedEntities) {
		projector.enabled = !projector.enabled;
		isSelected = !isSelected;
		if (alterPlayerSelectedEntities) {
			if (isSelected) {
				plyWhoPressed.selectedEntities.Add (this.GetInstanceID (), this);
			} else {
				plyWhoPressed.selectedEntities.Remove (this.GetInstanceID ());
			}
		}
	}
	//================================================================================================


	//================================================================================================
	//[ChangeSelection]// --- Specify selection state of entity
	//================================================================================================
	public void ChangeSelection (Player plyWhoPressed, bool alterPlayerSelectedEntities, bool setBool) {
		projector.enabled = setBool;
		isSelected = setBool;
		if (alterPlayerSelectedEntities) {
			if (isSelected) {
				plyWhoPressed.selectedEntities.Add (this.GetInstanceID (), this);
			} else {
				plyWhoPressed.selectedEntities.Remove (this.GetInstanceID ());
			}
		}
	}
	//================================================================================================


	//================================================================================================
	//[IsOwnedBy]// --- Check who the entity is owned by
	//================================================================================================
	public bool IsOwnedBy (Player ply) {
		if (player && player.Equals (ply)) {
			return true;
		} else {
			return false;
		}
	}
	//================================================================================================

}
