using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceFloor : MonoBehaviour {
    private GameObject mainCam;

    private void Start()
    {
        mainCam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        var headPosition = mainCam.transform.position;
        var curPosition = gameObject.transform.position;
        curPosition.y = headPosition.y - 2.25f; //Underground is 2.25 meters down from head 
        gameObject.transform.position = curPosition; //Assuming gazeDirection is a unit vector, so 1 meter
    }
}
