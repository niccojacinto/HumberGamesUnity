using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class Item : MonoBehaviour {

    Transform myTransform;


    float rotationSpeed = 2.0f;


	// Use this for initialization
	void Start () {
        myTransform = transform;
        gameObject.GetComponent<Item>().hideFlags = HideFlags.HideInInspector;
    }
	
	// Update is called once per frame
	void Update () {
        myTransform.Rotate(new Vector3(0, rotationSpeed, 0));
	}

    public virtual void OnTriggerEnter(Collider collider) {

    }

    public virtual void OnPickup() {

    }
}
