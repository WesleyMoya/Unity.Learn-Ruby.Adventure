using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Define o Contador vSync
        //QualitySettings.vSyncCount = 0;
        //FrameRate do jogo. Como meu personagem se move a cada 0.1 segundos e o framerate está 10. 0.1*10 = 1. 1 unidade por segundo
        //Application.targetFrameRate = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //variavel horizontal pega os inputs pre definidos no parametro Horizontal/Vertical
        float horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        //variavel position, Vector2 significa uma atribuição automática a um vetor que armazena as posiçoes X e Y, essa posição vai ser a do gameobject com esse script.
        Vector2 position = transform.position;

        //pega a posição X dentro do vetor position e adiciona 0.1 pixeis ou para a esquerda ou para a direita, funciona assim:
        //quando está sendo pressionado a tecla para a esquerda, o valor da variavel horizontal vai ser -1, quando esta para a direita 1 e sem clicar 0.
        //acontece o mesmo para a posição Y, mas o 1 é para cima e o -1 para baixo.
        //deltaTime, contido em Time, é uma variável que o Unity preenche com o tempo que leva para um quadro ser renderizado.
        position.x = position.x + 0.1f * horizontal;
        position.y = position.y + 0.1f * Vertical;

        //atualiza a posição atual antes de dar update
        transform.position = position;
    }
}
