using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public GameManager manager;

    public int targetID;

    public Vector3 highlightScale;
    Vector3 defaultScale;

    void Start()
    {
        if (manager == null)
        {
            manager = GameObject.FindAnyObjectByType<GameManager>();
        }

        /*if (targetImage == null)
        {
            targetImage = GetComponent<RawImage>();
        }*/

        //targetImage.material.color = defaultCol;
        defaultScale = transform.localScale;
    }

    void Update()
    {
        if (manager.timerActive)
        {
            if (IsMouseOverTarget())
            {
                //targetImage.material.color = highlightCol;
                Vector3 temp = defaultScale + highlightScale;

                if (transform.localScale != temp)
                {
                    transform.localScale = temp;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    if (manager.targets.Count == 0)
                    {
                        manager.targets.Add(this);
                        manager.UpdateTargetCounter();
                    }
                    else
                    {
                        if (!manager.targets.Contains(this))
                        {
                            manager.targets.Add(this);
                            manager.UpdateTargetCounter();
                        }
                    }
                }
            }
            else
            {
                //targetImage.material.color = defaultCol;
                transform.localScale = defaultScale;
            }
        }
    }

    bool IsMouseOverTarget()
    {
        //return EventSystem.current.IsPointerOverGameObject();

        //-----------------------------

        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultsList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultsList);

        for (int i = 0; i < raycastResultsList.Count; i++)
        {
            if (!raycastResultsList[i].gameObject.GetComponent<Target>())
            {
                raycastResultsList.RemoveAt(i);
                i--;
            }
            else if (raycastResultsList[i].gameObject.GetComponent<Target>())
            {
                Target temp = raycastResultsList[i].gameObject.GetComponent<Target>();

                if (temp.targetID != targetID)
                {
                    raycastResultsList.RemoveAt(i);
                    i--;
                }
            }


        }

        return raycastResultsList.Count > 0;
    }
}
