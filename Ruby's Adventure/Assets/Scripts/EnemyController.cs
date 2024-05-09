using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator animator;
    public float speed = 3.0f; // Velocidade de movimento do inimigo
    public float changeTime = 3.0f; // Tempo de mudança de direção do inimigo
    float timer; // Temporizador para controlar a mudança de direção
    int directionX = 1; // Direção do movimento horizontal do inimigo
    int directionY = 0; // Direção do movimento vertical do inimigo

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        timer = changeTime; // Inicializa o temporizador
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; // Decrementa o temporizador com base no tempo decorrido

        // Verifica se o temporizador chegou a zero
        if (timer < 0)
        {
            // Inverte a direção do movimento horizontal e vertical
            directionX *= -1;
            directionY *= -1;

            timer = changeTime; // Reinicia o temporizador
        }

        // Define os parâmetros de animação com base nas direções atualizadas
        animator.SetFloat("Move X", directionX);
        animator.SetFloat("Move Y", directionY);
    }

    // FixedUpdate is called at fixed intervals
    void FixedUpdate()
    {
        // Move o inimigo nas direções horizontal e vertical com base na velocidade
        Vector2 movement = new Vector2(speed * directionX * Time.deltaTime, speed * directionY * Time.deltaTime);
        transform.Translate(movement);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
