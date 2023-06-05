using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonNetCreatorController : MonoBehaviour
{
    [SerializeField] private GameObject netPrefab;
    public void GenerateNet(Vector2 force)
    {
        GameObject net = Instantiate(netPrefab, transform.position, Quaternion.identity);
        Rigidbody2D netRb = net.GetComponent<Rigidbody2D>();
        netRb.AddForce(force);
    }
}
