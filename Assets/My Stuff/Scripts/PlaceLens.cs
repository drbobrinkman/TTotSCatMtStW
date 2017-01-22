using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceLens : MonoBehaviour {
    private GameObject mainCam;

    private void Start()
    {
        mainCam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update () {
        var headPosition = mainCam.transform.position;
        var gazeDirection = mainCam.transform.forward;
        //Put bowl .5 meter down (y) from head, in direction of gaze with y set to 0.
        /*gazeDirection.y = 0;
        gazeDirection.Normalize();
        headPosition.y -= 0.5f; //Move down .5 meters from head
        gameObject.transform.localPosition = headPosition + gazeDirection*0.25f; //Assuming gazeDirection is a unit vector, so 1 meter*/

        //Actually: Bowl should be .5 meters down from head, and in line with the person's gaze. It cannot be farther away than .5 meters,
        // which is the average length of a forearm
        var bowlPos = headPosition;
        if (gazeDirection.y < -0.01f)
        {
            var amountOfGazeDirection = -0.5f / gazeDirection.y;
            bowlPos = headPosition + amountOfGazeDirection * gazeDirection;
            //TODO: bring bowl back if too far away
            headPosition.y -= 0.5f;
            var bowlDist = Vector3.Distance(headPosition, bowlPos);
            if(bowlDist > 0.5f)
            {
                //Bowl too far, bring it back
                var bowlDir = bowlPos - headPosition;
                bowlDir.Normalize();
                bowlPos = headPosition + bowlDir * 0.5f;
            }
        } else
        {
            gazeDirection.y = 0;
            gazeDirection.Normalize();
            bowlPos = headPosition + gazeDirection;
            bowlPos.y -= 0.5f;
        }

        gameObject.transform.position = bowlPos;
	}
}
