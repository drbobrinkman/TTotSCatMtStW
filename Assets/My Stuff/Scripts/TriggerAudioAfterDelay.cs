using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudioAfterDelay : MonoBehaviour {
    private AudioSource storySource;
    public float delayInSeconds = 10.0f;
    float startTime;
    bool done = false;
    // Use this for initialization
    void Start () {
        storySource = GetComponent<AudioSource>();
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		if(!done && Time.time - startTime > delayInSeconds)
        {
            done = true;
            storySource.Play();
        }
	}
}
