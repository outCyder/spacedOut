using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;

public class MainWeapon : Weapon
{
    public Bullet bullet;
    public float speed = 1.0f;
    public int fireRate = 20;
    private int shootPause = 0;
    private bool didShot = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (didShot)
        {
            shootPause--;
        }

        if (this.shootPause <= 0)
        {
            didShot = false;

            if (Input.GetMouseButton(0))
            {
                var bulletClone = Instantiate(bullet, this.transform.position, this.transform.rotation);
                var rb = bulletClone.GetComponent<Rigidbody>();
                rb.velocity = this.transform.forward * this.speed;
                Destroy(bulletClone.gameObject, 1);
                shootPause = fireRate;
                didShot = true;
            }
        }
		
	}
}
