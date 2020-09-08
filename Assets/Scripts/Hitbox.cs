using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;

public class Hitbox : MonoBehaviour
{
    Health health;
    GameObject hitboxOwner;

    private void Start() {
        health = GetComponent<Health>();
    }

    public void HandleHit() {

    }
}
