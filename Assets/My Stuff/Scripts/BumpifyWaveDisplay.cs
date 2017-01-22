using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpifyWaveDisplay : MonoBehaviour {
    private Vector3 velocity;

    private float maxDisplacement = 10.0f;
    private float maxSpeed = 0.0001f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        doJitter();
	}

    void doJitter()
    {
        //Particle should jitter a bit
        //First, apply a random accelerations to the velocity
        velocity += new Vector3(Random.Range(-maxSpeed / 5, maxSpeed / 5),
            0,
            Random.Range(-maxSpeed / 5, maxSpeed / 5));
        //Next, clamp velocities
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        //Then apply this to the localPosition, and clamp by maxDisplacement
        gameObject.transform.localPosition += velocity;
        gameObject.transform.localPosition = Vector3.ClampMagnitude(gameObject.transform.localPosition, maxDisplacement);
    }
}
