using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class netPrefab : MonoBehaviour
{
    private Rigidbody2D rb;

    public float measurementTimeInAir = 0.25f;
    [SerializeField] private float catchRaduis;

    public float netWeight;
    public bool close = false;
    public List<recycles> recyclesCatch;
    private float elapsedTime= 0;
    Collider2D[] catchRecycles;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        recyclesCatch = new List<recycles>();;
    }
    private void Update()
    {
        if (!close)
            OnCanvasGroupChanged();
    }
    private void OnMouseDown()
    {
        if (close)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.gameObject.GetComponent<Collider2D>().isTrigger = false;
            GameObject weighingMachine = GameObject.FindGameObjectWithTag("weighingMachine");
            transform.position = weighingMachine.transform.position;
        }
    }
    private void OnCanvasGroupChanged()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > measurementTimeInAir)
        {
            catchRecycles = Physics2D.OverlapCircleAll(transform.position, catchRaduis);
            if(catchRecycles != null)
            {
                foreach (Collider2D re in catchRecycles)
                {
                    if (re.CompareTag("recycle"))
                    {
                        recyclesCatch.Add(re.GetComponent<recycles>());
                        Destroy(re.gameObject.GetComponent<Renderer>());
                        Destroy(re.gameObject.GetComponent<Collider2D>());
                        Destroy(re.gameObject.GetComponent<Rigidbody2D>());
                    }
                }
            }
            CalculateWeight();
        }
    }
    private void CalculateWeight()
    {
        netWeight = 0;
        foreach (recycles re in recyclesCatch)
        {
            netWeight = netWeight + re.weight;
        }
    }
}

