using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Vector3Int spawnGrid;
    public LayerMask TileLayer;
    public GameObject characterPrefab;
    private CharacterInfo character;
    public float speed;

    private PathFinder pathFinder;
    private List<OverlayTile> path;

    private void Start()
    {
        pathFinder = new PathFinder();

        path = new List<OverlayTile>();
    }

    private void LateUpdate()
    {
        RaycastHit2D? hit = GetFocusedOnTile();

        if (character == null)
        {
            character = GameObject.FindWithTag("Player").GetComponent<CharacterInfo>();
            OverlayTile spawnTile = GameObject.Find("OverlayTile(Clone)").GetComponent<OverlayTile>();
            spawnTile.gridLocation = spawnGrid;
            character.activeTile = spawnTile;
        }

        if (hit.HasValue)
        {
            OverlayTile overlayTile = hit.Value.collider.gameObject.GetComponent<OverlayTile>();
            transform.position = overlayTile.transform.position;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = overlayTile.GetComponent<SpriteRenderer>().sortingOrder;

            if (Input.GetMouseButtonDown(0))
            {
                overlayTile.ShowTile();
                if (character == null)
                {
                    character = Instantiate(characterPrefab).GetComponent<CharacterInfo>();
                    PositionCharacterOnTile(overlayTile);
                    character.activeTile = overlayTile;
                }
                else
                {
                    path = pathFinder.FindPath(character.activeTile, overlayTile);

                    overlayTile.gameObject.GetComponent<OverlayTile>().HideTile();
                }
            }
        }

        if(path.Count > 0)
        {
            MoveAlongPath();
        }
    }

    private void MoveAlongPath()
    {
        var step = speed * Time.deltaTime;

        var zIndex = path[0].transform.position.z;

        character.transform.position = Vector2.MoveTowards(character.transform.position, path[0].transform.position, step);
        character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, zIndex);

        if(Vector2.Distance(character.transform.position, path[0].transform.position) < 0.00001f)
        {
            PositionCharacterOnTile(path[0]);
            path.RemoveAt(0);
        }
    }

    private void PositionCharacterOnTile(OverlayTile tile)
    {
        character.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y + 0.0001f, tile.transform.position.z);
        character.GetComponentInChildren<SpriteRenderer>().sortingOrder = tile.GetComponent<SpriteRenderer>().sortingOrder;
        character.activeTile = tile;
    }

    public RaycastHit2D? GetFocusedOnTile()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2d = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2d, Vector2.zero, 10000f, TileLayer);

        if(hits.Length > 0)
        {
            return hits.OrderByDescending(i => i.collider.transform.position.z).First();
        }
        return null;
    }
}

