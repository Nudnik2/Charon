using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingGrid : MonoBehaviour
{
    private PathfindingNode[,] pathfindingGrid;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public LayerMask unwalkableMask;

    private float nodeDiameter;
    private int gridSizeX;
    private int gridSizeY;

    [Header("Debug")]
    [SerializeField]
    private bool showDebug;

    public int MaxSize
    {
        get { return gridSizeX * gridSizeY; }
    }

    //Test
    public List<PathfindingNode> path;

    private void Awake()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);

        CreatePathfindingGrid();
    }

    private void CreatePathfindingGrid()
    {
        pathfindingGrid = new PathfindingNode[gridSizeX, gridSizeY];

        Vector3 worldBottomLeft = transform.position - Vector3.right * gridSizeX / 2 - Vector3.forward * gridSizeY / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius,unwalkableMask));
                pathfindingGrid[x, y] = new PathfindingNode(walkable, worldPoint,x,y);
            }
        }
    }
    
    public List<PathfindingNode> GetNodeNeighbours(PathfindingNode node)
    {
        List<PathfindingNode> neighbours = new List<PathfindingNode>();

        for (int x = -1 ; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbours.Add(pathfindingGrid[checkX, checkY]);
                }
            }
        }

        return neighbours;
    }

    public PathfindingNode NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;

        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return pathfindingGrid[x, y];
    }

    private void OnDrawGizmos()
    {
        if(showDebug)
        {
            //Draw boundaries
            Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

            //Draw Cubes
            if (pathfindingGrid != null)
            {
                foreach (PathfindingNode node in pathfindingGrid)
                {
                    Gizmos.color = (node.walkable) ? Color.white : Color.red;
                    Gizmos.DrawCube(node.worldPosition, Vector3.one * (nodeDiameter - 0.1f));
                }
            }
        }
    }
}
