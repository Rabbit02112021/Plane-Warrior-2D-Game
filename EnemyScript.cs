using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform gunPoint1;
    public Transform gunPoint2;
    public GameObject enemyBullet;
    public GameObject enemyFlash;
    public GameObject enemyExplosionPrefab;
    public float speed = 1f;
    public float enemyBulletSpawnTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        enemyFlash.SetActive(false);
        StartCoroutine(EnemyShooting());
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    private void OnTrggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBullet")
        {
            Destroy(gameObject);
            GameObject enemyExplosion = Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(enemyExplosion, 0.4f);
        }
        
    }
    void EnemyFire()
    {
        Instantiate(enemyBullet, gunPoint1.position, Quaternion.identity);
        Instantiate(enemyBullet, gunPoint2.position, Quaternion.identity);

    }
    IEnumerator EnemyShooting()
    {
        while(true)
        {
            yield return new WaitForSeconds(enemyBulletSpawnTime);
            EnemyFire();
            enemyFlash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            enemyFlash.SetActive(false);
        }
        
    }
}
