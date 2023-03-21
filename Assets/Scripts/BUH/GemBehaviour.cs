using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour, ICollectable
{
    // (CNTRL + .   will give a bunch of freebies)

    public int Value => 10;
    public CollectableType type => CollectableType.Gem;
    private SpriteRenderer sprite;
    private Collider2D boundingBox;

    void Start()
    {
        boundingBox = GetComponent<Collider2D>();
    }
    public int Collect()
    {
        boundingBox.enabled = false;
        sprite.color = new Color(1, 1, 1, 0.2f); //slightly transparent
        return Value;
    }
}