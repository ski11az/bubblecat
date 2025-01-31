using System.Collections.Generic;
using UnityEngine;

public class SuctionPath : MonoBehaviour
{
    public List<Transform> waypoints; // List of waypoints defining the path
    public float suctionForce = 10f; // Force to pull the player
    public float waypointRadius = 1f; // Distance to consider a waypoint "reached"
    public Rigidbody2D playerRigidbody; // Reference to the player's Rigidbody2D
    public Bubble currentBubble;
    public CircleCollider2D circleCollider;
    private int currentWaypointIndex = 0;
    private void Start()
    {
        enabled = false;
    }
    void Update()
    {
        if (currentWaypointIndex >= waypoints.Count) return;

        Transform currentWaypoint = waypoints[currentWaypointIndex];
        Vector2 direction = (currentWaypoint.position - playerRigidbody.transform.position).normalized;

        // Apply force to pull the player toward the current waypoint
        currentBubble.AddForceToJoints(direction * suctionForce);

        // Check if the player has reached the current waypoint
        if (Vector2.Distance(playerRigidbody.transform.position, currentWaypoint.position) <= waypointRadius)
        {
            currentWaypointIndex++; // Move to the next waypoint
        }
        if (currentWaypointIndex >= waypoints.Count)
        {

            circleCollider.enabled = true;
            currentBubble.canRise = true;
            circleCollider = null;
            playerRigidbody = null;
            currentBubble = null;
            currentWaypointIndex = 0;
            enabled = false; // Stop pulling the player
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bone"))
        {
            currentBubble = other.GetComponentInParent<Bubble>();
            playerRigidbody = other.GetComponent<Rigidbody2D>();
            currentBubble.canRise = false;
            circleCollider = other.GetComponent<CircleCollider2D>();
            circleCollider.enabled = false;
            enabled = true; // Start pulling the player
        }
    }
}