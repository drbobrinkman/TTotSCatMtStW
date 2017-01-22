using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotBehaviors : MonoBehaviour {
    private Color dotColor;
    private Vector3 velocity;

    private float maxDisplacement = 0.01f;
    private float maxSpeed = 0.0001f;
    private float minAlpha = 0.8f;
    private float curAlpha = 1.0f;
    private float flickerAmount = 0.1f;

    private Renderer rend;

	// Use this for initialization
	void Start () {
        //Select a random color, close to yellow
        dotColor = new Color(1.0f, Random.Range(0.5f, 1.0f), 0.0f);
        rend = GetComponent<Renderer>();
        rend.material.SetColor("_TintColor", dotColor);
    }
	
	// Update is called once per frame
	void Update () {
        doJitter();
        doFlicker();
    }

    void doJitter()
    {
        //Particle should jitter a bit
        //First, apply a random accelerations to the velocity
        velocity += new Vector3(Random.Range(-maxSpeed / 5, maxSpeed / 5),
            Random.Range(-maxSpeed / 5, maxSpeed / 5),
            Random.Range(-maxSpeed / 5, maxSpeed / 5));
        //Next, clamp velocities
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        //Then apply this to the localPosition, and clamp by maxDisplacement
        gameObject.transform.localPosition += velocity;
        gameObject.transform.localPosition = Vector3.ClampMagnitude(gameObject.transform.localPosition, maxDisplacement);
    }

    void doFlicker()
    {
        //flicker a bit
        curAlpha += Random.Range(-flickerAmount, flickerAmount);
        if (curAlpha < minAlpha) curAlpha = minAlpha;
        if (curAlpha > 1.0f) curAlpha = 1.0f;
        dotColor.a = curAlpha;
        rend.material.SetColor("_TintColor", dotColor);
    }
}
