using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAvatarOnFloor : MonoBehaviour {

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
        curPosition.y = headPosition.y - 1.5f; //estimating that eyes to feet distance is 1.5m 
        gameObject.transform.position = curPosition; //Assuming gazeDirection is a unit vector, so 1 meter
    }
}
