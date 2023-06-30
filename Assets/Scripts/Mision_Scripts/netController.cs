using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class netController : MonoBehaviour
{
    private bool close = false;
    public Collider2D netCollider;
    private Rigidbody2D rb;
    private float closeSpeed = 0.1f;
    private float measurementTimeSpeed = 1f;
    private float elapsedTime;

    public List<recycles> recyclesCatch;
    public float netSize;
    public float netCloseSize;
    public LayerMask water;
    public Animator closeAnimation;
    public Sprite closeNetSprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        netCollider = GetComponent<Collider2D>();
        netCollider.transform.localScale = new Vector3(netSize, netSize, 1f);
        recyclesCatch = new List<recycles>();
        elapsedTime = 0f;
    }
    void Update()
    {
        if (!close)
        {
            closeNet();
        }
        foreach (recycles re in recyclesCatch)
        {
            re.transform.position = transform.position;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!close)
        {
            if (collision.gameObject.CompareTag("recycle"))
            {
                recyclesCatch.Add(collision.gameObject.GetComponent<recycles>());
            }
        }

    }
    private void OnMouseDown()
    {
        if (close)
        {
            GameObject weighingMachine = GameObject.FindGameObjectWithTag("weighingMachine");
            transform.position = weighingMachine.transform.position;
        }
    }
    private void closeNet()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= measurementTimeSpeed)
        {
            if (rb.velocity.magnitude < closeSpeed)
            {
                GetComponent<Collider2D>().isTrigger = true;
                close = true;
                closeAnimation.SetBool("Close", close);
                this.gameObject.GetComponent<SpriteRenderer>().sprite = closeNetSprite;
            }
        }
    }
    /*private void OnMouseDrag()
    {
        if(close)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);
        }
    }*/
}
