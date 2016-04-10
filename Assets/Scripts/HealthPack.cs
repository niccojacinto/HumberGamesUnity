using UnityEngine;
using System.Collections;

public class HealthPack : Item {

    int healthGiven = 5;

    //void Start() {
        // gameObject.GetComponent<Renderer>().material.SetColor("_SpecColor", Color.red);
    //}

    void OnTriggerEnter(Collider collider) {
        Character charComponent = collider.gameObject.GetComponent<Character>();
        if (charComponent == null) return;
        onPickup(charComponent);
        Destroy(gameObject);
    }

    void onPickup(Character charComponent) {
        charComponent.health += healthGiven;
    }
}
