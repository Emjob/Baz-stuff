using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileInteractions : MonoBehaviour
{
    string Element;

    public Tilemap tilemap;
   public Tile currentTile;
    public Tile nextTile;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        //
        nextTile = Resources.Load<Tile>("Rock/RockTile");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            tilemap.SwapTile(currentTile, nextTile);
        }
        Element = gameObject.tag;
        if (Element == "Ground")
        {
        //    GetComponent<TilemapRenderer>().sortingOrder = 2;
        }
        if(Element == "Water" )
        {
         //   transform.Translate(-0.16f, -0.08f, 0);
        }
        if(Element == "Ice")
        {
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PickUpScript>() == null)
        {
            
            if (Element == "Ice")
            {
                if (collision.gameObject.GetComponent<PickUpScript>().Element == "Fire")
                {
                    Element = "Ground";
                    nextTile = Resources.Load<Tile>("Rock/RockTile");
                    tilemap.SwapTile(currentTile, nextTile);
                    currentTile = nextTile;
                    //   Destroy(gameObject);
                }
                if (collision.gameObject.GetComponent<PickUpScript>().Element == "Water")
                {

                    collision.gameObject.GetComponent<PickUpScript>().Element = "Ice";
                }
            }
            if (Element == "Water")
            {
                if (collision.gameObject.GetComponent<PickUpScript>().Element == "Ground")
                {
                    collision.gameObject.GetComponent<PickUpScript>().Element = "Water";
                }
                if (collision.gameObject.CompareTag("Ice"))
                {
                    Element = "Ice";
                    nextTile = Resources.Load<Tile>("Ice/IceTile");
                    tilemap.SwapTile(currentTile, nextTile);
                    currentTile = nextTile;
                }
                if (collision.gameObject.GetComponent<PickUpScript>().Element == "Fire")
                {
                    collision.gameObject.GetComponent<PickUpScript>().Element = "Water";
                    //   Destroy(gameObject);
                }
            }
            if (Element == "Fire")
            {
                if (collision.gameObject.GetComponent<PickUpScript>().Element == "Ice")
                {
                    collision.gameObject.GetComponent<PickUpScript>().Element = "Water";
                }
                if (collision.gameObject.GetComponent<PickUpScript>().Element == "Water")
                {
                    Element = "Ground";
                    nextTile = Resources.Load<Tile>("Rock/RockTile");
                    tilemap.SwapTile(currentTile, nextTile);
                    currentTile = nextTile;
                    //   Destroy(gameObject);
                }

            }
            if (Element == "Ground")
            {
                if (collision.gameObject.GetComponent<PickUpScript>().Element == "Water")
                {
                    Element = "Water";
                    nextTile = Resources.Load<Tile>("Water/WaterTile");
                    tilemap.SwapTile(currentTile, nextTile);
                    currentTile = nextTile;
                    //   Destroy(gameObject);
                }
            }
            return;
        }
    }
    
}
