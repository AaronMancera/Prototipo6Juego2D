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
    private Rigidbody2D rb2d;
    private Vector2 position;
    [Header("Vida")]
    [SerializeField] private int maximaVida;
    [SerializeField] private int vidaActual;
    [SerializeField] private float tiempoDeRecuperacionDeDaño;
    [Header("Animaciones")]
    [SerializeField] private Animator animator;
    [SerializeField] private float lookX;
    [SerializeField] private float lookY;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        vidaActual = maximaVida;
        tiempoDeRecuperacionDeDaño = 1.5f;
        animator = GetComponent<Animator>();

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
        if (horizontal != 0)
        {
            lookX = horizontal;
            lookY = 0;
            animator.SetFloat("Speed", horizontal);

        }
        if (horizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, transform.localScale.y);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, transform.localScale.y);
        }
        vertical = Input.GetAxis("Vertical");
        if (vertical != 0)
        {
            lookY = vertical;
            lookX = 0;
            animator.SetFloat("Speed", vertical);
        }
        //Animacion de movimiento
        animator.SetFloat("Look X", lookX);
        animator.SetFloat("Look Y", lookY);

    }
    private void MoverJugador()
    {
        position = rb2d.position;
        position.x = position.x + velocidad * horizontal;
        position.y = position.y + velocidad * vertical;
        //transform.position = position;
        rb2d.MovePosition(position);
    }
    private void DecrementacionDelTemporizador()
    {
        tiempoDeRecuperacionDeDaño -= Time.deltaTime;
    }
    public float getTiempoDeRecuperacionDeDaño()
    {
        return tiempoDeRecuperacionDeDaño;
    }
    public void DañarJugador()
    {
        vidaActual--;
        tiempoDeRecuperacionDeDaño = 1.5f;

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
