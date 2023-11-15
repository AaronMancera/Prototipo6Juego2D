using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad;
    private float horizontal;
    private float vertical;
    private Rigidbody2D rb;
    private Vector2 position;
    [Header("Vida")]
    [SerializeField] private int maximaVida;
    [SerializeField] private int vidaActual;
    [SerializeField] private float tiempoDeRecuperacionDeDaņo;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vidaActual = maximaVida;
        tiempoDeRecuperacionDeDaņo = 1.5f;

    }

    // Update is called once per frame
    void Update()
    {
        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");
        ////Vector2 position = transform.position;
        //Vector2 position = rb.position;
        //position.x = position.x+velocidad*horizontal*Time.deltaTime;
        //position.y = position.y+velocidad*vertical*Time.deltaTime;
        ////transform.position = position;
        //rb.MovePosition(position);
        CogerInput();
        DecrementacionDelTemporizador();
    }
    private void FixedUpdate()
    {

        MoverJugador();
    }
    private void CogerInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    private void MoverJugador()
    {
        position = rb.position;
        position.x = position.x + velocidad * horizontal;
        position.y = position.y + velocidad * vertical;
        //transform.position = position;
        rb.MovePosition(position);
    }
    private void DecrementacionDelTemporizador()
    {
        tiempoDeRecuperacionDeDaņo -= Time.deltaTime;
    }
    public float getTiempoDeRecuperacionDeDaņo()
    {
        return tiempoDeRecuperacionDeDaņo;
    }
    public void DaņarJugador()
    {
            vidaActual--;
            tiempoDeRecuperacionDeDaņo = 1.5f;
        
    }

    public void CurarJugador(GameObject objetoCurativo)
    {
        if (vidaActual < maximaVida)
        {
            vidaActual++;
            Destroy(objetoCurativo);
        }
    }
}
