using GameConstants;
using UnityEngine;

public class UpgradeEffect
{
    public string gameStatKey;
    public string upgradeEffectType;
    public float value;
    
    public UpgradeEffect (string statKey, string type, float value) {
        this.gameStatKey = statKey;
        this.upgradeEffectType = type;
        this.value = value;
    }
}
