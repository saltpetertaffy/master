using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameStat : MonoBehaviour {
    private string gameStatId;
    private float gameStatValue;

    public string GetGameStatId() {
        return gameStatId;
    }

    public void SetGameStatId(string gameStatId) {
        this.gameStatId = gameStatId;
    }

    public float GetGameStatValue() {
        return gameStatValue;
    }

    public void SetGameStatValue(float value) {
        gameStatValue = value;
    }
}
