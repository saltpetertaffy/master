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
    private bool isDead = false;

    DeathBehavior[] deathBehaviors;

    DebugOptions debugOptions;

    private void Start() {
        deathBehaviors = GetComponents<DeathBehavior>();
        debugOptions = FindObjectOfType<DebugOptions>();
        health = maximumHealth;
        SetGameStatId((int) GameStats.HEALTH);
    }

    private void Update() {
        if (isDead && ReadyToDie()) {
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
        bool isGodmodedMainCharacter = GetComponentInParent<MainCharacter>() && debugOptions.godMode;
        if (healthToRemove < 0 || isGodmodedMainCharacter) { return; }

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

    public float GetMissingHealth() {
        return maximumHealth - health;
    }

    private void Die() {
        isDead = true;
        if (GetComponentInParent<MainCharacter>()) {
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
        DeathBehavior[] deathBehaviors = GetComponents<DeathBehavior>();
        foreach (DeathBehavior deathBehavior in deathBehaviors) {
            deathBehavior.OnDeath();
        }
    }
}
