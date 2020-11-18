using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : GameStat {

    [Header("Game Stats")]
    [SerializeField] float maximumArmor = 100f;
    [SerializeField] int freeArmor = 10;
    [Tooltip("Per Second")] [SerializeField] [Range(0, 10)] int armorDecayRate = 1;
    [SerializeField] int armorDecayAmount = 5;
    [SerializeField] int armorAbsorption = 5;

    private float armor;

    // Start is called before the first frame update
    private void Start() {
        if (GetComponent<MainCharacter>()) {
            maximumArmor = FindObjectOfType<GameSession>().currentMaximumArmor;
        }
        armor = maximumArmor;
        SetGameStatId(GameStats.STAT_ARMOR);
    }

    private void Update() {
        DecayArmor();
    }

    public void AddArmor(float armorToAdd) {
        armor = (armor + armorToAdd > maximumArmor) ? maximumArmor : armor + armorToAdd;
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

    public float GetMaximumArmor() {
        return maximumArmor;
    }

    public void SetMaximumArmor(float maximumArmor) {
        this.maximumArmor = maximumArmor;
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
