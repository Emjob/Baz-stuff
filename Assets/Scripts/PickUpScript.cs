using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public LayerMask pickUpOBJ;
    public GameObject cursor;
    private Vector3 Placement;
    private GameObject Player;
    private bool PickedUp;
    //public GameObject UI;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

          //  print("Contact");
            if (Input.GetKeyDown(KeyCode.R))
            {
                 print(Placement.x - transform.position.x);
                transform.parent = Player.transform;
                PickedUp = true;
            }
        }
    }

    private void Update()
    {
        Placement = cursor.transform.position;

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
        }

    }
}
