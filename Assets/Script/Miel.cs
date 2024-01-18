using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miel : MonoBehaviour
{
    public GameObject Nut;
    public Transform Lieu;
    public Transform Lieu_1;
    public Transform Lieu_2;
    private bool cocohereleft;
    private bool cocohere;
    private bool mielhere;
    WaitForSeconds monkey = new WaitForSeconds(2);
    WaitForSeconds ant = new WaitForSeconds(1);
    // Start is called before the first frame update
    void Start()
    {
        Lieu = Lieu_2;
        cocohere = true;
        cocohereleft = false; 
        mielhere = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cocohere == true)
        {
            if (cocohereleft == true && mielhere == true)
            {
                Instantiate(Nut,Lieu_2.position,Quaternion.identity);
                StartCoroutine(Pop());
            }
            else if (cocohereleft == false && mielhere == true )
            {
                Instantiate(Nut,Lieu_1.position,Quaternion.identity);
                StartCoroutine(Pop());
            }
        }
        
    }
    IEnumerator Pop()
    {
        cocohere = false;
        yield return ant;
        if (cocohereleft == true) {cocohereleft = false;} else {cocohereleft = true;}
        cocohere = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Fourmi")
        {
            Debug.Log("Touché");
            mielhere = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Fourmi")
        {
            Debug.Log("exit");
            mielhere = false;
        }
    }
}

