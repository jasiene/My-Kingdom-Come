using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Structure : Entity{

	//================================================================================================
	//[Structure Variables]//
	//================================================================================================
	public Queue<Action> actionQueue;
	public Action currentAction;
	public int maxActionsInQueue;

	public float currentActionProgress = 0.0f;
	public float currentActionLength = 0.0f;
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
		actionQueue = new Queue<Action> ();
	}
	//================================================================================================



	//================================================================================================
	//[Update]// --- Called every frame to implement game behaviour
	//================================================================================================
	protected override void Update () {
		base.Update ();
		UpdateQueue ();
	}
	//================================================================================================



	//================================================================================================
	//[AddActionToQueue]// ---
	//================================================================================================
	public void AddActionToQueue (Action action) {
		actionQueue.Enqueue (action);
		currentAction = action;
		currentActionLength = currentAction.GetActionLength ();
	}
	//================================================================================================



	//================================================================================================
	//[UpdateQueue]// ---
	//================================================================================================
	protected void UpdateQueue () {
		if (actionQueue.Count > 0) {
			currentActionProgress += Time.deltaTime * 2f;
			if (currentActionProgress > currentActionLength) {
				Action finishedAction = actionQueue.Dequeue ();
				finishedAction.PerformAction ();
				currentActionProgress = 0.0f;
			}
		}
	}
	//================================================================================================

}
