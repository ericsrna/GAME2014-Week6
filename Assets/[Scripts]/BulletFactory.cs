using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    // Bullet Prefab
    public GameObject bulletPrefab;

    // Sprite textures
    public Sprite playerBulletSprite;
    public Sprite enemyBulletSprite;

    // Bullet parent
    public Transform bulletParent;

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

    public GameObject createBullet(BulletType bulletType = BulletType.PALYER)
    {
        GameObject bullet = null;

        bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity, bulletParent);
        bullet.SetActive(false);

        switch (bulletType)
        {
            case BulletType.PALYER:
                bullet.GetComponent<SpriteRenderer>().sprite = playerBulletSprite;
                bullet.GetComponent<BulletBehaviour>().bulletDirection = BulletDirection.UP;
                break;
            case BulletType.ENEMY:
                bullet.GetComponent<SpriteRenderer>().sprite = enemyBulletSprite;
                bullet.GetComponent<BulletBehaviour>().bulletDirection = BulletDirection.DOWN;
                break;
        }    

        return bullet;
    }
}
