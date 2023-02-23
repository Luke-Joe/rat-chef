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
    public int quantity;
    public status state;
    public int value;
    public float cookTime;
    public float burnTime;
}
