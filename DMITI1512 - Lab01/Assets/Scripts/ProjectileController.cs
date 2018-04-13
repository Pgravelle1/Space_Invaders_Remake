using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;
    int particleTimer = 0;
    public Vector2 direction;
    public float damageAmount = 5f;
    GameObject background;
    GameObject leftBoundsObject;
    GameObject forceFieldObject;
    ForceFieldScript forceFieldScript;
    ParticleSystem forceFieldHit;


    public Transform explosionPrefab;
    AudioSource explosionAudioSource;
    AudioSource forceFieldAudioSource;
    AudioSource forceFieldExplosionAudioSource;

    public ParticleSystem forceFieldHitParticles;

    private void Start()
    {
        background = GameObject.Find("Background");
        leftBoundsObject = GameObject.Find("LeftBounds");
        explosionAudioSource = background.GetComponent<AudioSource>();
        forceFieldExplosionAudioSource = leftBoundsObject.GetComponent<AudioSource>();
    }

    void Update ()
    {
        transform.Translate(Time.deltaTime * speed * direction, Space.Self);

        if (Object.Equals(forceFieldHit, null))
        {
            // Do nothing (there isn't a NotEquals method)
        }
        else
        {
            particleTimer++;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "AlienProjectile")
        {
            if (collision.tag == "Alien")
            {
                // ignore it
            }
            else if (collision.tag == "Bounds" || collision.tag == "AlienBounds")
            {
                // ignore it
            }
            else if (collision.tag == "ForceField")
            {

                forceFieldObject = collision.gameObject;
                forceFieldScript = forceFieldObject.GetComponent<ForceFieldScript>();
                forceFieldAudioSource = forceFieldObject.GetComponent<AudioSource>();

                Destroy(gameObject);
                forceFieldHit = Instantiate(forceFieldHitParticles);
                forceFieldHit.transform.position = transform.position;
                forceFieldHit.Emit(1);
                forceFieldAudioSource.Play();
                float currentDamage = forceFieldScript.ReceiveDamage(damageAmount / 100, gameObject);

                if (currentDamage >= 1f)
                {
                    forceFieldExplosionAudioSource.Play();
                }
                Destroy(forceFieldHit, 1);
            }
            else
            {
                Transform explosion = Instantiate(explosionPrefab);

                //move the explosion to where the projectile is
                explosion.transform.position = transform.position;
                explosion.GetComponent<Detonator>().Explode();
                explosionAudioSource.Play();

                Destroy(collision.gameObject);
                Destroy(gameObject);
            }

        }
        if (gameObject.tag == "TankProjectile")
        {
            if (collision.tag == "Tank")
            {
                // ignore it
            }
            else if (collision.tag == "Bounds" || collision.tag == "AlienBounds")
            {
                // ignore it
            }
            else if (collision.tag == "ForceField")
            {

                forceFieldObject = collision.gameObject;
                forceFieldScript = forceFieldObject.GetComponent<ForceFieldScript>();
                forceFieldAudioSource = forceFieldObject.GetComponent<AudioSource>();

                Destroy(gameObject);
                forceFieldHit = Instantiate(forceFieldHitParticles);
                forceFieldHit.transform.position = transform.position;
                forceFieldHit.Emit(1);
                forceFieldAudioSource.Play();     
                float currentDamage = forceFieldScript.ReceiveDamage(damageAmount / 100, gameObject);

                if (currentDamage >= 1f)
                {
                    forceFieldExplosionAudioSource.Play();
                }
                Destroy(forceFieldHit, 1);
            }
            else
            {
                Transform explosion = Instantiate(explosionPrefab);

                //move the explosion to where the projectile is
                explosion.transform.position = transform.position;
                
                explosion.GetComponent<Detonator>().Explode();
                explosionAudioSource.Play();

                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }


    }
}
