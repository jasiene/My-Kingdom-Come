using UnityEngine;
using System.Collections;

public class SingletonRepository : MonoBehaviour{

	//================================================================================================
	//[SingletonRepository Variables]//
	//================================================================================================
	public Material PROJECTOR_CIRCLE;
	public Material PROJECTOR_SQUARE;

	[HideInInspector] public Texture2D TEXTURE2D_RED;
	[HideInInspector] public Texture2D TEXTURE2D_GREEN;
	[HideInInspector] public Texture2D TEXTURE2D_BLUE;
	[HideInInspector] public Texture2D TEXTURE2D_BLACK;
	[HideInInspector] public Texture2D TEXTURE2D_WHITE;

	public GameObject[] ENTITIES;
	//================================================================================================



	//================================================================================================
	//[Awake]// --- Called before Start, used to initialise variables before game
	//================================================================================================
	protected void Awake () {
		
	}
	//================================================================================================



	//================================================================================================
	//[Start]// --- Called before Update, used to pass any information after all initialisation
	//================================================================================================
	protected void Start () {

		TEXTURE2D_RED = new Texture2D (1, 1);
		TEXTURE2D_RED.SetPixel (0, 0, Color.red);
		TEXTURE2D_RED.Apply ();

		TEXTURE2D_GREEN = new Texture2D (1, 1);
		TEXTURE2D_GREEN.SetPixel (0, 0, Color.green);
		TEXTURE2D_GREEN.Apply ();

		TEXTURE2D_BLUE = new Texture2D (1, 1);
		TEXTURE2D_BLUE.SetPixel (0, 0, Color.blue);
		TEXTURE2D_BLUE.Apply ();

		TEXTURE2D_BLACK = new Texture2D (1, 1);
		TEXTURE2D_BLACK.SetPixel (0, 0, Color.black);
		TEXTURE2D_BLACK.Apply ();

		TEXTURE2D_WHITE = new Texture2D (1, 1);
		TEXTURE2D_WHITE.SetPixel (0, 0, Color.white);
		TEXTURE2D_WHITE.Apply ();

	}
	//================================================================================================



	//================================================================================================
	//[Update]// --- Called every frame to implement game behaviour
	//================================================================================================
	protected void Update () {
		
	}
	//================================================================================================



	//================================================================================================
	//[GetEntity]// --- 
	//================================================================================================
	public Entity GetEntity(string name){
		foreach (GameObject entity in ENTITIES) {
			Entity ent = entity.GetComponent<Entity> ();
			if (ent && ent.entName.Equals (name)) {
				return ent;
			}
		}
		return null;
	}
	//================================================================================================



	//================================================================================================
	//[GetEntityImage]// --- 
	//================================================================================================
	public Texture2D GetEntityImage(string name){
		foreach (GameObject entity in ENTITIES) {
			Entity ent = entity.GetComponent<Entity> ();
			if (ent && ent.entName.Equals (name)) {
				return ent.image;
			}
		}
		return null;
	}
	//================================================================================================

}
