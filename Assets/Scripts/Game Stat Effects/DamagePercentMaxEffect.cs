using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePercentMaxEffect : GameStatEffect 
    {
    private void Start() {
        SetEffectName("Percent Max Damage");
        SetGameStatEffectId((int) GameStatEffects.DAMAGE_PERCENT_MAX);
    }
}
