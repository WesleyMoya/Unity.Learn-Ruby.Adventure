using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public string Name = "Ruby";
    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    int currentHealth;
    public float maxSpeed = 0.3f;
    float currentSpeed;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public float timeInvencible = 2.0f;
    bool isInvencible;
    float invencibleTimer;
    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        //Define o Contador vSync
        //QualitySettings.vSyncCount = 0;
        //FrameRate do jogo. Como meu personagem se move a cada 0.1 segundos e o framerate está 10. 0.1*10 = 1. 1 unidade por segundo
        //Application.targetFrameRate = 30;

        currentHealth = maxHealth;
        currentSpeed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);


        if(isInvencible)
        {
            invencibleTimer -= Time.deltaTime;
            if(invencibleTimer < 0)
                isInvencible = false;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + currentSpeed * horizontal * Time.deltaTime;
        position.y = position.y + currentSpeed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
    public void ChangeHealth(int v)
    {
        if(v < 0)
        {
            if (isInvencible)
                return;

            isInvencible = true;
            invencibleTimer = timeInvencible;
        }
        currentHealth = Mathf.Clamp(currentHealth + v, 0, maxHealth);
    }
}
