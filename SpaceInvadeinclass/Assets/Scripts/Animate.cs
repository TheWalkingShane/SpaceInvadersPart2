using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animatioTime = 1.0f;
    private SpriteRenderer _spriteRenderer;
    private int _AnimationFrame;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), animatioTime, animatioTime);
    }

    private void AnimateSprite()
    {
        _AnimationFrame++;
        if (_AnimationFrame >= animationSprites.Length)
        {
            _AnimationFrame = 0;
        }

        _spriteRenderer.sprite = animationSprites[_AnimationFrame];
    }
}
