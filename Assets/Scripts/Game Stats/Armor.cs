using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : GameStat {
    public float MaximumArmor { get; set; }  
    public float CurrentArmor { get; set; }
    public float ArmorDecayAmount { get; set; }
    public float ArmorDecayRate { get; set; }
    public float ArmorAbsorption { get; set; }
    public float FreeArmor { get; set; }

    // Start is called before the first frame update
    private void Start() {
        if (GetComponent<MainCharacter>()) {
            MaximumArmor = FindObjectOfType<GameSession>().currentMaximumArmor;
        }
        CurrentArmor = MaximumArmor;
        SetGameStatId(GameStats.STAT_ARMOR);
    }

    private void Update() {
        DecayArmor();
    }

    public void AddArmor(float armorToAdd) {
        CurrentArmor = (CurrentArmor + armorToAdd > MaximumArmor) ? MaximumArmor : CurrentArmor + armorToAdd;
    }

    public void RemoveArmor(float armorToRemove) {
        CurrentArmor = (CurrentArmor < armorToRemove) ? 0 : CurrentArmor - armorToRemove;
    }

    private void DecayArmor() {
        RemoveArmor(ArmorDecayAmount * ArmorDecayRate * Time.deltaTime);
    }
}
