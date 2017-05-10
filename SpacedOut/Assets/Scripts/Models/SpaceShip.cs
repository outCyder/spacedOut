using UnityEngine;

namespace Models
{
    public abstract class SpaceShip : MonoBehaviour
    {
        public int HP;
        [Range(0, 2)]
        public float speed;
        public Weapon[] weapons;
    }
}
