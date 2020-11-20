using System;
using System.Runtime.CompilerServices;

public class EffectNotFoundException : Exception
{
    public string abilityKey { get; }

    public EffectNotFoundException() { }

    public EffectNotFoundException(string message)
        : base(message) { }

    public EffectNotFoundException(string message, Exception inner) 
        : base(message, inner) { }

    public EffectNotFoundException(string message, string abilityKey) 
        : this(message) {
        this.abilityKey = abilityKey;
    }
}
