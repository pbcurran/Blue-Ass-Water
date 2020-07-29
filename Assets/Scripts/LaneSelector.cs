using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSelector : MonoBehaviour
{
    Vector3 bottomCoords = new Vector3(0, -2.85f, -3);
    Vector3 topCoords = new Vector3(0, 20, 30);

    // Bottom Screen Locations
    Vector3 centreLaneBottomCoords = new Vector3(0, -2.57f, -3);
    Vector3 leftLaneBottomCoords = new Vector3(-1.55f, -2.57f, -3);
    Vector3 rightLaneBottomCoords = new Vector3(1.55f, -2.57f, -3);

    // Top Screen Locations
    Vector3 leftLaneTopCoords = new Vector3(-3, 20, 30);
    Vector3 centreLaneTopCoords = new Vector3(0, 20, 30);
    Vector3 rightLaneTopCoords = new Vector3(3, 20, 30);

    // this sets the coords if the user doens't hit one of the lanes before they fire their first shot
    void Start()
    {
        SetCentreBottomPosition();
    }

    // when setting up the unity inspector stuff had to put this into the green and red shot button as a sub function as well as the red 
    // and green shot functions. 
    // need to use the this. before the variable changes so that it works on the class variable not the one in the funciton.
    public void SetLeftBottomPosition()
    {
        this.bottomCoords = leftLaneBottomCoords;
        this.topCoords = leftLaneTopCoords;
    }

    public Vector3 GetLeftBottomPosition()
    {
        return leftLaneBottomCoords;
    }

    public void SetCentreBottomPosition()
    {
        this.bottomCoords = centreLaneBottomCoords;
        this.topCoords = centreLaneTopCoords;
    }

    public Vector3 GetCentreBottomPosition()
    {
        return centreLaneTopCoords;
    }

    public void SetRightBottomPosition()
    {
        this.bottomCoords = rightLaneBottomCoords;
        this.topCoords = rightLaneTopCoords;
    }
    public Vector3 GetRightBottomPosition()
    {
        return rightLaneTopCoords;
    }
    public Vector3 GetBottomPosition()
    {
        return this.bottomCoords;
    }

    public Vector3 GetTopPosition()
    {
        return this.topCoords;
    }
}
