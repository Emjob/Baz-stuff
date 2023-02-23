using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInteractionIce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            Destroy(gameObject);
            print("Ice collide with Fire");
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            print("Ice collide with Water");
        }
    }
}
