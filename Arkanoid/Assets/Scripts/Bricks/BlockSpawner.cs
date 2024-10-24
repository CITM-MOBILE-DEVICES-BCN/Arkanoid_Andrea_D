using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;  // El prefab del bloque
    public int rows = 3;            // Número de filas de bloques
    public int columns = 5;         // Número de columnas de bloques
    public float xOffset = 1.1f;    // Separación entre bloques en el eje X
    public float yOffset = 0.6f;    // Separación entre bloques en el eje Y
    public float blockSpacing = 0.1f;  // Espaciado entre los bloques
    public int minColumns = 3;      // Mínimo número de columnas
    public int minRows = 3;         // Mínimo número de filas

    // Resistencias posibles para los bloques
    public int[] blockResistances = { 1, 2, 3 };  // Array con las resistencias posibles
    void Start()
    {
        GetRandomResistance();
    }

    // Método para obtener una resistencia aleatoria
    int GetRandomResistance()
    {
        int randomIndex = Random.Range(0, blockResistances.Length);
        return blockResistances[randomIndex];  // Devuelve una resistencia aleatoria del array
    }

}
