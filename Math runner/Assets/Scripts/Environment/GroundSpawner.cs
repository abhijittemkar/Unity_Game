using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab; // The ground prefab to be instantiated.
    public float groundZInterval = 40f; // Z-axis interval between ground spawns.
    public int maxGrounds = 3; // Maximum number of grounds to keep.
    public float PlayerDistanceThreshold = 10f; // Distance threshold for spawning grounds relative to the player.

    private float currentGroundZ = 0f; // The current Z-axis position for spawning ground.
    private List<GameObject> spawnedGrounds = new List<GameObject>(); // List to store references to spawned ground elements.
    private Transform PlayerTransform; // Reference to the player's transform.
    private bool hasSpawnedThisFrame = false; // Flag to ensure spawning happens only once per frame.

    private void Start()
    {
        // Find the player in the scene (assuming the player has a "Player" tag).
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {
            PlayerTransform = Player.transform;
        }
        else
        {
            Debug.LogError("Player not found in the scene. Make sure the player has the 'Player' tag.");
        }
    }

    private void Update()
    {
        // Reset the flag at the beginning of each frame.
        hasSpawnedThisFrame = false;

        // Check if the playerTransform is assigned.
        if (PlayerTransform != null)
        {
            // Calculate the distance between the current player position and the spawn position.
            float PlayerDistance = Mathf.Abs(PlayerTransform.position.z - currentGroundZ);

            // Check if the player is within the spawn distance threshold and has not spawned this frame.
            if (PlayerDistance < PlayerDistanceThreshold && !hasSpawnedThisFrame)
            {
                // Set the flag to prevent further spawning this frame.
                hasSpawnedThisFrame = true;

                // Increment the Z-axis position for each new ground.
                currentGroundZ += groundZInterval;

                // Spawn a ground element.
                GameObject newGround = Instantiate(groundPrefab, new Vector3(0f, 0f, currentGroundZ), Quaternion.identity);

                // Store references to the spawned ground elements.
                spawnedGrounds.Add(newGround);

                // Ensure the number of stored ground elements does not exceed the maximum limit.
                while (spawnedGrounds.Count > maxGrounds)
                {
                    // Destroy the oldest ground element.
                    Destroy(spawnedGrounds[0]);
                    spawnedGrounds.RemoveAt(0);
                }
            }
        }
    }
}