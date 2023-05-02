using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public LayerMask pickUpOBJ;
    public GameObject cursor;
    private Vector3 Placement;
    private GameObject Player;
    private bool PickedUp;
    [SerializeField] private bool PickUp;
    public bool ShouldAbsorb = false;
    [SerializeField] private bool Absorbed = false;
    private bool Inside = false;

    private float time = 6f;
    private float timer = 0;
    //public GameObject UI;

    public string Element;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Element = gameObject.tag;
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
        }
    }

    private void Update()
    {
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
        

        if (Inside)
        {
            Absorbed = GameObject.FindWithTag("Animator").GetComponent<AnimationScript>().Absorb;

            if (Input.GetKey(KeyCode.Mouse1))
            {
                MouseDown();
            }

            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                MouseUp();
            }
        }

        if(!Absorbed && !PickedUp)
        {
            transform.parent = null;
        }


        if (Absorbed)
        {
            print("Absorb element");
            transform.parent = Player.transform;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
    }

    private void MouseDown()
    {
        if (!Absorbed && !PickedUp)
        {
            if (timer < time)
            {
                timer += 5 * Time.deltaTime;
            }
            if (timer >= time)
            {
                
                ShouldAbsorb = true;
                
            }
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
