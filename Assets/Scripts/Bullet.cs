using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;

    public GameObject GameObject => gameObject;
    public event Action<IPoolable> OnDestroyed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Reset();
    }

    public void FlyInDirection(Vector2 direction)
    {
        _rb.velocity = direction * _speed;
    }

    public void Reset()
    {
        OnDestroyed?.Invoke(this);
    }
}
