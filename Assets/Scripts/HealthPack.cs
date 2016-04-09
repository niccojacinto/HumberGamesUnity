using UnityEngine;
using System.Collections;

public class HealthPack : Item {

    int healthGiven = 5;

    void OnCollisionEnter(Collision collision) {
        Character charComponent = collision.gameObject.GetComponent<Character>();
        if (charComponent == null) return;
        onPickup(charComponent);
        Destroy(gameObject);
    }

    void onPickup(Character charComponent) {
        charComponent.health += healthGiven;
    }
}
