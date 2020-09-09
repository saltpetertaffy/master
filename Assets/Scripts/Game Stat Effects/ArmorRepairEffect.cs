using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;

public class ArmorRepairEffect : GameStatEffect
{
    private void Start() {
        SetEffectName("Damage");
        SetGameStatEffectId((int) GameStatEffects.ARMOR_REPAIR);
    }
}
