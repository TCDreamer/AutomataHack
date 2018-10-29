using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailer : MonoBehaviour {

    [Range(0.0f, 100.0f)]
    public float LifeSpan;


	// Use this for initialization
	void Start () {
        //yield 
        DestroyTrailer();

	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, 5);
	}

    void DestroyTrailer()
    {
        Destroy(gameObject, LifeSpan);
    }
}
