using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileInteractions : MonoBehaviour
{
    public string Element;

    public Tilemap tilemap;
    public Tile currentTile;
    public Tile nextTile;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        //  nextTile = Resources.Load<Tile>("Rock/RockTile");
    }

    // Update is called once per frame
    void Update()
    {

        Element = gameObject.tag;
        if (Element == "Ground")
        {
            //    GetComponent<TilemapRenderer>().sortingOrder = 2;
        }
        if (Element == "Water")
        {
            //   transform.Translate(-0.16f, -0.08f, 0);
        }
        if (Element == "Ice")
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<CharacterInfo>() != null)
        {
            print("Characterinfo");
            if (Element == "Ice")
            {
                if (collision.gameObject.GetComponent<CharacterInfo>().playerElement == "Fire")
                {
                    
                    Element = "Ground";
                    nextTile = Resources.Load<Tile>("Rock/RockTile");
                    tilemap.SwapTile(currentTile, nextTile);
                    currentTile = nextTile;
                    //   Destroy(gameObject);
                }
               
                

            }
            if (Element == "Water")
            {
 
                if (collision.gameObject.GetComponent<CharacterInfo>().playerElement == "Ice")
                {
                    Element = "Ice";
                    nextTile = Resources.Load<Tile>("Ice/IceTile");
                    tilemap.SwapTile(currentTile, nextTile);
                    currentTile = nextTile;
                }
                
 
            }
            if (Element == "Fire")
            {

               
                if (collision.gameObject.GetComponent<CharacterInfo>().playerElement == "Water")
                {
                    print("Ground");
                    Element = "Ground";
                    nextTile = Resources.Load<Tile>("Rock/RockTile");
                    tilemap.SwapTile(currentTile, nextTile);
                    currentTile = nextTile;
                    //   Destroy(gameObject);
                }

            }
            if (Element == "Ground")
            {
                if (collision.gameObject.GetComponent<CharacterInfo>().playerElement == "Water")
                {
                    Element = "Water";
                    nextTile = Resources.Load<Tile>("Water/WaterTile");
                    tilemap.SwapTile(currentTile, nextTile);
                    currentTile = nextTile;
                    //   Destroy(gameObject);
                }
                if (collision.gameObject.GetComponent<CharacterInfo>().playerElement == "Grass")
                {
                    Element = "Grass";
                    nextTile = Resources.Load<Tile>("Grass/GrassTile");
                    tilemap.SwapTile(currentTile, nextTile);
                    currentTile = nextTile;
                    //   Destroy(gameObject);
                }

            }
            if (Element == "Grass")
            {
                if (collision.gameObject.GetComponent<CharacterInfo>().playerElement == "Fire")
                {
                    Element = "Fire";
                    nextTile = Resources.Load<Tile>("Fire/FireTile");
                    tilemap.SwapTile(currentTile, nextTile);
                    currentTile = nextTile;
                }
                
            }
        }
            
    }
}
    

