using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonController : MonoBehaviour
{
    public Vector3 objetive;
    [SerializeField] private Camera cameraCannon;
    // Update is called once per frame
    void Update()
    {
        rotateCamera();
    }

    private void rotateCamera()
    {
        objetive = cameraCannon.ScreenToWorldPoint(Input.mousePosition);
        float radiansAngle = Mathf.Atan2(objetive.y - transform.position.y, objetive.x - transform.position.x);
        float gradesAngle = (180 / Mathf.PI) * radiansAngle - 90;
        transform.rotation = Quaternion.Euler(0, 0, gradesAngle);
    }
}
