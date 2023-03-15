using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile1 : MonoBehaviour
{
    public Tile dirtTile;
    public Tilemap tilemap;
    public int diggingStrength = 1;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3Int cellPosition = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            TileBase tile = tilemap.GetTile(cellPosition);

            if (tile == dirtTile)
            {
                tilemap.SetTile(cellPosition, null);
            }
        }
    }
}
