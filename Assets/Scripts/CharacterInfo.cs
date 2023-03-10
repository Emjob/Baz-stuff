using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    private Animator animator;
    public OverlayTile activeTile;
    private float xPos;
    private float yPos;
    private float prevXPos;
    private float prevYPos;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;

        if (xPos != prevXPos || yPos != prevYPos)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        prevXPos = transform.position.x;
        prevYPos = transform.position.y;
    }
}
