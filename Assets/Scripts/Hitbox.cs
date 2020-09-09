using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    BaseStatHandler baseStatHandler;

    private void Start() {
        baseStatHandler = GetComponent<BaseStatHandler>();
    }

    public void HandleHit(GameStatEffect[] projectileEffects) {
        baseStatHandler.ProcessEffects(projectileEffects);
    }
}
