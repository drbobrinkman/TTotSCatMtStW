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
        //Put bowl 1 meter down (y) from head, in direction of gaze with y set to 0.
        gazeDirection.y = 0;
        gazeDirection.Normalize();
        headPosition.y -= 0.5f; //Move down .5 meters from head
        gameObject.transform.localPosition = headPosition + gazeDirection*0.25f; //Assuming gazeDirection is a unit vector, so 1 meter
	}
}
