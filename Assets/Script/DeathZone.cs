using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Transform playerSpam;

    private void Awake() 
    {
        playerSpam = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;       
    }
    private void OnCollisionStay2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Touché");
            if (Move_Joueur.instance.canMove == true)
            {
                StartCoroutine(Move_Joueur.instance.Dead());
            }
        }
    }
    private void OnCollisionEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Touché");
            if (Move_Joueur.instance.canMove == true)
            {
                StartCoroutine(Move_Joueur.instance.Dead());
            }
        }
    }
}
