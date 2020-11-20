using GameConstants;
using UnityEngine;

public class UpgradeEffect
{
    public string GameStatKey { get; set; }
    public string UpgradeEffectType { get; set; }
    public float Value { get; set; }
    
    public UpgradeEffect (string statKey, string type, float value) {
        GameStatKey = statKey;
        UpgradeEffectType = type;
        Value = value;
    }
}
