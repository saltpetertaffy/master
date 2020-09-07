using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Game Stats")]
    [SerializeField] int maximumHealth = 100;
    [SerializeField] int maximumArmor = 100;

    private int health;
    private int armor;

    private void Start() {
        health = maximumHealth;
        armor = maximumArmor;
    }

    public void AddHealth(int healthToAdd) {
        health = (health + healthToAdd > maximumHealth) ? maximumHealth : health + healthToAdd;
    }

    public void RemoveHealth(int healthToRemove) {
        health = (health < healthToRemove) ? 0 : health - healthToRemove;
        
        if (health == 0) {
            Die();
        }
    }

    public void AddArmor(int armorToAdd) {
        armor = (armor + armorToAdd > maximumArmor) ? maximumArmor : armor + armorToAdd;
    }

    public void RemoveArmor(int armorToRemove) {
        armor = (armor < armorToRemove) ? 0 : armor - armorToRemove;
    }

    private void Die() {

    }

    public int GetHealth() {
        return health;
    }

    public int GetMaximumHealth() {
        return maximumHealth;
    }
}
