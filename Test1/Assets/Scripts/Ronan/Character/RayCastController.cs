﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles all raycasts for the player
public class RayCastController : MonoBehaviour {

	public GameObject[] Rays;
	public GameObject RayHolder;
	public Pounce pnce;

	public TestLevel TL;

	public bool attachRight,attachLeft,attachTop,attachBottom;

	// Use this for initialization
	void Start () {
		pnce = gameObject.GetComponent<Pounce> ();
		TL =GameObject.Find ("GameManager").GetComponent<TestLevel> ();
	}
	
	// Update is called once per frame
	void Update () {
		List<RaycastHit2D> hits =CreateRay ();
	}

	//raycasts to find walls
	//returns all raycasthits
	List<RaycastHit2D> CreateRay()
	{
		if (Rays != null) {

			List<RaycastHit2D> hits = new List<RaycastHit2D>();

			foreach (GameObject ray in Rays) {
				string _name = ray.name;

				if(_name.Contains("Left"))
				{
					RaycastHit2D _hit = Physics2D.Raycast (ray.transform.position, Vector2.left,0.3f);
					hits.Add (_hit);
					if (_hit.transform != null && _hit.transform.tag == "Environment") {
						//print (_hit.transform.gameObject);
						attachLeft = true;
					} else {
						attachLeft = false;
					}
				}
				if(_name.Contains("Right"))
				{
					RaycastHit2D _hit = Physics2D.Raycast (ray.transform.position, Vector2.right,0.3f);
					hits.Add (_hit);
					if (_hit.transform != null && _hit.transform.tag == "Environment" ) {
						//print (_hit.transform.gameObject);
						attachRight = true;
					}
					else {
						attachRight = false;
					}
				}
				if(_name.Contains("Top"))
				{
					RaycastHit2D _hit = Physics2D.Raycast (ray.transform.position, Vector2.up,0.3f);
					hits.Add (_hit);
					if (_hit.transform != null && _hit.transform.tag == "Environment" ) {
						//print (_hit.transform.gameObject);
						attachTop = true;
					}
					else {
						attachTop = false;
					}
				}
				if(_name.Contains("Bottom"))
				{
					RaycastHit2D _hit = Physics2D.Raycast (ray.transform.position, Vector2.down,0.3f);
					hits.Add (_hit);
					if (_hit.transform != null && _hit.transform.tag == "Environment" ) {
						//print (_hit.transform.gameObject);
						attachBottom = true;
					}
					else {
						attachBottom = false;
					}
				}
			}

			return hits;


		}
		return null;
	}

	//turns raycast holder right
	public void TurnRight()
	{
		RayHolder.transform.Rotate (0, 0, 90f);
		print("turned right");
	}
	//turns raycast holder left
	public void TurnLeft()
	{
		RayHolder.transform.Rotate (0, 0, -90f);
		print ("turned left");
	}
}
