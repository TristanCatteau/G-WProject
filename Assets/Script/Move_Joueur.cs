using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move_Joueur : MonoBehaviour
{
    // Start is called before the first frame update
    public Timer reset;
    public static Move_Joueur instance;
    public int CurrentHealth;
    public int MaxHealth = 3;
    public Change_Sprite hero;
    public bool canMove;
    public bool canRestart;
    public bool canMoveRight;
    public bool canMoveLeft;
    public bool canMoveDown;
    public bool canMoveUp;
    public bool canFall;
    public bool canJump;
    public bool touch;
    public bool truedir;
    public int cont = 0;
    WaitForSeconds delayJump = new WaitForSeconds(0.5f);
    WaitForSeconds delayFall = new WaitForSeconds(0.25f);
    public Sprite death;
    public Transform playerSpawn;
    public AudioManager audioManager;
    public Bouton bouton;
    private void Awake() 
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        instance = this;
    }
    void Start()
    {
        canMove = true;
        canJump = true;
        truedir = true; //true = droite, false = gauche;
        CurrentHealth = MaxHealth ;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {Application.Quit();}
        if(Input.GetKeyDown(KeyCode.RightArrow) && canMove == true  && canMoveRight == true)
        {
            if (!truedir) {hero.Flip(); truedir = true; } 
            transform.Translate(new Vector2( 100, 0));
            hero.ChangeSprite();
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) && canMove == true && canMoveLeft == true)
        {
            if (truedir) {hero.Flip(); truedir = false;} 
            transform.Translate(new Vector2( -100, 0));
            hero.ChangeSprite();
        }

        if(canMove == true && canMoveDown == true && canFall == true)
        {
            StartCoroutine(Fall());
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && canMove == true && canMoveUp == true)
        {
            StartCoroutine(Jump());
        }
    }
    public IEnumerator Jump()
    {
        canMove = false;
        canFall = false;
        hero.ChangeSpriteJump();
        transform.Translate(new Vector2( 0, 100));
        yield return delayJump;
        if((Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.LeftArrow)) && canMoveUp == true && canJump == true && canMoveLeft == true )
        {
            hero.ChangeSpriteJump();
            transform.Translate(new Vector2( -100, 100));
            yield return delayJump;
            if(canMoveDown == true && canJump == true && canMoveLeft == true)
            {
                hero.ChangeSpriteJump();
                transform.Translate(new Vector2( -100, -100));
                yield return delayJump;
            }
        }
        else if((Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.RightArrow)) && canMoveUp == true && canJump == true && canMoveRight == true)
        {
            hero.ChangeSpriteJump();
            transform.Translate(new Vector2( 100, 100));
            yield return delayJump;
            if(canMoveDown == true && canJump == true && canMoveRight == true)
            {
                hero.ChangeSpriteJump();
                transform.Translate(new Vector2( 100, -100));
                yield return delayJump;
            }
        }
        else if (canJump == true && canMoveUp == true)
        {
            hero.ChangeSpriteJump();
            transform.Translate(new Vector2( 0, 100));
            yield return delayJump;
            if(canMoveDown == true && canJump == true)
            {
                hero.ChangeSpriteJump();
                transform.Translate(new Vector2( 0, -100));
                yield return delayJump;
            }
        }
        canMove = true;
        canFall = true;
    }

    public IEnumerator Fall()
    {
        canFall = false;
        canMove = false;
        transform.Translate(new Vector2( 0, -100));
        yield return delayFall;
        canFall = true;
        canMove = true;
    }
    public IEnumerator Dead()
    {
        canMove = false;
        canFall = false;
        canJump = false;
        touch = true;
        canRestart = true;
        CurrentHealth -= 1 ;
        audioManager.StopSong();
        GetComponent<SpriteRenderer>().sprite = death;
        yield return delayJump;
        if (CurrentHealth <= 0)
        {
            GameOverManager.instance.OnPlayerDeath();
        }
        else
        {
            canMoveDown = false;
            transform.position = playerSpawn.position;
            hero.ChangeSprite();
            reset.currentTime = reset.startingTime;
            audioManager.RestartSong();
            canMoveDown = false;
            Debug.Log("1");
            yield return delayJump;
            Debug.Log("2");
            canJump = true;
            touch = false;
            canMoveDown = false;
            canFall = true;
            canMove = true;
            canRestart = false;
            cont = 0;
            Debug.Log("3");
        }
    }
}
