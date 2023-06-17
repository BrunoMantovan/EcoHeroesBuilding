using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class cannonShooterController : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private GameObject netPrefab;
    [SerializeField] private Camera cameraShooter;
    [SerializeField] private bool isDragging = true;

    public float springRate;
    public float maxForce;
    public float thresholdDis = 0.1f;
    
    private Vector3 forceGenerated;
    private cannonNetCreatorController creator;
    private Rigidbody2D rbShooter;
    private Collider2D rbcollider;

    // Update is called once per frame
    void Start()
    {
        rbShooter = GetComponent<Rigidbody2D>();
        rbShooter.bodyType = RigidbodyType2D.Static;
    }
    /*private void FixedUpdate()
    {
        if(Input.touchCount > 0 )
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                rbcollider = GetComponent<Collider2D>();
                rbShooter = GetComponent<Rigidbody2D>();
                rbShooter.bodyType = RigidbodyType2D.Static;
                Vector3 pos = cameraShooter.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                if (hit.collider.tag == "shooter")
                {
                    OnMouseDrag();
                }
            }
        }
    }*/
    private void OnMouseDrag()
    {
        if (isDragging)
            return;
        Vector3 pos = cameraShooter.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shooterCharge = pos - pivot.position;
        shooterCharge.z = 0;
        if (shooterCharge.magnitude > springRate)
        {
            shooterCharge = shooterCharge.normalized * springRate;
        }
        rbShooter.transform.position = pivot.position + shooterCharge;
    }

    private void OnMouseUp()
    {
        if (isDragging)
            return;
        isDragging = false;
        forceGenerated = transform.position - pivot.position;
        float forceMagnitud = -forceGenerated.magnitude * maxForce / springRate;
        rbShooter.transform.position = pivot.position;
        Vector2 force = forceGenerated.normalized * forceMagnitud;
        if (forceGenerated.magnitude > thresholdDis && !isDragging)
        {
            GameObject net = Instantiate(netPrefab, transform.position, Quaternion.identity);
            Rigidbody2D netRb = net.GetComponent<Rigidbody2D>();
            netRb.AddForce(force);
            //creator.GenerateNet(force);
        }
    }
}
