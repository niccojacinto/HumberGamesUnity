using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Character))]
public class UIScript : MonoBehaviour {
    // Attach to the Arena Fighters

   public  enum Player { PLAYER1, PLAYER2 };

    Character characterComponent;
    public Text UITextHealth;
    public Player player = Player.PLAYER1;

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
        if (player == Player.PLAYER1) {
            UITextHealth.text = "Player 1 Health: " + hp;
        } else {
            UITextHealth.text = "Player 2 Health: " + hp;
        }

    }
}
