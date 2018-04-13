using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldScript : MonoBehaviour {

    SpriteRenderer forceFieldSpriteRenderer;
    float colorIntensity= 0.01f;

    // Use this for initialization
    void Start () {
        forceFieldSpriteRenderer = GetComponent<SpriteRenderer>();
        forceFieldSpriteRenderer.color = Color.green;
    }
	
	// Update is called once per frame
	void Update () {
        Color c = Color.Lerp(Color.green, Color.red, colorIntensity);
        forceFieldSpriteRenderer.color = c;
    }

    public float ReceiveDamage(float damageReceived, GameObject Projectile)
    {
        GameObject projectile = Projectile;
        colorIntensity += damageReceived;
        if (colorIntensity >=1)
        {
            Destroy(gameObject);
        }
        return colorIntensity;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
