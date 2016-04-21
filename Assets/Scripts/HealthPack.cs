using UnityEngine;
using System.Collections;

public class HealthPack : Item {

    int healthGiven = 5;

    override
    public void Start() {
        base.Start();

    }

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
