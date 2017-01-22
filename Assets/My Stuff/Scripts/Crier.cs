using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crier : MonoBehaviour {
    private Renderer rend;
    private float lastCryTime = 0.0f;
    private float timeToNextCry = 5.0f;
    private Vector4 lastCryLoc = new Vector4( 0, -1.4f, 0, 0 );
    private GameObject parentObject;

    public List<AudioClip> cryClips;
    private AudioSource crySource;

    // Use this for initialization
    void Start () {
        parentObject = gameObject.transform.parent.gameObject;
        rend = parentObject.GetComponent<Renderer>();
        crySource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        float now = Time.time;
        rend.material.SetFloat("_CurTime", now);

        if(now - lastCryTime > timeToNextCry)
        {
            lastCryTime = now;
            rend.material.SetFloat("_LastCryTime", now);

            timeToNextCry = Random.Range(4.0f, 6.0f);

            lastCryLoc.x = Random.Range(-5.0f, 5.0f);
            lastCryLoc.z = Random.Range(-5.0f, 5.0f);

            rend.material.SetVector("_CryLocation", lastCryLoc);

            playCry();
        }
    }

    private void playCry()
    {
        if (cryClips.Count > 0)
        {
            int whichClip = Random.Range(0, cryClips.Count);
            crySource.transform.position = lastCryLoc;
            crySource.PlayOneShot(cryClips[whichClip]);
            //Debug.Log("pew!");
        }
    }
}
