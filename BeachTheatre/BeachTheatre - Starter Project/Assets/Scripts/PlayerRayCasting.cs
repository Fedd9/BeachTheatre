using UnityEngine; 
using System.Collections;

public class PlayerRayCasting : MonoBehaviour 
{ 
	public float distanceToSee; 
	RaycastHit whatIHit; 
	public GUISkin Gameskin; 
	public string ObjectName; 
	private Color highlightColor; 
	Material originalMaterial, tempMaterial; 
	public Renderer rend;
	bool isDetected = false;

	void Start()
	{
		highlightColor = Color.green;
	}

	// Update is called once per frame
	void Update ()
	{
		//Draws ray in scene view during playmode; the multiplication in the second parameter controls how long the line will be
		Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

		//A raycast returns a true or false value
		//we  initiate raycast through the Physics class
		//out parameter is saying take collider information of the object we hit, and push it out and 
		//store is in the what I hit variable. The variable is empty by default, but once the raycast hits
		//any collider, it's going to take the information, and store it in whatIHit variable. So then,
		//if I wanted to access something, I could access it through the whatIHit variable. 

		if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee))
		{                        
			rend = whatIHit.collider.gameObject.GetComponent<Renderer>();             
			Debug.Log("I touched the " + whatIHit.collider.gameObject.name);
			if(!rend)
			{
				return;
			}

			originalMaterial = rend.sharedMaterial;

			tempMaterial = new Material(originalMaterial);
			tempMaterial.color = highlightColor;
			rend.material = tempMaterial;

		} else {
			rend.sharedMaterial = originalMaterial;
			rend = null;
		}
	}
}