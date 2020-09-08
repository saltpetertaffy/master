using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeathBehavior : MonoBehaviour
{
    [HideInInspector] public bool isCompleted = false;

    public abstract void OnDeath();
}
