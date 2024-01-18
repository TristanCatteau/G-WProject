using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton : MonoBehaviour
{
    public Sprite bouton_sprite; 
    public Sprite bouton_sprite_o; 
    public bool touch = false;
    // Start is called before the first frame update
    void Start()
    {
        touch=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Button" && gameObject.GetComponent<SpriteRenderer>().sprite == bouton_sprite)
        {
            if (Move_Joueur.instance.canRestart == true && Move_Joueur.instance.cont > 0)
            {
                RestartBouton();
            }
        }
    }
    public void RestartBouton()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = bouton_sprite_o;
        gameObject.transform.Translate(new Vector2( 0, 10));
        touch = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            if(touch == false)
            {
                touch = true;
                Debug.Log("Touché Bouton");
                this.gameObject.GetComponent<SpriteRenderer>().sprite = bouton_sprite;
                this.gameObject.transform.Translate(new Vector2( 0, -10));
                Move_Joueur.instance.cont += 1;
            }
        }
    }
}
