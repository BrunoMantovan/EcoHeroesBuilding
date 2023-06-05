using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Harbor : MonoBehaviour
{
    public Canvas harborCanvas;
    public TextMeshProUGUI captainDialog;
    public Button nextButton;
    public Button playButton;

    int dialogNumber = 1;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        harborCanvas.gameObject.SetActive(true);
        CaptainText();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CaptainText()
    {
        string text;
        if(dialogNumber == 1)
        {
            text = "primer dialogo";
            captainDialog.text = text;

            dialogNumber++;
        }
        else if (dialogNumber == 2)
        {
            text = "segundo dialogo";
            captainDialog.text = text;

            dialogNumber++;
        }
        else if (dialogNumber == 3)
        {
            text = "tercer dialogo";
            captainDialog.text = text;

            dialogNumber++;
        }
        else if (dialogNumber == 4)
        {
            text = "cuarto dialogo";
            captainDialog.text = text;
            nextButton.gameObject.SetActive(false);
            playButton.gameObject.SetActive(true);
            dialogNumber = 1;
        }
    }
    
}
