using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class netController : MonoBehaviour
{

    public netPrefab net;
    private float closeSpeed = 0.1f;
    private float measurementTimeSpeed = 1f;
    private float elapsedTime;

    // Start is called before the first frame update
    void Update()
    {
        if (!net.close)
        {
            closeNet();
        }
    }


    private void closeNet()
    {

        elapsedTime += Time.deltaTime;
        if (elapsedTime >= measurementTimeSpeed)
        {
            if (net.GetComponent<Rigidbody2D>().velocity.magnitude < closeSpeed)
            {
                if(net.recyclesCatch.Count > 0)
                {
                    net.close = true;
                    net.closeAnimation.SetBool("Close", net.close);
                    net.gameObject.GetComponent<SpriteRenderer>().sprite = net.closeNetSprite;
                }
                else 
                {
                    Destroy(net.gameObject);
                }
            }
        }
        //net.GetComponent<Collider2D>().isTrigger = true;
    }
}
