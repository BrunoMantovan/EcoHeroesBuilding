using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class gameOverPopup : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI kgCollected;
    public wareHouseCotroller wareHouse;
    private float totalKgCollected;
    private void Update()
    {
        totalKgCollected = wareHouse.LoadCalculation();
        kgCollected.text = totalKgCollected.ToString();
    }
    public void BackToCity()
    {
        SceneManager.LoadScene("Main_Menu");
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Mision_Ship_Collector");
    }

}
