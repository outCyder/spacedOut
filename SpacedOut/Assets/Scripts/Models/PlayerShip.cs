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
        if (this.HP <= 0)
        {
            this.transform.Rotate(new Vector3(0, 0, 10));
            var currPos = this.transform.position;
            this.transform.position = Vector3.MoveTowards(currPos, new Vector3(currPos.x, currPos.y - 0.1f, currPos.z), 10);
        }
        else
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
                    this.transform.localEulerAngles = new Vector3(verticalAngle - 90, 0, horizontalAngle);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                this.transform.localEulerAngles = new Vector3(-90, 0, 0);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            this.HP -= 20;
        }
    }
}
