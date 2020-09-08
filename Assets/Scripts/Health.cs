using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Game Stats")]
    [SerializeField] int maximumHealth = 100;
    [SerializeField] int maximumArmor = 100;

    [Header("Model")]
    [SerializeField] GameObject healthOwner;

    private int health;
    private int armor;

    DeathBehavior[] deathBehaviors;

    private void Start() {
        deathBehaviors = GetComponents<DeathBehavior>();
        health = maximumHealth;
        armor = maximumArmor;
    }

    private void Update() {
        if (ReadyToDie()) {
            Destroy(healthOwner);
        }
    }

    private bool ReadyToDie() {
        foreach (DeathBehavior deathBehavior in deathBehaviors) {
            if (!deathBehavior.isCompleted) {
                return false;
            }
        }
        return true;
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

    public int GetHealth() {
        return health;
    }

    public int GetMaximumHealth() {
        return maximumHealth;
    }

    private void Die() {
        DeathBehavior[] deathBehaviors = GetComponents<DeathBehavior>();
        foreach (DeathBehavior deathBehavior in deathBehaviors) {
            deathBehavior.OnDeath();
        }
    }
}
