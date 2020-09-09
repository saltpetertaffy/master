using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : GameStat
{
    [Header("Game Stats")]
    [SerializeField] float maximumHealth = 100f;

    [Header("Model")]
    [SerializeField] GameObject healthOwner;

    private float health;

    DeathBehavior[] deathBehaviors;

    private void Start() {
        deathBehaviors = GetComponents<DeathBehavior>();
        health = maximumHealth;
        SetGameStatId((int) BaseStats.HEALTH);
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

    public float GetHealth() {
        return health;
    }

    public float GetMaximumHealth() {
        return maximumHealth;
    }

    private void Die() {
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
        DeathBehavior[] deathBehaviors = GetComponents<DeathBehavior>();
        foreach (DeathBehavior deathBehavior in deathBehaviors) {
            deathBehavior.OnDeath();
        }
    }
}
