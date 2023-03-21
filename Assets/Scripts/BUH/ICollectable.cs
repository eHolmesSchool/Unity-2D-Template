using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface ICollectable //what should All collectables do? (just in general)
{
    public int value { get; set; } //Increment some value
    public int Collect(); //Have a “Collect” method. Removes itself from the scene
    public CollectableType type { get; }
}

// using... i dunno what this does
[System.Flags]

public enum CollectableType
{
    None = 0,
    Money = 1,
    Key = 2,
    Gem = 4,
    Special = Money | Gem //Specials Int is 5
}                    