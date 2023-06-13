using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class netPrefab : MonoBehaviour
{
    
    private Rigidbody2D rb;

    public float netWeight;
    public bool close = false;
    public List<recycles> recyclesCatch;
    public float netSize;
    public float netCloseSize;
    public Animator closeAnimation;
    public Sprite closeNetSprite;
    public float timeShoot; 
    private bool canTrigger = true;
    private float measurementTimeSpeed = 0.45f;
    private float elapsedTime= 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.transform.localScale = new Vector3(netSize, netSize, 1f);
        recyclesCatch = new List<recycles>();
        elapsedTime += Time.deltaTime;
    }
    private void Update()
    {
        if (!close) elapsedTime += Time.deltaTime;
    }
    private void OnMouseDown()
    {
        if (close && canTrigger)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.gameObject.GetComponent<Collider2D>().isTrigger = false;
            GameObject weighingMachine = GameObject.FindGameObjectWithTag("weighingMachine");
            transform.position = weighingMachine.transform.position;
            canTrigger = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (elapsedTime > measurementTimeSpeed)
        {

            Debug.Log("+++++++"+measurementTimeSpeed);
            if (!close)
            {
                if (collision.gameObject.CompareTag("recycle"))
                {
                    recyclesCatch.Add(collision.gameObject.GetComponent<recycles>());
                    collision.gameObject.transform.position = transform.position;
                    netWeight = netWeight + collision.gameObject.GetComponent<recycles>().weight;
                    Destroy(collision.gameObject, Time.deltaTime * 3f);
                }
            }
            else if (close)
            {
                if (collision.gameObject.CompareTag("nets"))
                {
                    collision.gameObject.GetComponent<netPrefab>().recyclesCatch = recyclesCatch;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}

