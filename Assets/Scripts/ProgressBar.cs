using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public int minimumXp;
    public int maximumXp;
    public int currentXp;
    public Image mask;
    public TextMeshProUGUI xpAmmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();

        if(currentXp >= maximumXp)
        {
            NewLvl();
        }

        xpAmmount.text = (currentXp + "/" + maximumXp);
    }

    void GetCurrentFill()
    {
        float currentOffset = currentXp - minimumXp;
        float maximumOffset = maximumXp - minimumXp;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;
    }

    public void AddXp()
    {

    }
    void NewLvl()
    {
        minimumXp = maximumXp;
        maximumXp += 100;
    }
}
