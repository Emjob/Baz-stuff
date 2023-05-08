using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart_UI : MonoBehaviour
{
    //calling script character info
    public CharacterInfo PlayerInfo;


    //calling Image or Gameobject (replace it when heart sprite are made)
    public Image[] hearts;
    public Sprite heartImage;
    public Sprite blankHeartImage;

    public AudioSource WorldMusic;
    public AudioSource EndGameMusic;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo = gameObject.GetComponent<CharacterInfo>();
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerInfo.lives > PlayerInfo.maxLives)
        {
            PlayerInfo.lives = PlayerInfo.maxLives;
        }

        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < PlayerInfo.lives)
            {
                hearts[i].sprite = heartImage;
            }
            else
            {
                hearts[i].sprite = blankHeartImage;
            }

            if(i < PlayerInfo.maxLives)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (PlayerInfo.isPlayerDead)
        {
            WorldMusic.Stop();
            EndGameMusic.Play();
        }

    }
}
