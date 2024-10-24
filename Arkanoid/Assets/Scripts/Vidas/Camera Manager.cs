using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;

public class CameraManager : MonoBehaviour
{
    private Camera cam; // Referencia a la c�mara

    private float screenHalfWidthInWorldUnits;
    private float screenHalfHeightInWorldUnits;

    void Start()
    {
        cam = Camera.main;
        CalculateCameraBounds();
    }

    void Update()
    {
        // Recalcular los l�mites si el tama�o de la pantalla cambia
        if (Screen.width != screenHalfWidthInWorldUnits || Screen.height != screenHalfHeightInWorldUnits)
        {
            CalculateCameraBounds();
        }
    }

    void CalculateCameraBounds()
    {
        // Obtener la mitad de la altura visible en unidades del mundo
        screenHalfHeightInWorldUnits = cam.orthographicSize;

        // Calcular la mitad del ancho visible en unidades del mundo, que depende de la relaci�n de aspecto
        screenHalfWidthInWorldUnits = cam.aspect * screenHalfHeightInWorldUnits;
    }

    public Vector2 GetCameraBounds()
    {
        // Devuelve el ancho y alto de la c�mara en unidades del mundo
        return new Vector2(screenHalfWidthInWorldUnits, screenHalfHeightInWorldUnits);
    }

}
