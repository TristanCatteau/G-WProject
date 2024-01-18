using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject VictoryUI;
    public static GameOverManager instance;
    private void Awake() 
    { 
        GameOverUI.SetActive(false);
        VictoryUI.SetActive(false);
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'une instance de GameOverManager dans la scène");
            return;
        }    
        instance = this;
    }
    public void OnPlayerDeath()
    {
        GameOverUI.SetActive(true);
    }

    public void Victory()
    {
        VictoryUI.SetActive(true);
    }

    public void RetryButton()
    {
        Move_Joueur.instance.CurrentHealth = 4;
        StartCoroutine(Move_Joueur.instance.Dead());
        GameOverUI.SetActive(false);
        VictoryUI.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
