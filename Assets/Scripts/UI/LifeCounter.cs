using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    TextMeshProUGUI lifeCounterText;

    private void Start() {
        lifeCounterText = GetComponent<TextMeshProUGUI>();
        lifeCounterText.text = "Lives: " + FindObjectOfType<GameSession>().lives;
    }
}
