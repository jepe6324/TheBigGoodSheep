using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

	public float scroll_speed = 0.1f;

	private SpriteRenderer sprite_renderer;

	// Use this for initialization
	void Start () {

		sprite_renderer = GetComponent<SpriteRenderer> ();

	}

	// Update is called once per frame
	void Update () {

		float x = Time.time * scroll_speed;

		Vector2 offset = new Vector2 (x, 0);

		sprite_renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);

	}
}
