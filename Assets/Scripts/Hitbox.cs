using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    GameStatHandler gameStatHandler;

    private void Start() {
        gameStatHandler = GetComponentInParent<GameStatHandler>();
    }

    public void HandleHit(StatEffect[] projectileEffects) {
        foreach (StatEffect effect in projectileEffects) {
            gameStatHandler.ModifyStat(effect);
        }
    }
}
