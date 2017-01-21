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
        gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, 1.152f); //Assuming gazeDirection is a unit vector, so 1 meter
	}
}
