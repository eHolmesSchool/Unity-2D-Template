using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour, ICollectable
{
    // (CNTRL + .   will give a bunch of freebies)

    public int Value { get => 22; set => Value = value; }
    public CollectableType type => CollectableType.Gem;
    private SpriteRenderer ourSprite;
    private Collider2D boundingBox;

    void Start()
    {
        ourSprite = GetComponent<SpriteRenderer>();
        boundingBox = GetComponent<Collider2D>();
    }
    public int Collect()
    {
        boundingBox.enabled = false;
        ourSprite.color = new Color(1, 1, 1, 0.2f); //slightly transparent
        return Value;
    }
}