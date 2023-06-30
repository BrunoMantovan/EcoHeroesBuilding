using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timeController : MonoBehaviour
{
    [SerializeField] int min, sec;
    [SerializeField] TMPro.TextMeshProUGUI time;
    [SerializeField] GameObject gameOver;

    private float timeLeft;
    private bool counting;

    private void Awake()
    {
        timeLeft = (min * 60) + sec;
        counting = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (counting)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 1)
            {
                gameOver.SetActive(true);
                counting = false;
            }
            int minutes = Mathf.FloorToInt(timeLeft / 60);
            int seconds = Mathf.FloorToInt(timeLeft % 60);
            time.text = string.Format("{00:00}:{01:00}", minutes, seconds);
        }
    }
}
