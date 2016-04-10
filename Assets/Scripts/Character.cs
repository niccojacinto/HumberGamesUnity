using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(AudioSource))]
public class Character : MonoBehaviour {

    public int health = 100;

    int heavyAttack = 40;
    int lightAttack = 15;

    public AudioClip sfxgrunt;
    public AudioClip sfxpain;
    public AudioClip sfxslice;

    CapsuleCollider collider;
    Rigidbody rigidbody;
    AudioSource audio;

    void Start() {
        collider = gameObject.GetComponent<CapsuleCollider>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
        audio = gameObject.GetComponent<AudioSource>();


        rigidbody.isKinematic = true;

        collider.radius = 0.03f;
        collider.height = 0.16f;
        collider.center = new Vector3(0, 0.08f, 0);
    }

    void Update() {
    }

    public void Slash() {

        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 1.0f, transform.forward, out hit, 1.0f)) { // Not Vector3.forward only because the characters are not facing the Z direction

            Debug.Log(hit.collider.gameObject.tag);
            Character chara = hit.collider.gameObject.GetComponent<Character>();
            if (chara == null) return;

            hit.collider.gameObject.GetComponent<AudioSource>().PlayOneShot(sfxpain);
            audio.PlayOneShot(sfxslice);
            chara.health -= lightAttack;
        }

    }

    public void Grunt() {
        audio.PlayOneShot(sfxgrunt);
    }

 
}
