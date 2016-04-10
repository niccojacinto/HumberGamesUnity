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

    public void Slash() {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.left, out hit, 20.0f)) { // Not Vector3.forward only because the characters are not facing the Z direction

            Debug.Log(hit.collider.gameObject.tag);
            Character chara = hit.collider.gameObject.GetComponent<Character>();
            if (chara == null) return;

            chara.health -= lightAttack;
        }
        else {
            //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //cube.transform.position = (transform.position + Vector3.forward * 10.0f);
            Debug.Log("Didn't Hit Anything");
        }
    }
 
}
