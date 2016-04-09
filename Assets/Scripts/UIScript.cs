using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Character))]
public class UIScript : MonoBehaviour {
    // Attach to the Arena Fighters

    Character characterComponent;
    public Text UITextHealth;

	// Use this for initialization
	void Start () {
        characterComponent = gameObject.GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateHealthUI();
	}

    void UpdateHealthUI() {
        int hp = characterComponent.health;
        UITextHealth.text = "Player 1 Health: " + hp;
    }
}
