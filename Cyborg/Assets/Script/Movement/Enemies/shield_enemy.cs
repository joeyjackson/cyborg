﻿using UnityEngine;

public class shield_enemy : MonoBehaviour
{
    public Util.SpriteFlasher spriteFlasher;
    public GameObject healthDrop;
    public int deathCount;
    public SpriteRenderer shieldRenderer;

    private int hitCount;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (shieldRenderer.enabled)
        {
            return;
        }
        if (coll.gameObject.tag == "Bullet")
        {
            if (!this.spriteFlasher.IsInvicible())
            {
                this.hitCount++;
                if (this.deathCount == this.hitCount)
                {
                    Destroy(this.gameObject);
                    float randomNumber = Random.Range(0, 100);
                    if (randomNumber < 20)
                    {
                        Instantiate(this.healthDrop, this.transform.position, Quaternion.identity);
                    }
                }
                else
                    this.spriteFlasher.StartFlash();
            }
        }
    }
}
