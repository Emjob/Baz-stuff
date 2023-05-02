using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    CharacterInfo characterInfo;
    bool dead = false;
    bool onetime = false;
    public AudioSource deathSound;
    void Start()
    {
        characterInfo = GameObject.FindWithTag("Player").GetComponent<CharacterInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        dead = characterInfo.isPlayerDead;

        if (dead && !onetime)
        {
            //print("playSound");
            deathSound.Play();
            onetime = true;
        }
    }
}
