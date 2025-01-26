using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceGradient : MonoBehaviour
{
    [SerializeField] GameObject bg;

    private SpriteRenderer[] _spriteRenderers;

    private void Start()
    {
        _spriteRenderers = bg.GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float _distance = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CalculateDistance>().GetDistance();

        if (_distance != -1)
        {
            for (int i = 0; i < _spriteRenderers.Length; i++)
            {
                float r = _spriteRenderers[i].color.r;
                float g = _spriteRenderers[i].color.g;
                float b = _spriteRenderers[i].color.b;

                _spriteRenderers[i].color = new Color(r, g, b, (1 - 1f * _distance));
            }
        }
    }
}
