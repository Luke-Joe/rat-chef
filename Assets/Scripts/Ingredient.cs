using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum status
{
    dirty,
    raw,
    cooked,
    burnt
}

[CreateAssetMenu(fileName = "New Ingredient")]
public class Ingredient : ScriptableObject
{

    public string ingredientName;
    public bool isCore;
    public int quantity;
    public status state;
    public int value;
}
