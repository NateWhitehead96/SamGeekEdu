using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenWalls : MonoBehaviour
{
    private TilemapRenderer render; // the images of the hidden walls, we'll use this to show/hide the tiles
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            render.enabled = false; // disable the renderer so the blocks are see through
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            render.enabled = true; // enable the renderer when we walk out of the hidden blocks
        }  
    }
}
