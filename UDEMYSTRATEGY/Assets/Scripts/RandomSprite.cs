using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite[] sprites;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        int rand = Random.Range(0, sprites.Length);
        rend.sprite = sprites[rand];
    }
}
