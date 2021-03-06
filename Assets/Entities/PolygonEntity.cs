﻿using UnityEngine;
using System.Collections;

public abstract class PolygonEntity : Entity {

	public const float sidelength = 0.4f;//theoretically 1/(1+sqrt(2))

	public int sides;//assign in inspector or in instantiation script
	public float area;

	public float inradius;
	public float circumradius;
	public float radius;

	public float force;
	public float torque;

	// Use this for initialization
	protected override void Start () {
		base.Start();

		area = Area(sides, sidelength);
		GetComponent<Rigidbody2D>().mass = area;

		inradius = InRadius(sides, sidelength);
		circumradius = CircumRadius(sides, sidelength);
		radius = Mathf.Sqrt(2*GetComponent<Rigidbody2D>().inertia/GetComponent<Rigidbody2D>().mass);

		force = GetComponent<Rigidbody2D>().mass * 25f;//pi*r*r * 25
		torque = GetComponent<Rigidbody2D>().inertia * 50f;//0.5*pi*r*r*r*r * 50 = F*r*r, but should be T = F*r
											//the inconsistency is:
											//angular acceleration decreases as the Force distance increases
												//e.g. Torque increases, but moment of inertia increases squared
											//however, the Force increases squared as the radius increases
	}

	public static float InRadius (int sides, float sidelength) {//Apothem
		return 0.5f * sidelength / Mathf.Tan(Mathf.PI / sides);//0.68819f * 0.41f if sides = 5
	}
	public static float CircumRadius (int sides, float sidelength) {//Radius
		return 0.5f * sidelength / Mathf.Sin(Mathf.PI / sides);//0.85065f * 0.41f if sides = 5
	}
	public static float Area (int sides, float sidelength) {//can also be in terms of the number of sides and the Apothem
		//1/2 * apothem * perimeter
		return 0.25f * sidelength * sidelength * sides / Mathf.Tan(Mathf.PI / sides);//1.705f if sides = 5
	}
}
