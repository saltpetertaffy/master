using System;
using System.Runtime.CompilerServices;

public class CharacterNotFoundException : Exception {
    public string abilityKey { get; }

    public CharacterNotFoundException() { }

    public CharacterNotFoundException(string message)
        : base(message) { }

    public CharacterNotFoundException(string message, Exception inner)
        : base(message, inner) { }

    public CharacterNotFoundException(string message, string abilityKey)
        : this(message) {
        this.abilityKey = abilityKey;
    }
}