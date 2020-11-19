using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : GameStat {
    public float MaximumArmor { get; set; }    

    [Header("Game Stats")]
    [SerializeField] int freeArmor = 10;
    [Tooltip("Per Second")] [SerializeField] [Range(0, 10)] int armorDecayRate = 1;
    [SerializeField] int armorDecayAmount = 5;
    [SerializeField] int armorAbsorption = 5;

    private float armor;

    // Start is called before the first frame update
    private void Start() {
        if (GetComponent<MainCharacter>()) {
            MaximumArmor = FindObjectOfType<GameSession>().currentMaximumArmor;
        }
        armor = MaximumArmor;
        SetGameStatId(GameStats.STAT_ARMOR);
    }

    private void Update() {
        DecayArmor();
    }

    public void AddArmor(float armorToAdd) {
        armor = (armor + armorToAdd > MaximumArmor) ? MaximumArmor : armor + armorToAdd;
    }

    public void RemoveArmor(float armorToRemove) {
        armor = (armor < armorToRemove) ? 0 : armor - armorToRemove;
    }

    private void DecayArmor() {
        RemoveArmor(armorDecayAmount * armorDecayRate * Time.deltaTime);
    }

    public float GetArmor() {
        return armor;
    }

    public void SetArmor(float armor) {
        this.armor = armor;
    }

    public int GetFreeArmor() {
        return freeArmor;
    }

    public void SetFreeArmor(int freeArmor) {
        this.freeArmor = freeArmor;
    }

    public int getArmorDecayRate() {
        return armorDecayRate;
    }

    public void SetArmorDecayRate(int armorDecayRate) {
        this.armorDecayRate = armorDecayRate;
    }

    public int getArmorDecayAmount() {
        return armorDecayAmount;
    }

    public void SetArmorDecayAmount(int armorDecayAmount) {
        this.armorDecayAmount = armorDecayAmount;
    }

    public int GetArmorAbsoprtion() {
        return armorAbsorption;
    }

    public void SetArmorAbsorption(int armorAbsorption) {
        this.armorAbsorption = armorAbsorption;
    }
}
