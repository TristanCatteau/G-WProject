using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    public bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Move_Joueur.instance.cont == 2 && open == false)
        {
            open = true;
            this.gameObject.transform.Translate(new Vector2( 0, 200));
        }
        if (Move_Joueur.instance.cont == 0 && open == true)
        {
            open = false;
            this.gameObject.transform.Translate(new Vector2( 0, -200));
        }
    }
}
