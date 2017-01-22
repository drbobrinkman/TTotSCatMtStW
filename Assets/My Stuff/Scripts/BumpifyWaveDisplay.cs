using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpifyWaveDisplay : MonoBehaviour {
    private Vector3 velocity;

    public float maxDisplacement = 5.0f;
    public float maxSpeed = 0.0001f;
    public float howBumpy = 0.1f;

    // Use this for initialization
    void Start () {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        int i = 0;
        while (i < vertices.Length)
        {
            vertices[i].y += Random.Range(-howBumpy, howBumpy);
            i++;
        }
        mesh.vertices = vertices;
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
        velocity.y = 0.0f;

        //Then apply this to the localPosition, and clamp by maxDisplacement
        var newLocalPos = gameObject.transform.localPosition;
        newLocalPos += velocity;
        newLocalPos.y = 0.1f;
        newLocalPos = Vector3.ClampMagnitude(newLocalPos, maxDisplacement);
        newLocalPos.y = 0.1f;
        gameObject.transform.localPosition = newLocalPos;
    }
}
