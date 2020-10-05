using Interaction;
using UnityEngine;

public class DoorPlayerDetector : PlayerDetector
{
    protected override void AlphaToggle(GameObject other)
    {
        _spriteRenderer.color = other.GetComponent<SpriteRenderer>().sortingOrder == 2 ? new Color(1f, 1f, 1f, 0f) : new Color(1f, 1f, 1f, 1f);
    }
}
