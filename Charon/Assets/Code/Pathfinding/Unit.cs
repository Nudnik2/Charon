using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Transform target;
    private float speed = 1.75f;

    private Vector3[] path;
    private int targetIndex;

    private Transform modelTransform;

    private void Start()
    {
        modelTransform = this.transform.GetChild(0).transform;
    }

    public void SetPathTarget(Transform targetPoint)
    {
        target = targetPoint;
        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if(pathSuccessful)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = ForceWaypointHeight(path[0]);
        bool hasReachedEnd = false;

        while(!hasReachedEnd)
        {
            if(transform.position == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    hasReachedEnd = true;
            
                }
                else
                {
                    //Force waypoint height
                    currentWaypoint = ForceWaypointHeight(path[targetIndex]);
                }            
            }

            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            modelTransform.LookAt(new Vector3(currentWaypoint.x,
                                              modelTransform.position.y,
                                              currentWaypoint.z));
            yield return null;
        }

        Destroy(this.gameObject);
    }

    //So NPC Doesn't Sink Down Into Ground
    private Vector3 ForceWaypointHeight(Vector3 waypoint)
    {
        Vector3 newWaypoint = new Vector3(waypoint.x,
                                          1,
                                          waypoint.z);
        return newWaypoint;
    }

    private void OnDrawGizmos()
    {
        if(path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }


}
