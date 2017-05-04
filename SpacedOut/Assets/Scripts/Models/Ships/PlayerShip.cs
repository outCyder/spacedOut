using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {

    [Range(0, 20)]
    public int speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            var target = new Vector3(Input.mousePosition.x - 540, 0, 0);
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, this.speed * Time.deltaTime);
            if (target.x > 0)
            {
                this.transform.Rotate(Vector3.forward * -this.speed * Time.deltaTime);
            }
            else
            {
                this.transform.Rotate(Vector3.forward * this.speed * Time.deltaTime);
            }
        }
    }
}