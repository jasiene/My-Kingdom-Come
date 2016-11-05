using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	//================================================================================================
	//[Entity Variables]//
	//================================================================================================
	public string entName;
	public string displayName;

	public float baseHealth;
	public float curHealth;

	public bool isSelected;

	public Texture2D image;

	private Projector projector;
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
		projector = transform.FindChild ("Projection").GetComponentInChildren<Projector> ();
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
	//[ChangeSelection]//
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
	//[ChangeSelection]//
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

}
