using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    private Transform playerSpam;
    public Move_Joueur player;
    public Porte porte;

    private void Awake() 
    {
        playerSpam = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;       
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player") && porte.open == false)
        {
            Debug.Log("Touché");
            player.canMoveRight = false;
        }
    }
        private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Sortie");
            player.canMoveRight = true;
        }
    }
}
