using System;

public class StatNotFoundException : Exception { 
    public string abilityKey { get; }

    public StatNotFoundException() { }

    public StatNotFoundException(string message)
        : base(message) { }

    public StatNotFoundException(string message, Exception inner)
        : base(message, inner) { }

    public StatNotFoundException(string message, string abilityKey)
        : this(message) {
        this.abilityKey = abilityKey;
    }
}
