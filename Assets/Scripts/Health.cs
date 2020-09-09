using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Game Stats")]
    [SerializeField] float maximumHealth = 100f;
    [SerializeField] float maximumArmor = 100f;
    [SerializeField] float armorDecayRate = 1f;

    [Header("Model")]
    [SerializeField] GameObject healthOwner;

    private float health;
    private float armor;

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

    public void AddHealth(float healthToAdd) {
        health = (health + healthToAdd > maximumHealth) ? maximumHealth : health + healthToAdd;
    }

    public void RemoveHealth(float healthToRemove) {
        if (healthToRemove < 0) { return; }

        health = (health < healthToRemove) ? 0 : health - healthToRemove;
        
        if (health == 0) {
            Die();
        }
    }

    public void AddArmor(float armorToAdd) {
        armor = (armor + armorToAdd > maximumArmor) ? maximumArmor : armor + armorToAdd;
    }

    public void RemoveArmor(float armorToRemove) {
        armor = (armor < armorToRemove) ? 0 : armor - armorToRemove;
    }

    public float GetHealth() {
        return health;
    }

    public float GetMaximumHealth() {
        return maximumHealth;
    }

    public float GetArmor() {
        return armor;
    }

    public float GetMaximumArmor() {
        return maximumArmor;
    }

    private void Die() {
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
        DeathBehavior[] deathBehaviors = GetComponents<DeathBehavior>();
        foreach (DeathBehavior deathBehavior in deathBehaviors) {
            deathBehavior.OnDeath();
        }
    }
}
