﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class cannonShooter : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private GameObject netPrefab;
    [SerializeField] private Camera cameraShooter;
    [SerializeField] private bool isDragging = false;

    public float springRate;
    public float maxForce;
    public float thresholdDis = 0.1f;
    private Vector3 forceGenerated;

    private Rigidbody2D rbShooter;
    private Collider2D rbcollider;

    // Update is called once per frame
    void Start()
    {
        rbShooter = GetComponent<Rigidbody2D>();
        rbShooter.bodyType = RigidbodyType2D.Static;
        
    }
    private void FixedUpdate()
    {
        if(Input.touchCount > 0 )
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                rbcollider = GetComponent<Collider2D>();
                rbShooter = GetComponent<Rigidbody2D>();
                rbShooter.bodyType = RigidbodyType2D.Static;
                Debug.Log("antes");
                Vector3 pos = cameraShooter.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                if (hit.collider.tag == "shooter")
                {
                    Debug.Log("llega");
                    OnMouseDrag();
                }
                
            }
        }
    }
    private void OnMouseDrag()
    {
        isDragging = true;
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
        forceGenerated = transform.position - pivot.position;
        float forceMagnitud = -forceGenerated.magnitude * maxForce / springRate;
        rbShooter.transform.position = pivot.position;
        if (forceGenerated.magnitude > thresholdDis && isDragging)
        {
            GameObject net = Instantiate(netPrefab, transform.position, Quaternion.identity);
            Rigidbody2D netRb = net.GetComponent<Rigidbody2D>();
            netRb.AddForce(forceGenerated.normalized * forceMagnitud);
        }
        isDragging = false;
    }
}
