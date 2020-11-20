using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameStat : MonoBehaviour {
    private string gameStatId;

    public string GetGameStatId() {
        return gameStatId;
    }

    public void SetGameStatId(string gameStatId) {
        this.gameStatId = gameStatId;
    }
}
