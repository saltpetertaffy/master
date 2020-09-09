using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    GameStatHandler gameStatHandler;

    private void Start() {
        gameStatHandler = GetComponent<GameStatHandler>();
    }

    public void HandleHit(GameStatEffect[] projectileEffects) {
        gameStatHandler.ProcessEffects(projectileEffects);
    }
}
