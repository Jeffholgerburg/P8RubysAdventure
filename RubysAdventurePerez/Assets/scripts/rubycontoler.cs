using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Searcher.SearcherWindow.Alignment;


public class rubycontoler : MonoBehaviour
{
    public int maxHealth = 5;

    public int currentHealth;
    public float timeInvincible = 2.0f;
    public GameObject projectilePrefab;
    public int health { get { return currentHealth; } }

    bool isInvincible;
    float invincibleTimer;


    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    Animator animator;
    Vector2 LookDirection = new Vector2(1, 0);
    public AudioClip throwsound;
    public AudioClip hitsound2;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        currentHealth = 1;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0f ))
        {
            LookDirection.Set(move.x, move.y);
            LookDirection.Normalize();
        }
        animator.SetFloat("Look X", LookDirection.x);
        animator.SetFloat("Look y", LookDirection.y);
        animator.SetFloat ("Speed" , move.magnitude);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
            if(Imput.GetKeyDown(KeyCode.C))
            {
                launch();
            }

            if(Imput.GetKeyDown(KeyCode.X))
            {
                RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, LookDirection, 1.5f, layerMask.GetMask("NPC"));
                if(hit.collider != null)
                {
                    NonPlayerCharcter charcter = hit.collider.GetComponent<NonPlayerCharcter>();
                    if(charcter != null)
                    {
                        charcter.DisplayDiaLog();
                    }

              
                        
                  
                    
                }
            }
        }


    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime; ;

        rigidbody2d.MovePosition(position);
    }
    public void ChangeHealth(int amount)
    {
        animator.SetTrigger("Hit");

        if (isInvincible)

            return;


        isInvincible = true;
        invincibleTimer = timeInvincible;
        PlaySound(hitsound);
        



        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance(currentHealth/(float)maxHealth);


    }
    void launch ()
    {
        GameObject ProjectTileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        projectilePrefab projectile = projectileObject.GetComponent<ProjectTile>();
        projectile.Launch(LookDirection, 300);

        animator.SetTrigger("Launch");
        PlaySound(throwsound);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}