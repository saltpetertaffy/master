using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBar : StatBar
{
    Armor mainCharacterArmor;

    // Start is called before the first frame update
    void Start() {
        mainCharacterArmor = FindObjectOfType<MainCharacter>().GetComponentInChildren<Armor>();
    }

    private void Update() {
        SetMaxStat(mainCharacterArmor.MaximumArmor);
        SetStat(mainCharacterArmor.CurrentArmor);
    }
}
