using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> bulletPool;
    public GameObject bulletPrefab;
    [Range(10, 200)]
    public int bulletNumber = 50;
    public Transform bulletParent;
    public int bulletCount;
    public int activeBullets = 0;

    void Start()
    {
        bulletPool = new Queue<GameObject>(); // creates an empty Queue
        BuildBulletPool();
    }

    void BuildBulletPool()
    {
        for (int i = 0; i < bulletNumber; i++)
        {
            CreateBullet();
        }
    }

    private void CreateBullet()
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false);
        bullet.transform.SetParent(bulletParent);
        bulletPool.Enqueue(bullet);
    }

    public GameObject GetBullet(Vector2 position, BulletDirection direction)
    {
        if (bulletPool.Count < 1)
        {
            CreateBullet();
        }

        var bullet = bulletPool.Dequeue();
        bullet.SetActive(true);
        bullet.transform.position = position;
        bullet.GetComponent<BulletBehaviour>().SetDirection(direction);

        activeBullets++;
        bulletCount = bulletPool.Count;
        
        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);

        activeBullets--;
        bulletCount = bulletPool.Count;
    }
}
