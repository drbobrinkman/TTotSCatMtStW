using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToTarget : MonoBehaviour {

    private GameObject walkTarget;
    private GameObject mainCam;
    //private Animator anim;
    private AudioSource footstepSource;
    private float lastStepTime = 0.0f;

    public List<AudioClip> stepClips;

    private void Start()
    {
        walkTarget = GameObject.Find("Walk Target");
        mainCam = GameObject.Find("Main Camera");
        footstepSource = GetComponent<AudioSource>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var cutOff = 0.1f; //10cm
        var timePerStep = 1.0f;

        var footPosition = walkTarget.transform.position;
        var headPosition = mainCam.transform.position;
        var avPosition = gameObject.transform.position;
        //Ignore elevation differences
        headPosition.y = 0.0f;
        avPosition.y = 0.0f;

        var dist = Vector3.Distance(headPosition, avPosition);
        if(dist > cutOff)
        {
            //anim.SetFloat("Walk", 1.0f);
            //This section only needed if not using an animated avatar
            var walkDir = footPosition - avPosition;
            walkDir.Normalize();
            gameObject.transform.position += 1.0f * walkDir * Time.deltaTime;

            gameObject.transform.LookAt(walkTarget.transform);
            float now = Time.time;
            if(now - lastStepTime >= timePerStep)
            {
                lastStepTime = now;
                playStep();
            }

        } else
        {
            //anim.SetFloat("Walk", 0.0f);
            var fwd = mainCam.transform.forward;
            fwd.y = 0;
            fwd.Normalize();
            gameObject.transform.LookAt(walkTarget.transform.position + fwd); 
        }
    }

    private void playStep()
    {
        if (stepClips.Count > 0) { 
            int whichClip = Random.Range(0, stepClips.Count);
            footstepSource.PlayOneShot(stepClips[whichClip]);
        }
    }
}
