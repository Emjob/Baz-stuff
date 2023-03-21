using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public LayerMask pickUpOBJ;
    public GameObject ElementalObj;
    //public GameObject UI;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            print("Contact");
            if (Input.GetKeyDown(KeyCode.R))
            {
                print("Do something");
            }
        }
    }
}
