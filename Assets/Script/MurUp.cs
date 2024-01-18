using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurUp : MonoBehaviour
{
    private Transform playerSpam;
    public Move_Joueur player;

    private void Awake() 
    {
        playerSpam = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;       
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Touché");
            player.canMoveUp = false;
        }
    }
        private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Sortie");
            player.canMoveUp = true;
        }
    }
}
