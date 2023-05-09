using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectScript : MonoBehaviour
{
    private bool isHeld = false;
    private bool canDrop = true;
    private bool justDropped = false;
    [SerializeField] private Vector3 localPos;

    public Sprite slotted;

    CharacterInfo charInfo;

    public UnityEvent onTrigger;

    void Start()
    {
        charInfo = GameObject.FindWithTag("Player").GetComponent<CharacterInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHeld && Input.GetKeyDown(KeyCode.Space) && canDrop)
        {
            charInfo.HoldingObject = false;
            isHeld = false;
            justDropped = true;
            transform.parent = null;
        }

        if(isHeld && Input.GetKeyDown(KeyCode.Space) && !canDrop)
        {
            charInfo.gameObject.GetComponent<AudioSource>().Play();
        }

        print(justDropped);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!collision.GetComponent<CharacterInfo>().HoldingObject && !justDropped)
            {
                PickUpObject(collision.gameObject);
            }
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            canDrop = false;
        }

        if((gameObject.CompareTag("Diamond") && collision.CompareTag("DiaHole")) || (gameObject.CompareTag("Square") && collision.CompareTag("SquHole")) || (gameObject.CompareTag("Orb") && collision.CompareTag("OrbHole")))
        {
            charInfo.HoldingObject = false;
            onTrigger.Invoke();
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = slotted;
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            canDrop = true;
        }
        if (collision.CompareTag("Player"))
        {
            justDropped = false;
        }
    }

    private void PickUpObject(GameObject player)
    {
        isHeld = true;
        charInfo.HoldingObject = true;
        transform.parent = player.transform;
        transform.localPosition = localPos;
    }
}
