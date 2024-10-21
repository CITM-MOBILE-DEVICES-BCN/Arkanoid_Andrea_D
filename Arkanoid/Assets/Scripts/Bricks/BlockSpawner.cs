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

    // Resistencias posibles para los bloques
    public int[] blockResistances = { 1, 2, 3 };  // Array con las resistencias posibles
    void Start()
    {
        SpawnBlocks();
    }

    void SpawnBlocks()
    {
        float screenHeight = Camera.main.orthographicSize * 2;
        // Obtener el tamaño del bloque desde el prefab
        float blockWidth = blockPrefab.transform.localScale.x * xOffset;  // Calculamos el ancho real del bloque considerando el offset
        float blockHeight = blockPrefab.transform.localScale.y * yOffset; // Calculamos el alto real del bloque considerando el offset

        // Calcular el ancho total de los bloques (incluyendo el espacio entre ellos)
        float totalWidth = (columns * blockWidth) + (columns - 1) * blockSpacing;

        // Calcular la posición inicial en X para centrar los bloques
        float startX = -(totalWidth / 2) + (blockWidth / 2);

        // Posicionar los bloques centrados
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Calcular la posición X e Y del bloque basándonos en su fila y columna
                float blockX = startX + col * (blockWidth + blockSpacing);
                float blockY = row * (blockHeight + blockSpacing) + screenHeight/4;

                // Crear el bloque en la posición calculada
                Vector2 blockPosition = new Vector2(blockX, blockY);
                GameObject newBlock = Instantiate(blockPrefab, blockPosition, Quaternion.identity);

                // Asignar una resistencia aleatoria al bloque
                Brick blockScript = newBlock.GetComponent<Brick>();
                if (blockScript != null)
                {
                    blockScript.resistance = GetRandomResistance();  // Asignar resistencia
                }
            }
        }
    }

    // Método para obtener una resistencia aleatoria
    int GetRandomResistance()
    {
        int randomIndex = Random.Range(0, blockResistances.Length);
        return blockResistances[randomIndex];  // Devuelve una resistencia aleatoria del array
    }

}
