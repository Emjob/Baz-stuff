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
    private bool PickUp;
    private bool Absorbed = false;
    private bool Inside = false;

    private float time = 6f;
    private float timer = 0;
    //public GameObject UI;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
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
            if (Input.GetKey(KeyCode.Mouse1))
            {
                MouseDown();
            }

            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                MouseUp();
            }
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
                print("Absorb element");
                Absorbed = true;
            }
        }

        
    }

    private void MouseUp()
    {
        if (!Absorbed && !PickedUp)
        {
            PickUp = true;
        }

        if (PickedUp)
        {
            PickUp = false;
        }

        if (PickUp && !Absorbed)
        {
            print(Placement.x - transform.position.x);
            transform.parent = Player.transform;
            PickedUp = true;
        }

        if (!PickUp)
        {
            transform.parent = null;
            PickedUp = false;
        }

        if (Absorbed && timer < time)
        {
            Absorbed = false;
            print("Released");
        }

        timer = 0;
    }
}