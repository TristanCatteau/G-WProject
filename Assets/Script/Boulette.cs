using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulette : MonoBehaviour
{
    WaitForSeconds delay = new WaitForSeconds(1);
    public static Boulette instance;
    public bool mielhere = true;
    public int avance = 0;
    public bool dir = true;
    // Update is called once per frame
    void Update()
    {

        if (mielhere == true)
        {
            StartCoroutine(Fall());
        }
        if(avance >= 3 && Move_Joueur.instance.touch == false)
        {
            Debug.Log("Disparait");
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log("Touché");
            if (Move_Joueur.instance.canJump == true)
            {
                StopCoroutine(Move_Joueur.instance.Jump());
                StopCoroutine(Move_Joueur.instance.Fall());
                StartCoroutine(Move_Joueur.instance.Dead());
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log("Touché");
            if (Move_Joueur.instance.canJump == true)
            {
                StopCoroutine(Move_Joueur.instance.Jump());
                StopCoroutine(Move_Joueur.instance.Fall());
                StartCoroutine(Move_Joueur.instance.Dead());
            }
        }
    }

    IEnumerator Fall()
    {
        mielhere = false;
        if (dir == true) 
        {
            transform.Translate(new Vector2( -100, 0));
        } 
        else 
        {
            transform.Translate(new Vector2( 100, 0));
        }
        yield return delay;
        avance = avance + 1;
        mielhere = true;
    }
}