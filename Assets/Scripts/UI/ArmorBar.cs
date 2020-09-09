using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBar : StatBar
{
    Health mainCharacterHealth;

    // Start is called before the first frame update
    void Start() {
        mainCharacterHealth = FindObjectOfType<MainCharacter>().GetComponentInChildren<Health>();
    }

    private void Update() {
        SetMaxStat(mainCharacterHealth.GetMaximumArmor());
        SetStat(mainCharacterHealth.GetArmor());
    }
}
