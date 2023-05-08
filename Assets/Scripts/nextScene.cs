using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    bool timer = false;
    float time = 0f;
    Animator animator;

    public bool levelCleared = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.FindWithTag("Animator").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer)
        {
            time += Time.deltaTime;
        }
        if(time >= 1.533f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            levelCleared = true;
            animator.SetBool("TP", true);
            GetComponent<AudioSource>().Play();
            timer = true;
            
        }
    }
}
