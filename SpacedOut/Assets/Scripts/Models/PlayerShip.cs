using UnityEngine;
using Models;

public class PlayerShip : SpaceShip
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hit = new RaycastHit();
            Debug.DrawRay(ray.origin, ray.direction * Camera.main.transform.position.y * 2, Color.blue);

            if (Physics.Raycast(ray, out hit))
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, hit.point, this.speed);

                var horizontalAngle = (hit.point.x - this.transform.position.x) * -10;
                if (hit.point.x < this.transform.position.x)
                {
                    if (horizontalAngle > 30)
                    {
                        horizontalAngle = 30;
                    }
                }
                else if (hit.point.x > this.transform.position.x)
                {
                    if (horizontalAngle < -30)
                    {
                        horizontalAngle = -30;
                    }
                }
                else
                {
                    horizontalAngle = 0;
                }

                var verticalAngle = (hit.point.z - this.transform.position.z) * 10;
                if (hit.point.z < this.transform.position.z)
                {
                    if (verticalAngle < -30)
                    {
                        verticalAngle = -30;
                    }
                }
                else if (hit.point.z > this.transform.position.z)
                {
                    if (verticalAngle > 30)
                    {
                        verticalAngle = 30;
                    }
                }
                else
                {
                    verticalAngle = 0;
                }
                this.transform.localEulerAngles = new Vector3(verticalAngle, 0, horizontalAngle);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
}
