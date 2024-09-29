using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject teleporter;
    public Renderer coin;
    public int count = 0;
    private bool isTeleporterActivated = false;

    void Start()
    {
        teleporter.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (count >= 10)
        {
            if (!isTeleporterActivated)
            {
                teleporter.SetActive(true);
                isTeleporterActivated = true;
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                coin.enabled = false;
                coin.GetComponent<SphereCollider>().enabled = false;
                count++;
            }
        }
    }
}

