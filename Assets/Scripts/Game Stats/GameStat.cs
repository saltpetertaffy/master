using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameStat : MonoBehaviour {
    private int gameStatId;

    public int GetGameStatId() {
        return gameStatId;
    }

    public void SetGameStatId(int gameStatId) {
        this.gameStatId = gameStatId;
    }
}
