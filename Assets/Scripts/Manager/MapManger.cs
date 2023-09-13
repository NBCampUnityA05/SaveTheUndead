using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManger : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase[] tiles;
    public TileBase rockTile;
    public int circleDiameterA = 5;
    public int circleDiameterB = 6;
    public GameObject objectToPlaceTilesAt;
    public GameObject TestRockPrefab;
    public float repeatInterval = 5.0f;
    private bool shouldRemoveTiles = true;

    private void Start()
    {
        PlaceRandomTiles();
        StartCoroutine(PlaceAndRemoveTiles());
        InvokeRepeating("PlaceRockTiles", 0.0f, repeatInterval);
    }

    void PlaceRandomTiles()
    {
        int radiusA = circleDiameterA / 2;
        Vector3 centerPositionA = objectToPlaceTilesAt.transform.position;

        for (int x = -radiusA; x <= radiusA; x++)
        {
            for (int y = -radiusA; y <= radiusA; y++)
            {
                Vector3Int tilePositionA = new Vector3Int(x, y, 0);
                float distanceA = Vector3.Distance(tilePositionA + centerPositionA, centerPositionA);

                if (distanceA <= radiusA)
                {
                    TileBase randomTile = GetRandomTileWithBias(tiles, 0, 0.9f);
                    tilemap.SetTile(tilePositionA, randomTile);
                }
            }
        }
    }
    TileBase GetRandomTileWithBias(TileBase[] tileArray, int biasedTileIndex, float bias)
    {
        if (Random.value < bias)
        {
            return tileArray[biasedTileIndex];
        }
        else
        {
            int randomIndex = Random.Range(0, tileArray.Length);
            return tileArray[randomIndex];
        }
    }

    void PlaceRockTiles()
{
    int radiusB = circleDiameterB / 2;
    Vector3 centerPositionB = objectToPlaceTilesAt.transform.position;

    if (circleDiameterB >= 0)
    {
        int prevRadiusB = (circleDiameterB + 1) / 2;

        int radiusDifference = prevRadiusB - radiusB;

        if (radiusDifference > 0)
        {
            for (int x = -prevRadiusB; x <= prevRadiusB; x++)
            {
                for (int y = -prevRadiusB; y <= prevRadiusB; y++)
                {
                    Vector3Int tilePositionB = new Vector3Int(x, y, 0);
                    float distanceB = Vector3.Distance(tilePositionB + centerPositionB, centerPositionB);

                    if (distanceB > radiusB)
                    {
                        tilemap.SetTile(tilePositionB, null);

                        if (distanceB <= prevRadiusB)
                        {
                            tilemap.SetTile(tilePositionB, rockTile);
                            tilemap.SetTileFlags(tilePositionB, TileFlags.None);
                            tilemap.SetColliderType(tilePositionB, Tile.ColliderType.Grid);

                            Vector3 rockPosition = tilemap.GetCellCenterWorld(tilePositionB);
                            GameObject rockObject = Instantiate(TestRockPrefab, rockPosition, Quaternion.identity);

                            StartCoroutine(DestroyAfterDelay(rockObject, 5.0f));
                        }
                    }
                }
            }
        }

        circleDiameterB--;
    }
    else
    {
        CancelInvoke("PlaceRockTiles");
    }
}
    private IEnumerator PlaceAndRemoveTiles()
    {
        while (shouldRemoveTiles)
        {
            int radiusB = circleDiameterB / 2;
            Vector3 centerPositionB = objectToPlaceTilesAt.transform.position;

            int targetX = 0;
            int targetY = 0;

            int halfDiameter = circleDiameterB / 2;

            tilemap.SetTile(new Vector3Int(targetX + halfDiameter + 3, targetY, 0), null);
            tilemap.SetTile(new Vector3Int(targetX - halfDiameter - 3, targetY, 0), null);
            tilemap.SetTile(new Vector3Int(targetX, targetY + halfDiameter + 3, 0), null);
            tilemap.SetTile(new Vector3Int(targetX, targetY - halfDiameter - 3, 0), null);

            yield return new WaitForSeconds(repeatInterval * 1f);
        }
    }
    public void StopTileRemoval()
    {
        shouldRemoveTiles = false;
    }

IEnumerator DestroyAfterDelay(GameObject obj, float delay)
{
    yield return new WaitForSeconds(delay);
    Destroy(obj);
}


}
