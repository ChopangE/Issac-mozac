using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    public Tilemap floorTilemap, wallTilemap;

    [SerializeField]
    private TileBase floorTile, wallTop; 

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPosition)
    {
        PaintFloorTiles(floorPosition, floorTilemap, floorTile);
    }

    private void PaintFloorTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach(var position in positions)
        {
            PaintSingleTile(tilemap, tile, position); 
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position); // Return world position of the tile cell 
        tilemap.SetTile(tilePosition, tile); // Paint the tile in xyz 
    }

    public void Clear()
    {
        floorTilemap.ClearAllTiles(); 
        wallTilemap.ClearAllTiles();
    }

    internal void PaintSingleBasicWall(Vector2Int position)
    {
        PaintSingleTile(wallTilemap, wallTop, position);
    }
}
