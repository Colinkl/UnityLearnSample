using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.LearnMaterials_2.Scripts
{
    public class InteractiveRaycast : MonoBehaviour
    {
        public GameObject gameObj;
        private InteractiveBox box;

        private void LeftButtonAction()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("InteractivePlane"))
                {
                    Instantiate(gameObj, hit.point + hit.normal * 0.5f, Quaternion.identity);
                }
                if (hit.collider.CompareTag("InteractiveBox"))
                {
                    InteractiveBox tempBox = hit.collider.GetComponent<InteractiveBox>();

                    if (tempBox == null)
                        return;

                    if (box == null)
                    {
                        box = tempBox;
                    }
                    else
                    {
                        box.AddNext(tempBox);
                    }
                }
            }
        }

        private void RightButtonAction()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("InteractiveBox"))
                {
                    Destroy(hit.transform.parent.gameObject);
                }
            }
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                LeftButtonAction();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                RightButtonAction();
            }
        }

    }
}
