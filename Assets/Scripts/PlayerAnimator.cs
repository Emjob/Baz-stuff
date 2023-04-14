using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    [SerializeField] float xPos;
    [SerializeField] float yPos;
    private float lastXPos;
    private float lastYPos;
    private CharacterInfo CharacterInfo;
    private bool Absorbed;
    private float timer = 0f;
    public float time = 2f;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        CharacterInfo = GameObject.FindWithTag("Player").GetComponent<CharacterInfo>();
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


            if (CharacterInfo.ElementAbsorbed)
            {
                if (timer <= time)
                {
                    timer += 5 * Time.deltaTime;
                }
                if(timer < time)
                {
                    Absorbed = true;
                }
            } else { Absorbed = false; timer = 0f; }

            if(timer >= time)
            {
                Absorbed = false;
            }
            if (Absorbed)
            {
                animator.SetBool("Absorb", true);
            }
            else
            {
                animator.SetBool("Absorb", false);
            }
            

            lastXPos = transform.position.x;
            lastYPos = transform.position.y;
        }
    }
}
