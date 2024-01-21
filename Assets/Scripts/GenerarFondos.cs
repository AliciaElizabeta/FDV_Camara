using UnityEngine;

public class GenerarFondos : MonoBehaviour
{
    public Camera camara;
    public Transform jugador;
    public Transform fondoPrefab; // Puedes tener un fondo o varios dependiendo de tu diseño
    public float distanciaGeneracion = 10f;
    private float puntoGeneracion = 0f;


    public float distanciaMaxima = 20f; // Distancia máxima antes de destruir el fondo antiguo
    private Transform ultimoFondoGenerado;

    void Update()
    {
        if (jugador.position.x > puntoGeneracion - distanciaGeneracion)
        {
            GenerarFondo();
            //DestruirFondosAntiguos();
        }
    }

    void GenerarFondo()
    {
        // Instancia un nuevo fondo
        Transform nuevoFondo = Instantiate(fondoPrefab, new Vector3(puntoGeneracion, 0, 0), Quaternion.identity);

        // Actualiza el punto de generación
        puntoGeneracion += nuevoFondo.GetComponent<SpriteRenderer>().bounds.size.x;

        // Actualiza la referencia al último fondo generado
        ultimoFondoGenerado = nuevoFondo;
    }

    void DestruirFondosAntiguos()
    {
        if (ultimoFondoGenerado != null && camara != null)
        {
            float distanciaDesdeCamara = puntoGeneracion - camara.transform.position.x;

            if (distanciaDesdeCamara > distanciaMaxima)
            {
                Destroy(ultimoFondoGenerado.gameObject);
            }
        }
    }
}
