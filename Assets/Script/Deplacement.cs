using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{
    public Sprite cube_2;
    public Sprite cube_3;
    public Sprite cube_4;
    public Sprite cube_1;
    int sprite = 1 ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2( 1000, 0));
            if (sprite == 1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cube_2;
                sprite = 2;
            }
            else if (sprite == 2)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cube_3;
                sprite = 3;
            }
             else if (sprite == 3)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cube_4;
                sprite = 4;
            }
             else
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cube_1;
                sprite = 1;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2( -1000, 0));
            if (sprite == 1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cube_4;
                sprite = 4;
            }
            else if (sprite == 4)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cube_3;
                sprite = 3;
            }
             else if (sprite == 3)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cube_2;
                sprite = 2;
            }
             else
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cube_1;
                sprite = 1;
            }
        }
    }
}
