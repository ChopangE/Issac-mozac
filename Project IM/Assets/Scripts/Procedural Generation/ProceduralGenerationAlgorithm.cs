using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProceduralGenerationAlgorithm
{
    #region SimpleWalk
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
    {
        // HashSet: TKey가 없고 TValue만 존재하며, 마찬가지로 순서, 중복이 존재하지 않는다. 
        // VectorInt: int Type만 사용 가능한 Vector 

        HashSet<Vector2Int> path = new HashSet<Vector2Int>();
        
        path.Add(startPosition);
        var prevPosition = startPosition;

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = prevPosition + Direction2D.GetRandomCardinalDirection();
            path.Add(newPosition);
            prevPosition = newPosition; 
        }

        return path; 
    }
    #endregion

    #region Binary Partitioning 
    public static List<BoundsInt> BinarySpacePartitioning(BoundsInt spaceToSplit, int minWidth, int minHeight)
    {
        Queue<BoundsInt> roomsQueue = new Queue<BoundsInt>();
        List<BoundsInt> roomList = new List<BoundsInt>();
        roomsQueue.Enqueue(spaceToSplit); 
        while(roomsQueue.Count > 0)
        {
            var room = roomsQueue.Dequeue();
            if(room.size.y >= minHeight && room.size.x >= minWidth)
            {
                // Split horizontally or vertically 
                if(Random.value < 0.5f)
                {
                    // 이렇게 두 파트로 나뉜 이유는, 만약 random.value로 1/2를 설정하지 않았다면, 항상 Horizontal로 먼저 자르기 때문 
                    if(room.size.y >= minHeight * 2)
                    {
                        SplitHoriznotally(minWidth, roomsQueue, room);
                    }else if(room.size.x >= minWidth * 2)
                    {
                        SplitVertically(minHeight, roomsQueue, room); 
                    }else if(room.size.x >= minWidth && room.size.y >= minHeight)
                    {
                        roomList.Add(room); 
                    }
                }

                else
                {
                    if (room.size.x >= minWidth * 2)
                    {
                        SplitVertically(minWidth,roomsQueue, room);
                    }
                    else if (room.size.y >= minHeight * 2)
                    {
                        SplitHoriznotally(minHeight, roomsQueue, room);
                    }
                    else if (room.size.x >= minWidth && room.size.y >= minHeight)
                    {
                        roomList.Add(room);
                    }
                }
            }
        }
        return roomList; 
    }

    private static void SplitVertically(int minWidth, Queue<BoundsInt> roomsQueue, BoundsInt room)
    {
        var xSplit = Random.Range(1, room.size.x);
        BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(xSplit, room.size.y, room.size.z));
        BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x + xSplit, room.min.y, room.min.z), new Vector3Int(room.size.x - xSplit, room.size.y, room.size.z));
        roomsQueue.Enqueue(room1);
        roomsQueue.Enqueue(room2); 
    }

    private static void SplitHoriznotally(int minHeight, Queue<BoundsInt> roomsQueue, BoundsInt room)
    {
        var ySplit = Random.Range(1, room.size.y);
        BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(room.size.x, ySplit, room.size.z));
        BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x, room.min.y + ySplit, room.min.z), new Vector3Int(room.size.x, room.size.y - ySplit, room.size.z));
        roomsQueue.Enqueue(room1);
        roomsQueue.Enqueue(room2);
    }
    #endregion

    #region Corridor 
    public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPosition, int corridorLength)
    {
        List<Vector2Int> corridor = new List<Vector2Int>();
        var direction = Direction2D.GetRandomCardinalDirection();
        var currentPosition = startPosition; 
        corridor.Add(currentPosition);

        for (int i = 0; i < corridorLength; i++)
        {
            currentPosition += direction; 
            corridor.Add(currentPosition);
        }

        return corridor; 
    }
    #endregion 
}

public static class Direction2D
{
    // RandomWalk에서 움직일 방향을 제시 

    public static List<Vector2Int> cardinalDirectionList = new List<Vector2Int>
    {
        new Vector2Int(0, 1), // Up
        new Vector2Int(1, 0), // Right
        new Vector2Int(-1, 0), // Left
        new Vector2Int(0, -1) // Down
    };

    public static Vector2Int GetRandomCardinalDirection()
    {
        return cardinalDirectionList[Random.Range(0, cardinalDirectionList.Count)]; 
    }
}