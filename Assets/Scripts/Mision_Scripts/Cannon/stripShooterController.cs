using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stripShooterController : MonoBehaviour
{
    public LineRenderer lineRenderers0;
    public LineRenderer lineRenderers1;
    public Transform center0;
    public Transform center1;


    void Start()
    {
        lineRenderers0.positionCount = 2;
        lineRenderers1.positionCount = 2;
        lineRenderers0.SetPosition(0, new Vector3(transform.position.x + 0,0001, transform.position.y + transform.position.z));
        lineRenderers1.SetPosition(0, new Vector3(transform.position.x - 0,0001, transform.position.y + transform.position.z));

    }
    void Update()
    {
        SetStrips(center0.position);
        SetStrips(center1.position);
    }
    void SetStrips(Vector3 position)
    {
        lineRenderers0.SetPosition(1, position);
        lineRenderers1.SetPosition(1, position);
    }
}
