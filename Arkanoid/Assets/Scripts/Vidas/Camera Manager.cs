using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;

public class CameraManager : MonoBehaviour
{
    private Camera cam; // Referencia a la cámara

    private float screenHalfWidthInWorldUnits;
    private float screenHalfHeightInWorldUnits;

    void Start()
    {
        cam = Camera.main;
        CalculateCameraBounds();
    }

    void Update()
    {
        // Recalcular los límites si el tamaño de la pantalla cambia
        if (Screen.width != screenHalfWidthInWorldUnits || Screen.height != screenHalfHeightInWorldUnits)
        {
            CalculateCameraBounds();
        }
    }

    void CalculateCameraBounds()
    {
        // Obtener la mitad de la altura visible en unidades del mundo
        screenHalfHeightInWorldUnits = cam.orthographicSize;

        // Calcular la mitad del ancho visible en unidades del mundo, que depende de la relación de aspecto
        screenHalfWidthInWorldUnits = cam.aspect * screenHalfHeightInWorldUnits;
    }

    public Vector2 GetCameraBounds()
    {
        // Devuelve el ancho y alto de la cámara en unidades del mundo
        return new Vector2(screenHalfWidthInWorldUnits, screenHalfHeightInWorldUnits);
    }

}
