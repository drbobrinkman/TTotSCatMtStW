using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotControllerBehaviors : MonoBehaviour {
    public float dotSpacing = 0.1f;
    public float dotExtent = 5.0f; //This matches the size of Plane
    public GameObject dotPrefab = null;

    public class Cry
    {
        public float when;
        public Vector3 where;
    }
    public List<Cry> cries;

    // Use this for initialization
	void Start () {
        /*for(float x = -dotExtent; x <= dotExtent; x += dotSpacing)
        {
            for(float z = -dotExtent; z <= dotExtent; z += dotSpacing)
            {
                GameObject go = (GameObject)Instantiate(dotPrefab);
                go.transform.SetParent(gameObject.transform);
                go.transform.localPosition = new Vector3(x, 0, z);
            }
        }*/
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(1 / Time.deltaTime);
    }
}
