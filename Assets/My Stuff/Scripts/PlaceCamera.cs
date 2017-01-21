using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCamera : MonoBehaviour {

    private GameObject mainCam;

    private void Start()
    {
        mainCam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = mainCam.transform.position;
        gameObject.transform.rotation = mainCam.transform.rotation;
    }
}
