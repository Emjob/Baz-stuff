using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public OverlayTile activeTile;
    private float xPos;
    private float yPos;
    private float prevXPos;
    private float prevYPos;
    private bool isPlayerDead;


    private void Update()
    {
        if(isPlayerDead)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Fire"))
        {
            isPlayerDead = true;
        }
    }
}
