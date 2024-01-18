using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour
{
    WaitForSeconds delay = new WaitForSeconds(1);
    public bool cocohere = true;
    public int avance = 0;
    public bool touch = false;
    // Update is called once per frame
    void Update()
    {
        if (cocohere == true)
        {
            StartCoroutine(Fall());
        }
        if(avance == 4 && touch == false)
        {
            Debug.Log("Disparait");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            touch = true;
            Debug.Log("Touché");
            if (Move_Joueur.instance.canJump == true)
            {
                Debug.Log("here");
                StopCoroutine(Move_Joueur.instance.Jump());
                StopCoroutine(Move_Joueur.instance.Fall());
                StartCoroutine(Move_Joueur.instance.Dead());
                Debug.Log("dead");
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            touch = true;
            Debug.Log("Touché");
            if (Move_Joueur.instance.canJump == true)
            {
                Debug.Log("here");
                StopCoroutine(Move_Joueur.instance.Jump());
                StopCoroutine(Move_Joueur.instance.Fall());
                StartCoroutine(Move_Joueur.instance.Dead());
                Debug.Log("dead");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            touch = true;
            Debug.Log("Touché");
            if (Move_Joueur.instance.canJump == true)
            {
                Debug.Log("here");
                StopCoroutine(Move_Joueur.instance.Jump());
                StopCoroutine(Move_Joueur.instance.Fall());
                StartCoroutine(Move_Joueur.instance.Dead());
                Debug.Log("dead");
            }
        }
    }
    IEnumerator Fall()
    {
        cocohere = false;
        transform.Translate(new Vector2( 0, -100));
        yield return delay;
        avance = avance + 1;
        cocohere = true;
    }
}
