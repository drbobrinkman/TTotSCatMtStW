using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCoords : MonoBehaviour {
    private GameObject trkObj;
    private GameObject mainCam;

    private void Start()
    {
        trkObj = GameObject.Find("Cylinder");
        mainCam = GameObject.Find("Main Camera");
    }

	// Update is called once per frame
	void Update () {
        TextMesh textObject = GetComponent<TextMesh>();
        textObject.text = trkObj.transform.position.ToString() + "\n" + mainCam.transform.position.ToString() + "\n" + mainCam.transform.forward.ToString();
	}
}
