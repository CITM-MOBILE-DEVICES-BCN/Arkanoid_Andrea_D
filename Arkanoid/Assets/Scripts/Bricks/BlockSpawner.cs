using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;  // El prefab del bloque
    public int rows = 3;            // N�mero de filas de bloques
    public int columns = 5;         // N�mero de columnas de bloques
    public float xOffset = 1.1f;    // Separaci�n entre bloques en el eje X
    public float yOffset = 0.6f;    // Separaci�n entre bloques en el eje Y
    public float blockSpacing = 0.1f;  // Espaciado entre los bloques
    public int minColumns = 3;      // M�nimo n�mero de columnas
    public int minRows = 3;         // M�nimo n�mero de filas

    // Resistencias posibles para los bloques
    public int[] blockResistances = { 1, 2, 3 };  // Array con las resistencias posibles
    void Start()
    {
        GetRandomResistance();
    }

    // M�todo para obtener una resistencia aleatoria
    int GetRandomResistance()
    {
        int randomIndex = Random.Range(0, blockResistances.Length);
        return blockResistances[randomIndex];  // Devuelve una resistencia aleatoria del array
    }

}
