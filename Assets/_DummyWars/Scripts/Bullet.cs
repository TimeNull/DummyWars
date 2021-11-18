using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Vector3 shootDir;
    private float speed, damage;
    private Rigidbody bulletRB;
    private float lifetime;

    public void Setup(Vector3 shootDir, float speed, float damage, float lifetime, int layer)
    {
        this.shootDir = shootDir.normalized;
        this.speed = speed;
        this.damage = damage;
        this.lifetime = lifetime;
        gameObject.layer = layer;
        transform.LookAt(transform.position + shootDir);
        bulletRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        giveBulletForce();
    }
    
    private void giveBulletForce()
    {
        
        transform.Translate(shootDir * speed * Time.deltaTime, Space.World); // EUREKA! (a want to kill ma self wigga)
    }

    private void OnTriggerEnter(Collider collision)
    {
        //to avoid self harm, I disabled collision of layer Enemy with Enemy, and Player with Player
        //remember to change that if enemies are going to kill themselves in the future

        //if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Ally"))
        //{
        //    collision.gameObject.GetComponent<Life>().ReceiveDamage(damage);
        //}

    }

    private void Start()
    {
        StartCoroutine(LifeTime());
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

}
