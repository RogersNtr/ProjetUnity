using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour {
    [SerializeField] Transform target;
    Vector3 offsetCamera;
	// Use this for initialization
	void Start () {
        offsetCamera = transform.position - target.position;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 cameraPostion = target.position + offsetCamera;
        transform.position = cameraPostion;

    }
}
