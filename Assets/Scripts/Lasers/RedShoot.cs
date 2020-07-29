using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShoot : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;

    // when creating this function need to pass in the class and assign it to the instance at the start of the function, this is where unity asks for the script
    // to be passed in at the inspector
    public void RedShot(LaneSelector laneSelector)
    {
        GameObject laser = Instantiate(laserPrefab, laneSelector.GetBottomPosition(), Quaternion.identity) as GameObject;
    }
}
