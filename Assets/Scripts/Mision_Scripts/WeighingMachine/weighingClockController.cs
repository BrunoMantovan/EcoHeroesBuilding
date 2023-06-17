using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class weighingClockController : MonoBehaviour
{
    public weighingMachine weighingMachine;
    public TMPro.TextMeshProUGUI currentLoadText;
    private float currentLoad;
    // Update is called once per frame
    void Update()
    {
        currentLoad = weighingMachine.totalWeight;
        currentLoadText.text = currentLoad.ToString("N1") + "kg";
        currentLoadText.transform.SetAsLastSibling();
    }


}
