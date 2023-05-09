using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    public Material PlayerMaterial;
    public Material DefaultMaterial;
    public OverlayTile activeTile;
    private Animator animator;
    public Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private GameObject DeathScreen;

    private MouseController mouseController;

    private PickUpScript PickUpScript;

    public bool isPlayerDead;
    public int lives;
    public int maxLives = 3;

    private Vector2 playerDir;
    public float knockbackMultiplier = 1;

    public bool ElementAbsorbed = false;
    public string tileElement;
    public string playerElement;

    public bool HoldingElement = false;

    public bool HoldingObject = false;

    private bool startTimer = false;
    private float timer = 0f;
    public float time = 2f;

    Color Fire;
    Color Water;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        mouseController = GameObject.FindWithTag("Cursor").GetComponent<MouseController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        lives = maxLives;
        DeathScreen = GameObject.FindWithTag("DeathScreen");
        Fire = new Color32(255, 84, 0, 255);
        Water = new Color32(21, 196, 253, 255);
    }


    private void Update()
    {
        playerDir = new Vector2(animator.GetFloat("SlimeX"), animator.GetFloat("SlimeY"));

            for (int i = 0; i < transform.childCount; i++)
            {

            if (transform.GetChild(i).gameObject.layer != LayerMask.NameToLayer("Object"))
            {
                if (transform.GetChild(i).gameObject.layer == LayerMask.NameToLayer("Element"))
                {
                    spriteRenderer.material = DefaultMaterial;
                    HoldingElement = true;
                    if (transform.GetChild(i).CompareTag("Ice"))
                    {
                        spriteRenderer.color = Color.cyan;
                    }
                    if (transform.GetChild(i).CompareTag("Grass"))
                    {
                        spriteRenderer.color = Color.green;
                    }
                    if (transform.GetChild(i).CompareTag("Fire"))
                    {
                        spriteRenderer.color = Fire;
                    }
                    if (transform.GetChild(i).CompareTag("Water"))
                    {
                        spriteRenderer.color = Water;
                    }
                    if (transform.GetChild(i).CompareTag("Rock"))
                    {
                        spriteRenderer.color = Color.gray;
                    }
                    if (transform.GetChild(i).CompareTag("Steel"))
                    {
                        spriteRenderer.color = new Color(169, 169, 169);
                    }
                }
                else { HoldingElement = false; spriteRenderer.material = PlayerMaterial; spriteRenderer.color = Color.white; }
            }
            }

        if (isPlayerDead)
        {
            Debug.Log("Player has died");
            DeathScreen.SetActive(true);
            mouseController.gameObject.SetActive(false);
            Destroy(gameObject); // Delete and set up death animation in PlayerAnimator script
        }
        else { DeathScreen.SetActive(false); }

        if (startTimer)
        {
            timer += Time.deltaTime * 1f;
        }
        if(!HoldingElement)
        {
            playerElement = null;
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
            tileElement = collision.gameObject.GetComponent<TileInteractions>().Element;
            if (lives <= 0)
            {
                isPlayerDead = true;
            }
            if (playerElement == null)
            {
                GameObject.FindWithTag("KnockSound").GetComponent<AudioSource>().Play();
                startTimer = true;
                lives -= 1;
                spriteRenderer.color = Color.red;
                mouseController.StopMovement();
                animator.enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.AddForce(playerDir * -1 * knockbackMultiplier);
            }
            
            if (playerElement == "Ice" && tileElement == "Ground")
            {
                GameObject.FindWithTag("KnockSound").GetComponent<AudioSource>().Play();
                startTimer = true;
                lives -= 1;
                spriteRenderer.color = Color.red;
                mouseController.StopMovement();
                animator.enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.AddForce(playerDir * -1 * knockbackMultiplier);
            }
            if (playerElement == "Grass" && tileElement == "Fire")
            {
                GameObject.FindWithTag("KnockSound").GetComponent<AudioSource>().Play();
                startTimer = true;
                lives -= 1;
                spriteRenderer.color = Color.red;
                mouseController.StopMovement();
                animator.enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.AddForce(playerDir * -1 * knockbackMultiplier);
            }
            if (playerElement == "Grass" && tileElement == "Steel")
            {
                GameObject.FindWithTag("KnockSound").GetComponent<AudioSource>().Play();
                startTimer = true;
                lives -= 1;
                spriteRenderer.color = Color.red;
                mouseController.StopMovement();
                animator.enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.AddForce(playerDir * -1 * knockbackMultiplier);
            }
            if (playerElement == "Water" && tileElement == "Ice")
            {
                GameObject.FindWithTag("KnockSound").GetComponent<AudioSource>().Play();
                startTimer = true;
                lives -= 1;
                spriteRenderer.color = Color.red;
                mouseController.StopMovement();
                animator.enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.AddForce(playerDir * -1 * knockbackMultiplier);
            }
            if (playerElement == "Water" && tileElement == "Grass")
            {
                GameObject.FindWithTag("KnockSound").GetComponent<AudioSource>().Play();
                startTimer = true;
                lives -= 1;
                spriteRenderer.color = Color.red;
                mouseController.StopMovement();
                animator.enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.AddForce(playerDir * -1 * knockbackMultiplier);
            }
            if (playerElement == "Fire" && tileElement == "Water")
            {
                GameObject.FindWithTag("KnockSound").GetComponent<AudioSource>().Play();
                startTimer = true;
                lives -= 1;
                spriteRenderer.color = Color.red;
                mouseController.StopMovement();
                animator.enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.AddForce(playerDir * -1 * knockbackMultiplier);
            }
            if (playerElement == "Fire" && tileElement == "Ground")
            {
                GameObject.FindWithTag("KnockSound").GetComponent<AudioSource>().Play();
                startTimer = true;
                lives -= 1;
                spriteRenderer.color = Color.red;
                mouseController.StopMovement();
                animator.enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.AddForce(playerDir * -1 * knockbackMultiplier);
            }
            if (playerElement == "Steel" && tileElement == "Fire")
            {
                GameObject.FindWithTag("KnockSound").GetComponent<AudioSource>().Play();
                startTimer = true;
                lives -= 1;
                spriteRenderer.color = Color.red;
                mouseController.StopMovement();
                animator.enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.AddForce(playerDir * -1 * knockbackMultiplier);
            }
            if (playerElement == "Steel" && tileElement == "Ground")
            {
                GameObject.FindWithTag("KnockSound").GetComponent<AudioSource>().Play();
                startTimer = true;
                lives -= 1;
                spriteRenderer.color = Color.red;
                mouseController.StopMovement();
                animator.enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.AddForce(playerDir * -1 * knockbackMultiplier);
            }
            if (playerElement == "Ground" && tileElement == "Grass")
            {
                GameObject.FindWithTag("KnockSound").GetComponent<AudioSource>().Play();
                startTimer = true;
                lives -= 1;
                spriteRenderer.color = Color.red;
                mouseController.StopMovement();
                animator.enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.AddForce(playerDir * -1 * knockbackMultiplier);
            }
            if (playerElement == "Ground" && tileElement == "Water")
            {
                GameObject.FindWithTag("KnockSound").GetComponent<AudioSource>().Play();
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
            if (!HoldingElement)
            {
                PickUpScript = collision.gameObject.GetComponent<PickUpScript>();
            }
            ElementAbsorbed = PickUpScript.ShouldAbsorb;
            
        }

        
    }
}
