using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private float horizontal;
    private float vertical;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //Vector2 position = transform.position;
        Vector2 position = rb.position;
        position.x = position.x+velocidad*horizontal*Time.deltaTime;
        position.y = position.y+velocidad*vertical*Time.deltaTime;
        //transform.position = position;
        rb.MovePosition(position);

    }
}
