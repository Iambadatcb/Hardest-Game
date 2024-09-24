using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    //unity initialize the PUBLIC list for us
    public List<Vector3> path;
    public float speed = 2.0f;

    public bool reverse = false;

    //unity doesnt initialize the PRIVATE list for us
    //private List<Vector3> path = new();

    private int index = 0;

    
    void Update()
    {
        //allow 0.3 m of error
        if(Vector3.Distance(transform.position, path[index]) < 0.3f)
        {
            index++;

            //if index is greater than or equal to the number of elements in the list
            if(index >= path.Count)
            {
                index = 0;

                if (reverse) path.Reverse();
                             
            }
        }

        transform.LookAt(path[index]);
        transform.position += transform.forward * speed * Time.deltaTime;
    }


    private void OnDrawGizmos() 
    {
        //Gizmos class is a unity class that allows us to draw shapes in the scene view
        //Gizmos.color sets the color of the shape
        //Gizmos.DrawLine draws a line between two points

        Gizmos.color = Color.red;
        for (int i = 0; i < path.Count - 1; i++)
        {
            Gizmos.DrawLine(path[i], path[i + 1]);
        }
    }
}
