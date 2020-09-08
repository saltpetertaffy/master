using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePercentRemainingEffect : GameStatEffect
{
    private void Start() {
        SetEffectName("Percent Remaining Damage");
        SetGameStatEffectId(GameConfigConstants.EFFECT_ID_DAMAGE_PERCENT_REMAINING);
    }
}
