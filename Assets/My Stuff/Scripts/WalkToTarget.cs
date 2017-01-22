using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToTarget : MonoBehaviour {

    private GameObject walkTarget;
    private GameObject mainCam;
    private Animator anim;

    private void Start()
    {
        walkTarget = GameObject.Find("Walk Target");
        mainCam = GameObject.Find("Main Camera");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var cutOff = 0.1f; //10cm

        var footPosition = walkTarget.transform.position;
        var headPosition = mainCam.transform.position;
        var avPosition = gameObject.transform.position;
        //Ignore elevation differences
        headPosition.y = 0.0f;
        avPosition.y = 0.0f;

        var dist = Vector3.Distance(headPosition, avPosition);
        if(dist > cutOff)
        {
            anim.SetFloat("Walk", 1.0f);
            gameObject.transform.LookAt(walkTarget.transform);

        } else
        {
            anim.SetFloat("Walk", 0.0f);
        }
    }
}
