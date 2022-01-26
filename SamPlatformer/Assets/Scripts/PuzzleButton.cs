using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to destroy blocks we need to to unlock either another block or key
public class PuzzleButton : MonoBehaviour
{
    public GameObject[] tilesToDelete; // some tiles to delete
    
    public void DestroyAllTiles()
    {
        for (int i = 0; i < tilesToDelete.Length; i++)
        {
            Destroy(tilesToDelete[i]); // destroy the tiles
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DestroyAllTiles(); // first destroy the tiles we want
            Destroy(gameObject); // destroy self
        }
    }
}
