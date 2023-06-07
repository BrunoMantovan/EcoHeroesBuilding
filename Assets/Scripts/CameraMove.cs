using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [SerializeField]
    Camera mainCamera;

    Vector3 dragOrigin;
    void Update()
    {
        CameraDrag();
    }

    void CameraDrag()
    {
        if (Input.GetMouseButton(0))
        {
            dragOrigin = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - mainCamera.ScreenToWorldPoint(Input.mousePosition);
            print("origin" + dragOrigin + "new position" + mainCamera.ScreenToWorldPoint(Input.mousePosition) + "difference" + difference);
            mainCamera.transform.position += difference;
        }
    }

}
