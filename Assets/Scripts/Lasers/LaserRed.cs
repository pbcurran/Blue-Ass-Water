using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRed : MonoBehaviour
{
    public int laserIdentifier = 2;
    [SerializeField] float moveSpeed = 1.0f;

    Vector3 targetPosition;

    Vector3 centreBottomCoords = new Vector3(0, -2.57f, -3);
    Vector3 leftBottomCoords = new Vector3(-1.55f, -2.57f, -3);
    Vector3 rightBottomCoords = new Vector3(1.55f, -2.57f, -3);

    Vector3 leftTopCoords = new Vector3(-3, 20, 30);
    Vector3 centreTopCoords = new Vector3(0, 20, 30);
    Vector3 rightTopCoords = new Vector3(3, 20, 30);

    // this is used so that the laser is destroyed when it hits a gem in the game

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

    // Start method is here to assign the target desintation of the gem and have it change for the
    // lifetime if the instance of this laser
    void Start()
    {
        SetTargetCoords();
    }

    private void SetTargetCoords()
    {
        LaneSelector laneSelector = FindObjectOfType<LaneSelector>();

        if (laneSelector.GetBottomPosition() == centreBottomCoords)
        {
            this.targetPosition = centreTopCoords;
        }
        else if (laneSelector.GetBottomPosition() == leftBottomCoords)
        {
            this.targetPosition = leftTopCoords;
        }
        else if (laneSelector.GetBottomPosition() == rightBottomCoords)
        {
            this.targetPosition = rightTopCoords;
        }
    }

    void Update()
    {
        Move(this.targetPosition);
    }

    private void Move(Vector3 targetPosition)
    {
        var movementThisFrame = moveSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

        if (transform.position == targetPosition)
        {
            Destroy(gameObject);
        }
    }

}
