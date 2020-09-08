using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeathBehavior : MonoBehaviour
{
    public bool isCompleted = false;

    public abstract void OnDeath();
}
