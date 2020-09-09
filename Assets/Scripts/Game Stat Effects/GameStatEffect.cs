using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatEffect : MonoBehaviour
{
    [SerializeField] float value;
    string effectName;
    int gameStatEffectId;
    int gameStatEffectType;

    public string GetEffectName() {
        return effectName;
    }

    protected void SetEffectName(string effectName) {
        this.effectName = name;
    }

    public int GetGameStatEffectId() {
        return gameStatEffectId;
    }

    protected void SetGameStatEffectId(int gameStatEffectId) {
        this.gameStatEffectId = gameStatEffectId;
    }

    public int GetGameStatEffectType() {
        return gameStatEffectType;
    }

    protected void SetGameStatEffectType(int gameStatEffectType) {
        this.gameStatEffectType = gameStatEffectType;
    }

    public float GetValue() {
        return value;
    }

    public void SetValue(float value) {
        this.value = value;
    }
}
