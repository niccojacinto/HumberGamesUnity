using UnityEngine;
using System.Collections;

public class Siren : MonoBehaviour {
    Transform myTransform;
    float rotationSpeed = 1.0f;

	// Use this for initialization
	void Start () {
        myTransform = transform;
    }
	
	// Update is called once per frame
	void Update () {
        myTransform.Rotate(new Vector3(0, 0, rotationSpeed));
    }
}
