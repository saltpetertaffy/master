using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiProjectileShape : MonoBehaviour
{
    // Update is called once per frame
    void Update() {
        int projectileCount = GetComponentsInChildren<Projectile>().Length;
        if (projectileCount == 0) {
            Destroy(gameObject);
        }
    }
}
