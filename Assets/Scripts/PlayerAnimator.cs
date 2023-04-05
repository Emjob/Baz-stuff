using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    [SerializeField] float xPos;
    [SerializeField] float yPos;
    private float lastXPos;
    private float lastYPos;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (animator.isActiveAndEnabled)
        {
            xPos = transform.position.x;
            yPos = transform.position.y;


            if (xPos > lastXPos)
            {
                animator.SetFloat("SlimeX", 1);
            }
            if (yPos > lastYPos)
            {
                animator.SetFloat("SlimeY", 1);
            }
            if (xPos < lastXPos)
            {
                animator.SetFloat("SlimeX", -1);
            }
            if (yPos < lastYPos)
            {
                animator.SetFloat("SlimeY", -1);
            }
            if (xPos != lastXPos || yPos != lastYPos)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }


            lastXPos = transform.position.x;
            lastYPos = transform.position.y;
        }
    }
}
