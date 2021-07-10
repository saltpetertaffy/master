using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    GameStatHandler gameStatHandler;

    private void Start() {
        gameStatHandler = GetComponentInParent<GameStatHandler>();
    }

    public void HandleHit(EffectSet projectileEffectSet) {
        foreach (StatEffect effect in projectileEffectSet.effects) {
            gameStatHandler.ModifyStat(effect);
        }
    }
}
