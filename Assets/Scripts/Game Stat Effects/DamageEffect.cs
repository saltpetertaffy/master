using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : GameStatEffect
{
    private void Start() {
        SetEffectName("Damage");
        SetGameStatEffectId((int) GameStatEffects.DAMAGE);
        SetGameStatEffectType((int) GameStatEffectTypes.DAMAGE);
    }
}
