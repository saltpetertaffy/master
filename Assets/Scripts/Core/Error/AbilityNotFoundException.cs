using System;
using System.Runtime.CompilerServices;

public class AbilityNotFoundException : Exception
{
    public string abilityKey { get; }

    public AbilityNotFoundException() { }

    public AbilityNotFoundException(string message)
        : base(message) { }

    public AbilityNotFoundException(string message, Exception inner) 
        : base(message, inner) { }

    public AbilityNotFoundException(string message, string abilityKey) 
        : this(message) {
        this.abilityKey = abilityKey;
    }
}
