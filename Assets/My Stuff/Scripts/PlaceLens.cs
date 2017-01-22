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

        var armLength = 0.4f;
        var bowlDepth = 0.5f;

        //Actually: Bowl should be .5 meters down from head, and in line with the person's gaze. It cannot be farther away than .5 meters,
        // which is the average length of a forearm
        var bowlPos = headPosition;
        if (gazeDirection.y < -0.01f)
        {
            var amountOfGazeDirection = -bowlDepth / gazeDirection.y;
            bowlPos = headPosition + amountOfGazeDirection * gazeDirection;
 
            headPosition.y -= bowlDepth;
            var bowlDist = Vector3.Distance(headPosition, bowlPos);
            if(bowlDist > armLength)
            {
                //Bowl too far, bring it back
                var bowlDir = bowlPos - headPosition;
                bowlDir.Normalize();
                bowlPos = headPosition + bowlDir * armLength;
            }
        } else
        {
            gazeDirection.y = 0;
            gazeDirection.Normalize();
            bowlPos = headPosition + gazeDirection * armLength;
            bowlPos.y -= bowlDepth;
        }

        gameObject.transform.position = bowlPos;
        var headfwd = mainCam.transform.forward;
        headfwd.y = 0.0f;
        headfwd.Normalize();
        gameObject.transform.forward = headfwd;
	}
}
