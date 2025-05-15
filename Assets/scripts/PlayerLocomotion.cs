using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidadMovimiento = 5f;
    public float fuerzaSalto = 10f;

    [Header("Configuración del suelo")]
     public Transform chequeoSuelo;
   // public GameObject chequeoSuelo2;
    public LayerMask capaSuelo;
    public float radioChequeo = 0.2f;
    public bool enSuelo;

    public Rigidbody2D rb;
    private float movimientoX;

    public GameObject PersonajePrincipal;

    void Start()
    {
        //  rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento lateral
        movimientoX = Input.GetAxisRaw("Horizontal"); // -1 (izq), 1 (der), 0 (sin mover)
       // Debug.Log(movimientoX);

        // Comprobamos si está tocando el suelo
        enSuelo = Physics2D.OverlapCircle(chequeoSuelo.position, radioChequeo, capaSuelo);


        // Salto (solo si está en el suelo)
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            Saltar();
        }
  
    }

    void FixedUpdate()
    {
        // Aplicar movimiento en X manteniendo la velocidad Y
        rb.linearVelocity = new Vector2(movimientoX * velocidadMovimiento, rb.linearVelocity.y);
    }

    void Saltar()
    {
        // Dirección del salto (vertical o diagonal si se mueve a los lados)
        Vector2 direccionSalto = new Vector2(movimientoX, 1).normalized;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Resetea velocidad Y para un salto m�s consistente
        rb.AddForce(direccionSalto * fuerzaSalto, ForceMode2D.Impulse);
    }

    public void AlertaDaño() //Vacio
    {
       // PersonajePrincipal.GetComponent<Rigidbody2D>().gravityScale = 2;
       PersonajePrincipal.GetComponent<SpriteRenderer>().color = Color.yellow;
    }
    public float valorSalto()
    {
        Debug.Log("El valor de movimiento X es igual a:" + movimientoX);
        return movimientoX;
    }
    public void valorSalto2()
    {
        valorSalto();
    }


}
