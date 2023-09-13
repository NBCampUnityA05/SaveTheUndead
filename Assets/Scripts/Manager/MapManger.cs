using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManger : MonoBehaviour
{
    public Tilemap tilemap; // 타일맵 컴포넌트를 가리킬 public 변수
    public TileBase[] tiles; // 배치할 랜덤 타일들의 배열
    public TileBase rockTile; // Rock 타일을 가리킬 public 변수
    public int circleDiameterA = 5; // 원 A의 지름
    public int circleDiameterB = 6; // 원 B의 지름
    public GameObject objectToPlaceTilesAt; // 원의 중심 위치를 갖는 오브젝트
    public GameObject TestRockPrefab; // "TestRock" 프리팹을 가리킬 public 변수
    public float repeatInterval = 5.0f;// 주기적으로 실행할 시간 간격(초)
    private bool shouldRemoveTiles = true; // 타일 제거 여부를 제어하는 변수


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
                    //특수 타일 빈도수 조정
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
            // 특정 타일이 선택될 확률이 bias 이상인 경우
            return tileArray[biasedTileIndex];
        }
        else
        {
            // 랜덤하게 다른 타일을 선택합니다.
            int randomIndex = Random.Range(0, tileArray.Length);
            return tileArray[randomIndex];
        }
    }

    void PlaceRockTiles()
{
    int radiusB = circleDiameterB / 2;
    Vector3 centerPositionB = objectToPlaceTilesAt.transform.position;

    // 원 B의 반지름 감소 여부를 확인합니다.
    if (circleDiameterB >= 0)
    {
        // 이전 원 B의 반지름
        int prevRadiusB = (circleDiameterB + 1) / 2;

        // 이전 원 B와 현재 원 B 사이의 차이를 계산합니다.
        int radiusDifference = prevRadiusB - radiusB;

        // 차이가 양수인 경우, 원 A 안에 없는 타일을 제거하고 Rock 타일을 배치합니다.
        if (radiusDifference > 0)
        {
            for (int x = -prevRadiusB; x <= prevRadiusB; x++)
            {
                for (int y = -prevRadiusB; y <= prevRadiusB; y++)
                {
                    Vector3Int tilePositionB = new Vector3Int(x, y, 0);
                    float distanceB = Vector3.Distance(tilePositionB + centerPositionB, centerPositionB);

                    // 현재 원 B 안에 없는 타일만 처리합니다.
                    if (distanceB > radiusB)
                    {
                        // 해당 위치의 타일을 제거합니다.
                        tilemap.SetTile(tilePositionB, null);

                        // Rock 타일을 해당 위치에 배치합니다.
                        if (distanceB <= prevRadiusB)
                        {
                            tilemap.SetTile(tilePositionB, rockTile);
                            tilemap.SetTileFlags(tilePositionB, TileFlags.None);
                            tilemap.SetColliderType(tilePositionB, Tile.ColliderType.Grid);

                            Vector3 rockPosition = tilemap.GetCellCenterWorld(tilePositionB);
                            GameObject rockObject = Instantiate(TestRockPrefab, rockPosition, Quaternion.identity);

                            // 일정 시간 후에 TestRockPrefab을 제거합니다.
                            StartCoroutine(DestroyAfterDelay(rockObject, 5.0f));
                        }
                    }
                }
            }
        }

        // circleDiameterB를 1씩 감소시킵니다.
        circleDiameterB--;
    }
    else
    {
        // 원 B의 반지름이 0 이하이면 호출 중지
        CancelInvoke("PlaceRockTiles");
    }
}
    private IEnumerator PlaceAndRemoveTiles()
    {
        while (shouldRemoveTiles)
        {
            // 원 안에 있는 타일을 제거합니다.
            int radiusB = circleDiameterB / 2;
            Vector3 centerPositionB = objectToPlaceTilesAt.transform.position;

            // 원 안에 있는 타일 중에서 특정 좌표와 관련된 타일만 제거합니다.
            int targetX = 0; // 원하는 x 좌표
            int targetY = 0; // 원하는 y 좌표

            // 원의 지름의 절반을 계산합니다.
            int halfDiameter = circleDiameterB / 2;

            // 원의 위, 아래, 좌, 우에 있는 타일을 제거합니다.
            tilemap.SetTile(new Vector3Int(targetX + halfDiameter + 3, targetY, 0), null);
            tilemap.SetTile(new Vector3Int(targetX - halfDiameter - 3, targetY, 0), null);
            tilemap.SetTile(new Vector3Int(targetX, targetY + halfDiameter + 3, 0), null);
            tilemap.SetTile(new Vector3Int(targetX, targetY - halfDiameter - 3, 0), null);

            // 주기의 2배 시간 기다립니다.
            yield return new WaitForSeconds(repeatInterval * 1f);
        }
    }

// 원하는 시점에 타일 제거를 중지할 수 있는 메서드
    public void StopTileRemoval()
    {
        shouldRemoveTiles = false;
    }

// 일정 시간 후에 게임 오브젝트를 제거하는 코루틴
IEnumerator DestroyAfterDelay(GameObject obj, float delay)
{
    yield return new WaitForSeconds(delay);
    Destroy(obj);
}


}
