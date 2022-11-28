using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rating : MonoBehaviour
{
    [SerializeField]
    private Recipe recipe;

    public Ingredient[] prepared;

    // Initialize an area that counts the ingredients prepared by the player
    // For every ingredient in this area, give it a score base on ingredient quality, status, and value

}
