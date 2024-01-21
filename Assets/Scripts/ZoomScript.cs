using UnityEngine;
using Cinemachine;

public class ZoomScript : MonoBehaviour
{
    public CinemachineVirtualCamera freeLookCamera;

    private void Update()
    {
        // Capturar la entrada del teclado para hacer zoom
        if (Input.GetKey("u"))
        {
            ZoomIn();
        }
        else if (Input.GetKey("j"))
        {
            ZoomOut();
        }
    }

    void ZoomIn()
    {
        // Ajustar el campo de visión para hacer zoom in
        freeLookCamera.m_Lens.OrthographicSize += 1;
        Debug.Log("u");
    }

    void ZoomOut()
    {
        // Ajustar el campo de visión para hacer zoom out
        freeLookCamera.m_Lens.OrthographicSize += -1;
    }
}
