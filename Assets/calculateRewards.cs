using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calculateRewards : MonoBehaviour
{

    public static Text winText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static List<List<Vector2Int>> lines = new List<List<Vector2Int>>()
    {
        // 1 FIRST ROW FROM BOTTOM
        new List<Vector2Int>()
        {
            new Vector2Int(0, 0),
            new Vector2Int(1, 0),
            new Vector2Int(2, 0),
            new Vector2Int(3, 0),
            new Vector2Int(4, 0),
            new Vector2Int(5, 0)
        },

        // 2 SECOND ROW FROM BOTTOM
        new List<Vector2Int>()
        {
            new Vector2Int(0, 1),
            new Vector2Int(1, 1),
            new Vector2Int(2, 1),
            new Vector2Int(3, 1),
            new Vector2Int(4, 1),
            new Vector2Int(5, 1)
        },

        // 3 THIRD ROW FROM BOTTOM
        new List<Vector2Int>()
        {
            new Vector2Int(0, 2),
            new Vector2Int(1, 2),
            new Vector2Int(2, 2),
            new Vector2Int(3, 2),
            new Vector2Int(4, 2),
            new Vector2Int(5, 2)
        },

        // 4 FOUTH ROW FROM BOTTOM
        new List<Vector2Int>()
        {
            new Vector2Int(0, 3),
            new Vector2Int(1, 3),
            new Vector2Int(2, 3),
            new Vector2Int(3, 3),
            new Vector2Int(4, 3),
            new Vector2Int(5, 3)
        },
    };
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static void WinningLine(int line, int id)
    {

        List<Vector2Int> l1 = lines[line];
        int[,] symbolIDs = logicScript.symbolIDs;

        foreach (Vector2Int c in l1)
        {
            symbolIDs[c.x, c.y] = id;
        }
    }
}
