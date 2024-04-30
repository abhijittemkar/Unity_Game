using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    public GameObject portalPrefab; // The portal prefab to be instantiated.
    public Transform spawnPointLeft; // The left spawn point.
    public Transform spawnPointRight; // The right spawn point.
    public float spawnZInterval = 15f; // Z-axis interval between portal spawns.
    public int maxPortals = 3; // Maximum number of portals to keep.
    public float PlayerDistanceThreshold = 10f; // Distance threshold for spawning portals relative to the player.

    private float currentSpawnZ = 0f; // The current Z-axis position for spawning.
    private List<GameObject> spawnedPortals = new List<GameObject>(); // List to store references to spawned portals.
    private Transform PlayerTransform; // Reference to the player's transform.

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
        // Check if the playerTransform is assigned.
        if (PlayerTransform != null)
        {
            // Calculate the distance between the current player position and the spawn position.
            float PlayerDistance = Mathf.Abs(PlayerTransform.position.z - currentSpawnZ);

            // Check if the player is within the spawn distance threshold.
            if (PlayerDistance < PlayerDistanceThreshold)
            {
                // Increment the Z-axis position for each new portal.
                currentSpawnZ += spawnZInterval;

                // Spawn a portal on the left.
                GameObject leftPortal = Instantiate(portalPrefab, new Vector3(spawnPointLeft.position.x, spawnPointLeft.position.y, currentSpawnZ), spawnPointLeft.rotation);

                // Spawn a portal on the right.
                GameObject rightPortal = Instantiate(portalPrefab, new Vector3(spawnPointRight.position.x, spawnPointRight.position.y, currentSpawnZ), spawnPointRight.rotation);

                // Store references to the spawned portals.
                spawnedPortals.Add(leftPortal);
                spawnedPortals.Add(rightPortal);

                // Ensure the number of stored portals does not exceed the maximum limit.
                while (spawnedPortals.Count > maxPortals)
                {
                    // Destroy the oldest portal.
                    Destroy(spawnedPortals[0]);
                    spawnedPortals.RemoveAt(0);
                }
            }
        }
    }
}
