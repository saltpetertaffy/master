using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : AimedAbility
{
    override public void Initialize()
    {
        AbilityId = GameKeys.ABILITY_SPARK_KEY;
        base.Start();
    }
}
