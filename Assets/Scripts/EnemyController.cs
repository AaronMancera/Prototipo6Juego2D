using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad;
    private Rigidbody2D rb2d;
    private Vector2 nuevaPosicion;
    [SerializeField] private float tiempoDeCambioDireccion;
    [SerializeField] private float temporizador;
    private float direccion;
    private int giros;
    private bool horizontal;
    [Header("Vida y reaparacion")]
    [SerializeField] private bool vivo;
    [SerializeField] private float tiempoReparacion;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        temporizador = tiempoDeCambioDireccion;
        direccion = 1;
        horizontal = true;
        vivo = true;
        tiempoReparacion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (vivo)
        {
            if (temporizador > 0)
            {
                temporizador -= Time.deltaTime;

            }
            else
            {
                horizontal = !horizontal;
                temporizador = tiempoDeCambioDireccion;
                giros++;
            }
            if (giros == 2)
            {
                direccion = -(direccion);
                giros = 0;
            }
        }
        else
        {
            tiempoReparacion += Time.deltaTime;
            if (tiempoReparacion > 5)
            {
                Reparar();
            }
        }
    }
    private void FixedUpdate()
    {
        if (vivo)
            Caminar();
    }
    private void Caminar()
    {

        Debug.Log("hola");
        nuevaPosicion = rb2d.position;

        //nuevaPosicion.x = nuevaPosicion.x + velocidad;
        if (horizontal)
        {
            nuevaPosicion.x = nuevaPosicion.x + velocidad * direccion;
        }
        else
        {
            nuevaPosicion.y = nuevaPosicion.y + velocidad * direccion;
        }
        rb2d.MovePosition(nuevaPosicion);
    }
    public void Muerto()
    {
        vivo = false;
        rb2d.simulated = false;

    }

    private void Reparar()
    {
        vivo = true;
        rb2d.simulated = true;
        tiempoReparacion = 0;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.DañarJugador();
        }
    }
}
