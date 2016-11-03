using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	//================================================================================================
	//[Entity Variables]//
	//================================================================================================
	public string entName;
	public bool isSelected;

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
		if (transform.GetComponentInParent<UnitsManager> ().GetComponentInParent<Player> () != null) {
			Player ply = transform.GetComponentInParent<UnitsManager> ().GetComponentInParent<Player> ();
			projector.material.color = ply.color;
		} else if (transform.GetComponentInParent<StructuresManager> ().GetComponentInParent<Player> () != null) {
			Player ply = transform.GetComponentInParent<StructuresManager> ().GetComponentInParent<Player> ();
			projector.material.color = ply.color;
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
	//[UpdateSelection]//
	//================================================================================================
	public void ChangeSelection () {
		projector.enabled = !projector.enabled;
		isSelected = !isSelected;
	}
	//================================================================================================

}
