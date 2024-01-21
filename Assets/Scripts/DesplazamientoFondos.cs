using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesplazamientoFondos : MonoBehaviour
{
    public Transform fondo1;
    public Transform fondo2;
    public float distanciaEntreFondos = 1.0f;
    public float velocidad = 5f;
    public float limiteDeCambio = 0f; // Ajusta este valor según la posición de cambio
    private bool intercambiarFondos = false;

    void Update()
    {
        MoverFondos();
    }

    void MoverFondos()
    {
        fondo1.Translate(Vector3.left * velocidad * Time.deltaTime);
        fondo2.Translate(Vector3.left * velocidad * Time.deltaTime);

        if (fondo1.position.x < limiteDeCambio && !intercambiarFondos)
        {
            intercambiarFondos = true;
            CambiarFondos();
        }
    }

    void CambiarFondos()
    {
        // Intercambia los fondos y reinicia la posición del fondo1
        Transform temp = fondo1;
        fondo1 = fondo2;
        fondo2 = temp;

        fondo1.position = new Vector3(fondo2.position.x + distanciaEntreFondos, fondo1.position.y, fondo1.position.z);

        intercambiarFondos = false;
    }
}
