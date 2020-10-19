using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePercentRemainingEffect : GameStatEffect
{
    private void Start() {
        SetEffectName("Percent Remaining Damage");
        SetGameStatEffectId((int) GameStatEffects.DAMAGE_PERCENT_REMAINING);
        SetGameStatEffectType((int) GameStatEffectTypes.DAMAGE);
    }
}
