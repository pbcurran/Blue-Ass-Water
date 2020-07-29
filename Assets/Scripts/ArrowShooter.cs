using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{

    [SerializeField] GameObject blueLaserPrefab;
    [SerializeField] GameObject redLaserPrefab;
    
    // Update is called once per frame
    void Update()
    {
        ArrowShoot();
    }

    private void ArrowShoot()
    {
        LaneSelector laneSelector = FindObjectOfType<LaneSelector>();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject laser = Instantiate(blueLaserPrefab, laneSelector.GetBottomPosition(), Quaternion.identity) as GameObject;
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject laser = Instantiate(redLaserPrefab, laneSelector.GetBottomPosition(), Quaternion.identity) as GameObject;
        }
    }
}
