using GameConstants;
using UnityEngine;

public class StatEffect
{
    public string gameStatKey;
    public string effectType;
    public float value;
    
    public StatEffect (string statKey, string type, float value) {
        this.gameStatKey = statKey;
        this.effectType = type;
        this.value = value;
    }
}
