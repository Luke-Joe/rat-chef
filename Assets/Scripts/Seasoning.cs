using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient")]
public class Seasoning : ScriptableObject
{
    public string seasoningName;
    public int quantity;
}
