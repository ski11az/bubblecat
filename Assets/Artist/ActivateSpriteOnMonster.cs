using System.Collections;
using UnityEngine;

public class ActivateSpriteOnMonster : MonoBehaviour
{
    public GameObject monster;  // Reference to the monster GameObject
    public GameObject sprite;   // Reference to the parent sprite object
    public float fadeDuration = 1.0f;  // Time it takes to fade in

    private SpriteRenderer[] spriteRenderers;

    void Start()
    {
        if (sprite != null)
        {
            spriteRenderers = sprite.GetComponentsInChildren<SpriteRenderer>();  // Get all SpriteRenderer components

            foreach (SpriteRenderer sr in spriteRenderers)
            {
                Color color = sr.color;
                color.a = 0f;  // Start fully transparent
                sr.color = color;
            }
        }
    }

    void Update()
    {
        if (monster != null && sprite != null)
        {
            // Check if the monster is active
            if (monster.activeInHierarchy && spriteRenderers.Length > 0)
            {
                sprite.SetActive(true);  // Enable the sprite object
                StartCoroutine(FadeSprites());
            }
            else
            {
                sprite.SetActive(false); // Disable the sprite object
            }
        }
    }

    public IEnumerator FadeSprites()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);

            foreach (SpriteRenderer sr in spriteRenderers)
            {
                Color color = sr.color;
                color.a = alpha;
                sr.color = color;
            }

            yield return null;
        }

        // Ensure all sprites are fully visible at the end
        foreach (SpriteRenderer sr in spriteRenderers)
        {
            Color color = sr.color;
            color.a = 1f;
            sr.color = color;
        }
    }
}
