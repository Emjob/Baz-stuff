using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileInteractions : MonoBehaviour
{
    string Element;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Element = gameObject.tag;
        if (Element == "Ground")
        {
        //    GetComponent<TilemapRenderer>().sortingOrder = 2;
        }
        if(Element == "Water" )
        {
         //   transform.Translate(-0.16f, -0.08f, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Element == "Ice")
        {
            if(collision.gameObject.CompareTag("Fire"))
            {
                gameObject.tag = "Water";
             //   Destroy(gameObject);
            }
        }
        if(Element == "Water")
        {
            if (collision.gameObject.CompareTag("Fire"))
            {
                collision.gameObject.tag = "Ground";
                Destroy(gameObject);
                
            }
            if(collision.gameObject.CompareTag("Ice"))
            {
                collision.gameObject.tag = "Ice";
            }
        }
        if(Element == "Fire")
        {

        }
    }
}
