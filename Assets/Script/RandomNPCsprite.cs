using UnityEngine;

public class RandomNPCsprite : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();

        _sprite.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
