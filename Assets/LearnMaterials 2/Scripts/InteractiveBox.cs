using UnityEngine;
using UnityEngine.Events;

namespace Assets.LearnMaterials_2.Scripts
{
    public class InteractiveBox : MonoBehaviour
    {
        [SerializeField]
        private InteractiveBox nextItem;

        public void AddNext(InteractiveBox nextBox)
        {
            if (nextBox != null)
                nextItem = nextBox;
        }

        void Update()
        {
            if (nextItem == null)
                return;

            RaycastHit hit;

            Vector3 direction = nextItem.transform.position - transform.position;

            if (Physics.Raycast(transform.position, direction, out hit))
            {
                hit.transform.GetComponent<ObstacleItem>()?.GetDamage(Time.deltaTime);
            }
            Debug.DrawRay(transform.position, direction, Color.red);
        }
    }
}
