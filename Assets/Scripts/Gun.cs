using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    private ObjectPool<Bullet> _objectPool;

    private void Start()
    {
        _objectPool = new ObjectPool<Bullet>(_bulletPrefab);
    }

    public void Shoot()
    {
        Bullet bullet = CreateBullet();

        bullet.transform.position = new Vector3(gameObject.transform.position.x - 2.5f, gameObject.transform.position.y, gameObject.transform.position.z);
        bullet.FlyInDirection(transform.right * -1f);
    }

    private Bullet CreateBullet()
    {
        IPoolable poolable = _objectPool.GetFreeObject();
        return poolable as Bullet;
    }
}
