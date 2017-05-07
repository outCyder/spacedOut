using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;

public class PlayerShip : SpaceShip
{

    private float yPosition = 0;
    private float modifier;

	// Use this for initialization
	void Start ()
    {
        this.modifier = Camera.main.transform.position.z;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            var mousePostion = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            var target = new Vector3(mousePostion.x * this.modifier, this.yPosition, mousePostion.y * this.modifier);
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, this.speed);
            //this.transform.position = new Vector3(target.x, this.distance, target.y);
        }
    }
}