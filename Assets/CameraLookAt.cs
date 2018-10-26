using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {

    public Transform lookatTarget;

    [Range(0,100)]
    public float Speed;

    private float cameraSpeed {  get { return Speed / 100f; } }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 forward = transform.forward;
        Vector3 lookat = lookatTarget.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(lookat);

        transform.rotation = Quaternion.Lerp(transform.rotation, rot, cameraSpeed);
        
        //transform.LookAt(lookatTarget.position  );
	}
}
