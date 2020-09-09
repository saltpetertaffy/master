using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatEffect : MonoBehaviour
{
    [SerializeField] float value;
    string effectName;
    int gameStatEffectId;

    protected void SetEffectName(string name) {
        effectName = name;
    }

    protected void SetGameStatEffectId(int id) {
        gameStatEffectId = id;
    }

    public string GetEffectName() {
        return effectName;
    }

    public float GetValue() {
        return value;
    }

    public int GetGameStatEffectId() {
        return gameStatEffectId;
    }
}
