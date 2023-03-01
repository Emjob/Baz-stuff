using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInteractionFire : MonoBehaviour
{
    public GameObject water;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            Destroy(this);
        }
        if (collision.gameObject.CompareTag("Ice"))
        {
            Instantiate(water,collision.transform.position,Quaternion.identity);
            Debug.Log("help");
            Destroy(collision.gameObject);

        }
    }
}
