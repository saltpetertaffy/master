using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour {

    [Header("Game Stats")]
    [SerializeField] float maximumArmor = 100f;
    [SerializeField] int freeArmor = 10;
    [Tooltip("Per Second")] [SerializeField] [Range(0, 10)] int armorDecayRate = 1;
    [SerializeField] int armorDecayAmount = 5;

    private float armor;

    // Start is called before the first frame update
    private void Start() {
        armor = maximumArmor;
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

    public float GetArmor() {
        return armor;
    }

    public float GetMaximumArmor() {
        return maximumArmor;
    }

    private void DecayArmor() {
        RemoveArmor(armorDecayAmount * armorDecayRate * Time.deltaTime);
    }
}
