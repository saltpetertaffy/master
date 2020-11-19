using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameStatEffect : MonoBehaviour
{
    [SerializeField] private float value;
    private string gameStatEffectName;
    private int gameStatEffectId;
    private int gameStatEffectCategory;

    public string GetEffectName() {
        return gameStatEffectName;
    }

    protected void SetEffectName(string gameStatEffectName) {
        this.gameStatEffectName = gameStatEffectName;
    }

    public int GetGameStatEffectId() {
        return gameStatEffectId;
    }

    protected void SetGameStatEffectId(int gameStatEffectId) {
        this.gameStatEffectId = gameStatEffectId;
    }

    public int GetGameStatEffectCategory() {
        return gameStatEffectCategory;
    }

    protected void SetGameStatEffectCategory(int gameStatEffectCategory) {
        this.gameStatEffectCategory = gameStatEffectCategory;
    }

    public float GetValue() {
        return value;
    }

    public void SetValue(float value) {
        this.value = value;
    }
}
