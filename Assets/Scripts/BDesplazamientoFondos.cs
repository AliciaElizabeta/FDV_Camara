using UnityEngine;

public class BDesplazamientoFondos : MonoBehaviour
{
    public Transform fondoActual;
    public Transform fondoReserva;
    public Transform fondoAdicional; // Asegura que haya un fondo adicional para la transición
    public float velocidad = 5f;
    private float limiteDeCambio;

    void Start()
    {
        limiteDeCambio = fondoActual.position.x - fondoActual.GetComponent<SpriteRenderer>().bounds.size.x;
        Debug.Log(limiteDeCambio);
    }

    void Update()
    {
        MoverFondos();
    }

    void MoverFondos()
    {
        fondoActual.Translate(Vector3.right * velocidad * Time.deltaTime);
        fondoReserva.Translate(Vector3.right * velocidad * Time.deltaTime);
        fondoAdicional.Translate(Vector3.right * velocidad * Time.deltaTime);

        // Verifica si el fondoActual ha cruzado el límite de cambio
        if (fondoActual.position.x > limiteDeCambio)
        {
            Debug.Log("Cambiar");
            CambiarFondos();
        }
    }

    void CambiarFondos()
    {
        
        // Reposiciona el fondoReserva después del fondoAdicional
        fondoReserva.position = new Vector3(fondoAdicional.position.x + fondoAdicional.GetComponent<SpriteRenderer>().bounds.size.x, fondoReserva.position.y, fondoReserva.position.z);

        // Intercambia las referencias
        Transform temp = fondoActual;
        fondoActual = fondoReserva;
        fondoReserva = temp;
    }
}