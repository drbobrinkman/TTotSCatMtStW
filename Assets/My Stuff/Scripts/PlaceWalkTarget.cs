using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceWalkTarget : MonoBehaviour {
    //Walk target should be at same level as avatar feed, but under the main camera
    private GameObject mainCam;

    private void Start()
    {
        mainCam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        var headPosition = mainCam.transform.position;
        headPosition.y = headPosition.y - 1.5f; //estimating that eyes to feet distance is 1.5m 
        gameObject.transform.position = headPosition; //Assuming gazeDirection is a unit vector, so 1 meter
    }
}
