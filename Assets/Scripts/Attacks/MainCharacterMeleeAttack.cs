using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMeleeAttack : MeleeAttack
{
    void Start()
    {
        targetLayer = GameKeys.LAYER_ENEMY_KEY;
    }
}
