using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient")]
public class Ingredient : ScriptableObject
{
    public string ingredientName;
    public bool isCore;
    public int quantity;
    public int status;
    public int value;
}
