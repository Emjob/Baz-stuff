using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public LayerMask pickUpOBJ;
    public GameObject cursor;
    private Vector3 Placement;
    private GameObject Player;
    private Animator animator;
    private bool PickedUp;
    [SerializeField] private bool PickUp;
    public bool ShouldAbsorb = false;
    [SerializeField] public bool Absorbed = false;
    [SerializeField]private bool Inside = false;
    [SerializeField]private bool dontpickup = false;

    private float time = 6f;
    private float timer = 0;
    //public GameObject UI;

    public string Element;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Element = gameObject.tag;
        animator = GameObject.FindWithTag("Animator").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Inside = true;   
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Inside = false;
            dontpickup = false;
        }
    }

    private void Update()
    {
        print(Inside + " ShouldAbsorb: " + ShouldAbsorb + " Absorbed: " + Absorbed);

        //ShouldAbsorb = GameObject.FindWithTag("Animator").GetComponent<AnimationScript>().Absorb;


        /*Placement = cursor.transform.position;

        if(Input.GetKeyDown(KeyCode.P) && PickedUp)
        {
            if(Placement.x - transform.position.x <= 0)
            {
                transform.parent = null;
                transform.Translate(-0.16f,0,0);
            }
            if(Placement.x - transform.position.x >= 0)
            {
                transform.parent = null;
                transform.Translate(0.16f, 0, 0);
            }
            if (Placement.y - transform.position.y <= 0)
            {
                transform.parent = null;
                transform.Translate(-0.08f, 0, 0);
            }
            if (Placement.y - transform.position.y >= 0)
            {
                transform.parent = null;
                transform.Translate(0.08f, 0, 0);
            }
        }*/
        if(transform.parent == null)
        {
            ShouldAbsorb = false;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            MouseDown();
        }
        if (Inside && !animator.GetBool("IsRunning"))
        {
            Absorbed = GameObject.FindWithTag("Animator").GetComponent<AnimationScript>().Absorb;

            
           /*
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                MouseUp();
            } */
            if (!Absorbed && !PickedUp && !dontpickup && !Player.GetComponent<CharacterInfo>().HoldingElement)
            {
                ShouldAbsorb = true;
                
                //Player.GetComponent<CharacterInfo>().playerElement = null;
            }

            if (Absorbed && !Player.GetComponent<CharacterInfo>().HoldingElement && !dontpickup)
            {
                print(Element);
                Player.GetComponent<CharacterInfo>().playerElement = Element;
                print("Absorb element");
                transform.parent = Player.transform;
                transform.localPosition = new Vector3(0, 0, 0);
                GetComponentInChildren<SpriteRenderer>().enabled = false;
            }
        }

        if(!Absorbed && !PickedUp)
        {
            
            transform.parent = null;

        }


        
    }

    private void MouseDown()
    {
        print("MouseDown");
        /*if (!Absorbed && !PickedUp)
        {
            if (timer < time)
            {
                timer += 5 * Time.deltaTime;
            }
            if (timer >= time)
            {
                
                ShouldAbsorb = true;
                
            }
        }*/

        if (transform.parent)
        {
            dontpickup = true;
            ShouldAbsorb = false;
            GameObject.FindWithTag("Animator").GetComponent<AnimationScript>().Absorb = false;
            
            
            GetComponentInChildren<SpriteRenderer>().enabled = true;
            print("Released");
            Absorbed = false;
            transform.parent = null;
        }
    }
    public void Destroy()
    {
        if (!Absorbed)
        {
            Destroy(gameObject);
            Debug.Log("AHSFDKJHABSCFIJHBASUYCHB ");
        }
    }

    private void MouseUp()
    {
        print("Mouse is released");
        if (!Absorbed && !PickedUp && !ShouldAbsorb && !GameObject.FindWithTag("Animator").GetComponent<AnimationScript>().Absorb)
        {
            PickUp = true;
        }

        if (PickedUp)
        {
            PickUp = false;
        }

        if (PickUp && !Absorbed && !ShouldAbsorb)
        {
            GameObject.FindWithTag("PickSound").GetComponent<AudioSource>().Play();
            print(Placement.x - transform.position.x);
            GameObject.Find("Player").GetComponent<CharacterInfo>().playerElement = Element;
            transform.parent = Player.transform;
            PickedUp = true;
        }

        if (!PickUp)
        {
            
            PickedUp = false;
        }

        if (Absorbed && timer < time)
        {
            
            ShouldAbsorb = false;
            GameObject.FindWithTag("Animator").GetComponent<AnimationScript>().Absorb = false;
            
            GetComponentInChildren<SpriteRenderer>().enabled = true;
            print("Released");
            Absorbed = false;
        }

        timer = 0;
    }
}
