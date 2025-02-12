using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPrefab : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float fadeDuration = 0.5f;
    private float timer;
    
    void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = fadeDuration;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        Color color = spriteRenderer.color;
        color.a = Mathf.Lerp(0, 1, timer / fadeDuration);
        spriteRenderer.color = color;

        if (timer <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
