using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : AimedAbility
{
    // Start is called before the first frame update
    void Start()
    {
        SetAbilityId(GameKeys.ABILITY_SPARK_KEY);
        SetAbilityPrefab("Prefabs/Abilities/Spark");
    }
}
