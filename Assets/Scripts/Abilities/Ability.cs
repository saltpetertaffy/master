using System.Collections;
using UnityEngine;

public abstract class Ability : MonoBehaviour 
{
    public string AbilityId { get; set; }
    public float AbilitySpeed { get; set; }

    public abstract void Activate();

    public abstract void Initialize();
}
