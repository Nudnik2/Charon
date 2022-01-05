using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingNode : IHeapItem<PathfindingNode>
{
    public bool walkable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;
    public PathfindingNode parent;

    private int heapIndex;

    public int fCost { get { return gCost + hCost; } }

    public PathfindingNode(bool _walkable, Vector3 _worldPosition, int _gridX, int _gridY)
    {
        walkable = _walkable;
        worldPosition = _worldPosition;

        gridX = _gridX;
        gridY = _gridY;
    }

    public int HeapIndex
    {
        get
        {
            return heapIndex;
        }

        set
        {
            heapIndex = value;
        }
    }

    public int CompareTo(PathfindingNode nodeToCompare)
    {
        int compare = fCost.CompareTo(nodeToCompare.fCost);

        if(compare == 0)
        {
            compare = hCost.CompareTo(nodeToCompare.hCost);
        }
        return -compare;
    }
}