using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;

public class ArmorRepairEffect : GameStatEffect
{
    private void Start() {
        SetEffectName("Armor Repair");
        SetGameStatEffectId((int) GameStatEffects.ARMOR_REPAIR);
        SetGameStatEffectType((int) GameStatEffectTypes.ARMOR_REPAIR);
    }
}
