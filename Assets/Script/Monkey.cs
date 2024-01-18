using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    public GameObject Nut;
    public Transform Lieu;
    public Transform Lieu_1;
    public Transform Lieu_2;
    private bool cocohereleft;
    private bool cocohere;
    WaitForSeconds monkey = new WaitForSeconds(2);
    WaitForSeconds ant = new WaitForSeconds(6);
    // Start is called before the first frame update
    void Start()
    {
        Lieu = Lieu_2;
        cocohere = true;
        cocohereleft = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (cocohere == true)
        {
            if (cocohereleft == true)
            {
                Instantiate(Nut,Lieu_2.position,Quaternion.identity);
                StartCoroutine(Pop());
            }
            else if (cocohereleft == false)
            {
                Instantiate(Nut,Lieu_1.position,Quaternion.identity);
                StartCoroutine(Pop());
            }
        }
        
    }
    IEnumerator Pop()
    {
        cocohere = false;
        if (this.CompareTag("Monkey"))
        {
            yield return monkey;
        }
        else
        {
            yield return ant;
        }
        if (cocohereleft == true) {cocohereleft = false;} else {cocohereleft = true;}
        cocohere = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log("Touché");
            if (Move_Joueur.instance.canMove == true)
            {
                StartCoroutine(Move_Joueur.instance.Dead());
            }
        }
    }
}
