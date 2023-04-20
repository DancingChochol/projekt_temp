using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuchGracza : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private Animator anim;

    [SerializeField] private LayerMask doSkakania;

    private float dirX = 0f;
    [SerializeField] private float predkoscRuchu = 7f;
    [SerializeField] private float silaSkoku = 15f;

    private enum StanRuchu
    {
        idle, bieganie, skakanie, spadanie
    }

    [SerializeField] private AudioSource dzwiekSkok;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * predkoscRuchu, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && CzyDotykaPodloza())
        {
            dzwiekSkok.Play();
            rb.velocity = new Vector2(rb.velocity.x,silaSkoku);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        StanRuchu stan;

        if (dirX > 0f)
        {
            stan = StanRuchu.bieganie;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            stan = StanRuchu.bieganie;
            sprite.flipX = true;
        }
        else
        {
            stan = StanRuchu.idle;
        }

        if (rb.velocity.y > .1f)
        {
            stan = StanRuchu.skakanie;
        }
        else if (rb.velocity.y < -.1f) 
        {
            stan = StanRuchu.spadanie;
        }

        anim.SetInteger("stan", (int)stan);
    }

    private bool CzyDotykaPodloza()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size, 0f, Vector2.down, .1f, doSkakania);
    }

}
