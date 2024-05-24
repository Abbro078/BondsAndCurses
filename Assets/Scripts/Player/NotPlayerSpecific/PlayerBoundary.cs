using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D boundaryCollider;

    private void Update()
    {
        ConstrainPlayerWithinBoundary();
    }

    private void ConstrainPlayerWithinBoundary()
    {
        Bounds bounds = boundaryCollider.bounds;

        Vector3 playerPosition = transform.position;

        playerPosition.x = Mathf.Clamp(playerPosition.x, bounds.min.x, bounds.max.x);
        playerPosition.y = Mathf.Clamp(playerPosition.y, bounds.min.y, bounds.max.y);

        transform.position = playerPosition;
    }

}
