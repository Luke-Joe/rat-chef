using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage background;
    [SerializeField] private float _x, _y;

    void Update()
    {
        background.uvRect = new Rect(background.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, background.uvRect.size);
    }
}
