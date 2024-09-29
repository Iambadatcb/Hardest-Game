using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject teleporter;
    public Renderer coinRenderer;
    public static int count;
    private bool isTeleporterActivated = false;

    void Start()
    {
        // Initialize the teleporter as inactive
        teleporter.SetActive(false);
        count = 0;

        // Get all coins in the scene
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        // Set the count to the number of coins
        count = coins.Length;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the player
        if (collision.gameObject.tag == "Player")
        {
            // Disable the current coin
            coinRenderer.enabled = false;
            GetComponent<SphereCollider>().enabled = false;

            // Decrement the count
            count--;

            // Check if the count is less than or equal to 0
            if (count <= 0)
            {
                // Activate the teleporter if it's not already active
                if (!isTeleporterActivated)
                {
                    teleporter.SetActive(true);
                    isTeleporterActivated = true;
                }
            }
        }
    }
}
