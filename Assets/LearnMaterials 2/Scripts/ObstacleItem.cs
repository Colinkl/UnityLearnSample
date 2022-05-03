using UnityEngine;
using UnityEngine.Events;

namespace Assets.LearnMaterials_2.Scripts
{
    public class ObstacleItem : MonoBehaviour
    {
        [Range(0, 1f)]
        private float health = 1;
        public UnityEvent onDestroyObstacle;

        public void GetDamage(float value)
        {
            health -= value;
            if (health <= 0)
            {
                onDestroyObstacle.Invoke();
                Destroy(gameObject);

            }

            gameObject.GetComponent<Renderer>().material.color = new Color(1, health, health);
        }

    }
}
