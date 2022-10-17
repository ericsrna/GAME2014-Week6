using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    [Header("Player Bullets")]
    [Range(10, 200)]
    public int playerBulletNumber = 50;
    public int playerBulletCount;
    public int activePlayerBullets = 0;
    
    [Header("Enemy Bullets")]
    [Range(10, 200)]
    public int enemyBulletNumber = 50;
    public int enemyBulletCount;
    public int activeEnemyBullets = 0;

    private Queue<GameObject> PlayerBulletPool;
    private Queue<GameObject> EnemyBulletPool;
    private BulletFactory bulletFactory;

    void Start()
    {
        PlayerBulletPool = new Queue<GameObject>(); // creates an empty Queue
        EnemyBulletPool = new Queue<GameObject>(); // creates an empty Queue
        bulletFactory = GameObject.FindObjectOfType<BulletFactory>();
        BuildBulletPools();
    }

    void BuildBulletPools()
    {
        for (int i = 0; i < playerBulletNumber; i++)
        {
            PlayerBulletPool.Enqueue(bulletFactory.createBullet(BulletType.PALYER));
        }
        for (int i = 0; i < enemyBulletNumber; i++)
        {
            EnemyBulletPool.Enqueue(bulletFactory.createBullet(BulletType.ENEMY));
        }
    }

    public GameObject GetBullet(Vector2 position, BulletType type)
    {
        GameObject bullet = null;

        switch (type)
        {
            case BulletType.PALYER:
                {
                    if (PlayerBulletPool.Count < 1)
                    {
                        PlayerBulletPool.Enqueue(bulletFactory.createBullet(BulletType.PALYER));
                    }
                    bullet = PlayerBulletPool.Dequeue();
                    activePlayerBullets++;
                    playerBulletCount = PlayerBulletPool.Count;
                    break;
                }

            case BulletType.ENEMY:
                {
                    if (EnemyBulletPool.Count < 1)
                    {
                        EnemyBulletPool.Enqueue(bulletFactory.createBullet(BulletType.ENEMY));
                    }
                    bullet = EnemyBulletPool.Dequeue();
                    activeEnemyBullets++;
                    enemyBulletCount = EnemyBulletPool.Count;
                    break;
                }
        }

        bullet.SetActive(true);
        bullet.transform.position = position;

        return bullet;
    }

    public void ReturnBullet(GameObject bullet, BulletType type)
    {
        bullet.SetActive(false);

        switch (type)
        {
            case BulletType.PALYER:
                PlayerBulletPool.Enqueue(bullet);

                activePlayerBullets--;
                playerBulletCount = PlayerBulletPool.Count;
                break;

            case BulletType.ENEMY:
                EnemyBulletPool.Enqueue(bullet);

                activeEnemyBullets--;
                enemyBulletCount = EnemyBulletPool.Count;
                break;
        }
    }
}
