using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class netController : MonoBehaviour
{

    public netPrefab net;
    private float elapsedTime;

    public Animator closeAnimation;
    public Sprite closeNetSprite;


    // Start is called before the first frame update
    void Update()
    {
        if (!net.close) //Chequea que la red esté abierta, en caso de estar cerrada deja de correr estas opciones.
            closeNet();
    }
    private void closeNet()
    {
        elapsedTime += Time.deltaTime;  //Inicia un contador y cada vez que lo llama arranca a contar. 
        if (elapsedTime >= net.measurementTimeInAir*2) //Cuando el tiempo de contador, seá mayor al tiempo minimo entonces ejecuta
        {
            if(net.recyclesCatch.Count > 0) //Si capturó botellas entonces se cierra
            {
                net.close = true; //la red pasa a estar en estado cerrado
                closeAnimation.SetBool("Close", net.close); //cambia una bariable para indicar que tienen que cambiar el sprite
                net.gameObject.GetComponent<SpriteRenderer>().sprite = closeNetSprite; //cambia el sprite
            }
            else //Si no encuentra botellas se destruye
                Destroy(gameObject);
        }
    }
}
