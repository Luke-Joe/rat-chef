using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe")]
public class Recipe : ScriptableObject
{
    public string recipeName;
    public Dictionary<string, Ingredient> Ingredients;
    public float maxScore;
    public float time;
}
