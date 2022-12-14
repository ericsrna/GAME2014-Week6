using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    // Bullet Prefab
    private GameObject bulletPrefab;

    // Sprite textures
    private Sprite playerBulletSprite;
    private Sprite enemyBulletSprite;

    // Bullet parent
    private Transform bulletParent;

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        playerBulletSprite = Resources.Load<Sprite>("Sprites/Bullet");
        enemyBulletSprite = Resources.Load<Sprite>("Sprites/EnemySmallBullet");
        bulletPrefab = Resources.Load<GameObject>("Prefabs/PlayerBullet");
        bulletParent = GameObject.Find("Bullets").transform;
    }

    public GameObject createBullet(BulletType bulletType)
    {
        GameObject bullet = null;

        bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity, bulletParent);
        bullet.SetActive(false);

        switch (bulletType)
        {
            case BulletType.PALYER:
                bullet.GetComponent<SpriteRenderer>().sprite = playerBulletSprite;
                bullet.GetComponent<BulletBehaviour>().bulletType = BulletType.PALYER;
                bullet.GetComponent<BulletBehaviour>().SetDirection(BulletDirection.UP);
                break;
            case BulletType.ENEMY:
                bullet.GetComponent<SpriteRenderer>().sprite = enemyBulletSprite;
                bullet.GetComponent<BulletBehaviour>().bulletType = BulletType.ENEMY;
                bullet.GetComponent<BulletBehaviour>().SetDirection(BulletDirection.DOWN);
                break;
        }    

        return bullet;
    }
}
