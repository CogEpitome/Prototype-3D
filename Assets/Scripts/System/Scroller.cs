using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Jonas Iacobi (12:40 23-10-2017)
 * This class gives the illusion of movement by offsetting an object's texture along the z axis.
 * Intended for objects representing ground, such as the lava flow.
*/
public class Scroller : MonoBehaviour {

	public float scrollSpeed;	//The speed at which to offset the texture. Greater speed imitates faster movement.

	private Renderer rend;		//A reference to the texture renderer.
	private Vector2 offset;		//The texture offset.

	void Start() //Initialize
	{
		rend = GetComponent<Renderer> ();
		offset = new Vector2 (0.0f, 0.0f);
	}

	//Increase the offset by scrollSpeed and update the material's texure offset to reflect the change.
	void LateUpdate() 
	{
		offset.y += scrollSpeed * Time.fixedDeltaTime;
		rend.material.SetTextureOffset ("_MainTex", offset);
	}
}
