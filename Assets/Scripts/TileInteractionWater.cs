using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInteractionWater : MonoBehaviour
{
    public GameObject Ice;
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
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Ice"))
        {
            Instantiate(Ice, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
