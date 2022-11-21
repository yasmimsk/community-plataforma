using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPlataforma : MonoBehaviour
{
    public float velocidade = 3;
    public float altura = 1;
    public float largura = 1;

    private float contador = 0;
    private Vector2 posInicial;

    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        contador += velocidade * Time.deltaTime;

        float posX = Mathf.Cos(contador) * largura;
        float posY = Mathf.Sin(contador) * altura;
        Vector2 posAtual = new Vector2(posX, posY);
        transform.position = posInicial + posAtual;

        if (contador >= 2 * Mathf.PI)
            contador = contador - 2 * Mathf.PI;
    }
}
