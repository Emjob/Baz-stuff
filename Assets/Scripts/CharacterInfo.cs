using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    public OverlayTile activeTile;
    private Animator animator;
    public Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private MouseController mouseController;

    private PickUpScript PickUpScript;

    private bool isPlayerDead;
    public int lives;
    public int maxLives = 3;

    private Vector2 playerDir;
    public float knockbackMultiplier = 1;

    public bool ElementAbsorbed = false;

    private bool startTimer = false;
    private float timer = 0f;
    public float time = 2f;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        mouseController = GameObject.FindWithTag("Cursor").GetComponent<MouseController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        lives = maxLives;
    }


    private void Update()
    {
        playerDir = new Vector2(animator.GetFloat("SlimeX"), animator.GetFloat("SlimeY"));

        if(isPlayerDead)
        {
            Debug.Log("Player has died");
            mouseController.gameObject.SetActive(false);
            Destroy(gameObject); // Delete and set up death animation in PlayerAnimator script
            // Death screen/UI enabled goes here or in a seperate UI script that references isPlayerDead bool (or on a behaviour script to play at the end of the death animation)
        }

        if (startTimer)
        {
            timer += Time.deltaTime * 1f;
        }

        if(timer >= time)
        {
            spriteRenderer.color = Color.white;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.enabled = true;
            startTimer = false;
            timer = 0f;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            if (lives <= 0)
            {
                isPlayerDead = true;
            }
            else
            {
                startTimer = true;
                lives -= 1;
                spriteRenderer.color = Color.red;
                mouseController.StopMovement();
                animator.enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.AddForce(playerDir * -1 * knockbackMultiplier);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            //spriteRenderer.color = Color.white;
            //rb.constraints = RigidbodyConstraints2D.FreezeAll;
            //animator.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PickUpScript>())
        {
            PickUpScript = collision.gameObject.GetComponent<PickUpScript>();
            ElementAbsorbed = PickUpScript.ShouldAbsorb;
        }

        
    }
}
