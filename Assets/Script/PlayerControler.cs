using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{


    private Rigidbody2D rb;
    private Vector2 direccion;

    [Header("Estadisticas")]
    public float velocidadDeMovimiento = 10;
    public float fuerzaDeSalto = 5;

    [Header("Booleanos")]
    public bool puedeMover = true;
    public bool enSuelo = true;

    [Header("Colisiones")]
    public Vector2 abajo;
    public float radioColision;
    public LayerMask layerPiso;

    private void Agarres() {
        enSuelo = Physics2D.OverlapCircle((Vector2)transform.position + abajo, radioColision, layerPiso);
    }





    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void MoviMiento() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        direccion = new Vector2 (x, y);
        caminar(direccion);
        
        //detectamos si camina 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enSuelo)
            {
                Saltar();
            }   
        }
    }
    private void caminar(Vector2 direccion) {
        if (puedeMover) {
            rb.velocity = new Vector2(direccion.x * velocidadDeMovimiento, rb.velocity.y);

            //verificamos la direccion para poder voltear al personaje.
            if (direccion != Vector2.zero) {
                if (direccion.x < 0 && transform.localScale.x > 0) {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                } else if (direccion.x > 0  && transform.localScale.x < 0) {

                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
            }
        }
    }
    
    private void mejorarSalto() {
        if (rb.velocity.y < 0)
        {

            rb.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.deltaTime;
        }
        else  if(rb.velocity.y > 0  && !Input.GetKeyDown(KeyCode.Space)){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (2.0f - 1) * Time.deltaTime;
        }
    }
    private void Saltar()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * fuerzaDeSalto;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoviMiento();
        Agarres();
    }
}
