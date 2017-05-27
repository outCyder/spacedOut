using UnityEngine;

namespace Models
{
    public abstract class SpaceShip : MonoBehaviour
    {
        public int HP;
        [Range(0, 5)]
        public float speed;
        public Weapon[] weapons;
    }
}
