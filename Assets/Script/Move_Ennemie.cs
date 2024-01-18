using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Ennemie : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public Change_Sprite ennemie;
    bool move = true;
    private Transform target;
    private int destPoint=0;
    WaitForSeconds delay = new WaitForSeconds(1);
    public static Move_Ennemie instance;

    public void Awake() 
    {
        instance = this;      
    }
    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            Vector2 dir = target.position - transform.position;
            transform.Translate(dir.normalized*speed, Space.World);
            StartCoroutine(Sprite());
            
            if (Vector2.Distance(transform.position, target.position) < speed)
            {
                destPoint= (destPoint+1) % waypoints.Length;
                target= waypoints[destPoint];
                if (ennemie.tag == "Ant")
                {
                    ennemie.Flip();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log("Touché");
            if (Move_Joueur.instance.canJump == true)
            {
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
                StartCoroutine(Move_Joueur.instance.Dead());
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log("Touché");
            if (Move_Joueur.instance.canJump == true)
            {
                StartCoroutine(Move_Joueur.instance.Dead());
            }
        }
    }
    IEnumerator Sprite()
    {
        move = false;
        ennemie.ChangeSprite();
        yield return delay;
        move = true;    
    }
}
