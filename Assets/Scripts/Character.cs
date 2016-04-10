using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Character : MonoBehaviour {

    public int health = 100;

    int heavyAttack = 40;
    int lightAttack = 15;

    CapsuleCollider collider;
    Rigidbody rigidbody;

    void Start() {
        collider = gameObject.GetComponent<CapsuleCollider>();
        rigidbody = gameObject.GetComponent<Rigidbody>();

        rigidbody.isKinematic = true;

        collider.radius = 0.03f;
        collider.height = 0.16f;
        collider.center = new Vector3(0, 0.08f, 0);
    }

    void Update() {
    }
 
}
