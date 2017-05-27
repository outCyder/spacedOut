using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    private int spawnPause = 0;
    private int enemyCount = 0;
    private float movementSpeed = 0.1f;
    public Enemy enemy;
    public int spawnTime = 60;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.position += new Vector3(movementSpeed, 0, 0);

        if (spawnPause <= 0)
        {
            var enemyClone = Instantiate(enemy, this.transform.position, new Quaternion(0, 180, 0, 0));
            Destroy(enemyClone.gameObject, 20);
            spawnPause = spawnTime;
            enemyCount++;
        }

        if (enemyCount == 2)
        {
            enemyCount = 0;
            movementSpeed *= -1;
        }

        spawnPause--;
	}
}
