using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class weighingClockController : MonoBehaviour
{
    public weighingMachineController weighingMachine;
    public TMPro.TextMeshProUGUI currentLoadText;
    private float currentLoad;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        currentLoad = weighingMachine.totalWeight;
        currentLoadText.text = currentLoad.ToString("N1") + "kg";
        currentLoadText.transform.SetAsLastSibling();
    }


}
