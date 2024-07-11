using System;
public class Move  {
    private string _name;
    public string GetName() { return _name;}
    private string _verbDescript;
    public string GetVerbDescript() { return _verbDescript;}
    private int _damage;
    public int GetDamage() { return _damage;}
    private int _accuracy;
    public int GetAccuracy() { return _accuracy;}
    private float _staminaCost;
    public float GetStaminaCost() { return _staminaCost;}

    public Move(string name, string verbDescript, int damage, int accuracy, float staminaCost) {
        _name = name;
        _verbDescript = verbDescript;
        _damage = damage;
        _accuracy = accuracy;
        _staminaCost = staminaCost;
    }

    public float staminaCost { get; internal set; }

    public void Execute() { // 
        // Move execution logic
        Console.WriteLine("execution logic.");
    }
}