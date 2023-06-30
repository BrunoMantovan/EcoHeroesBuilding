using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class netAnimator : MonoBehaviour
{
    Rigidbody rb;
    private float rotationSpeed = 500;

    public float maxSize = 2f;
    public float growingRate = 0.5f;

    bool maxSizeReached = false;

    float catchSizeX;
    float catchSizeY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.Rotate(0, 0, Random.Range(0,360));
        catchSizeX = transform.localScale.x;
        catchSizeY = transform.localScale.y;
        transform.localScale = new Vector2(0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!maxSizeReached)
        {
            SizeGrow(); 
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime); //Esto hace que la red gire
        }
        else
            SizeShrink();
    }
    void SizeGrow()
    {
        float sizeX = transform.localScale.x;
        float sizeY = transform.localScale.y;

        sizeX += growingRate * Time.deltaTime;
        sizeY += growingRate * Time.deltaTime;

        if (sizeX >= maxSize && sizeY >= maxSize)
        {
            sizeX = maxSize;
            sizeY = maxSize;
            maxSizeReached = true;
        }
        transform.localScale = new Vector2(sizeX, sizeY);
    }
    void SizeShrink()
    {
        float sizeX = transform.localScale.x;
        float sizeY = transform.localScale.y;

        sizeX -= growingRate * Time.deltaTime;
        sizeY -= growingRate * Time.deltaTime;

        if (sizeX <= catchSizeX && sizeY <= catchSizeY)
        {
            sizeX = catchSizeX;
            sizeY = catchSizeY;
        }
        transform.localScale = new Vector2(sizeX, sizeY);
    }
}
