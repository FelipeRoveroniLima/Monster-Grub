using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGameScreen : MonoBehaviour
{
    public TMP_Text scoreText;
    
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreText.SetText("Score: {0}", score);
        Debug.Log("Score: " + score);
    }
    
}
