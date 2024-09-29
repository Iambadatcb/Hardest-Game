using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyPlayerEnter : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player")
        {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>(), false);
        }
        else
        {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>(), true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag != "Player")
        {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>(), true);
        }
    }
}
