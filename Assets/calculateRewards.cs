using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calculateRewards : MonoBehaviour
{

    public static Text winText;


    // ALL LINES
    public static List<List<Vector2Int>> lines = new List<List<Vector2Int>>()
    {
        // 1 ( - 1)
        new List<Vector2Int>()
        {
            new Vector2Int(0, 3),
            new Vector2Int(1, 3),
            new Vector2Int(2, 3),
            new Vector2Int(3, 3),
            new Vector2Int(4, 3),
        },

        // 2 
        new List<Vector2Int>()
        {
            new Vector2Int(0, 2),
            new Vector2Int(1, 2),
            new Vector2Int(2, 2),
            new Vector2Int(3, 2),
            new Vector2Int(4, 2),
        },

        // 3
        new List<Vector2Int>()
        {
            new Vector2Int(0, 1),
            new Vector2Int(1, 1),
            new Vector2Int(2, 1),
            new Vector2Int(3, 1),
            new Vector2Int(4, 1),
        },

        // 4 
        new List<Vector2Int>()
        {
            new Vector2Int(0, 0),
            new Vector2Int(1, 0),
            new Vector2Int(2, 0),
            new Vector2Int(3, 0),
            new Vector2Int(4, 0),
        },

        // 5
        new List<Vector2Int>()
        {
            new Vector2Int(0, 3),
            new Vector2Int(1, 2),
            new Vector2Int(2, 3),
            new Vector2Int(3, 2),
            new Vector2Int(4, 3),
        },

        // 6
        new List<Vector2Int>()
        {
            new Vector2Int(0, 2),
            new Vector2Int(1, 1),
            new Vector2Int(2, 2),
            new Vector2Int(3, 1),
            new Vector2Int(4, 2),
        },

        // 7
        new List<Vector2Int>()
        {
            new Vector2Int(0, 1),
            new Vector2Int(1, 0),
            new Vector2Int(2, 1),
            new Vector2Int(3, 0),
            new Vector2Int(4, 1),
        },

        // 8
        new List<Vector2Int>()
        {
            new Vector2Int(0, 2),
            new Vector2Int(1, 3),
            new Vector2Int(2, 2),
            new Vector2Int(3, 3),
            new Vector2Int(4, 2),
        },

        // 9
        new List<Vector2Int>()
        {
            new Vector2Int(0, 1),
            new Vector2Int(1, 2),
            new Vector2Int(2, 1),
            new Vector2Int(3, 2),
            new Vector2Int(4, 1),
        },

        // 10
        new List<Vector2Int>()
        {
            new Vector2Int(0, 0),
            new Vector2Int(1, 1),
            new Vector2Int(2, 0),
            new Vector2Int(3, 1),
            new Vector2Int(4, 0),
        },

        // 11
        new List<Vector2Int>()
        {
            new Vector2Int(0, 3),
            new Vector2Int(1, 2),
            new Vector2Int(2, 1),
            new Vector2Int(3, 2),
            new Vector2Int(4, 3),
        },

        // 12
        new List<Vector2Int>()
        {
            new Vector2Int(0, 2),
            new Vector2Int(1, 1),
            new Vector2Int(2, 0),
            new Vector2Int(3, 1),
            new Vector2Int(4, 2),
        },

        // 13
        new List<Vector2Int>()
        {
            new Vector2Int(0, 0),
            new Vector2Int(1, 1),
            new Vector2Int(2, 2),
            new Vector2Int(3, 1),
            new Vector2Int(4, 0),
        },

        // 14
        new List<Vector2Int>()
        {
            new Vector2Int(0, 1),
            new Vector2Int(1, 2),
            new Vector2Int(2, 3),
            new Vector2Int(3, 2),
            new Vector2Int(4, 1),
        },
    };


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static double findMulti(int item, int amt)
    {
        double multi = 0.0;
        if (item == 1 && amt == 3) multi = 0.1;
        else if (item == 1 && amt == 4) multi = 0.5;
        else if (item == 1 && amt == 5) multi = 2;

        if (item == 2 && amt == 3) multi = 0.1;
        else if (item == 2 && amt == 4) multi = 0.5;
        else if (item == 2 && amt == 5) multi = 2;

        if (item == 3 && amt == 3) multi = 0.2;
        else if (item == 3 && amt == 4) multi = 1;
        else if (item == 3 && amt == 5) multi = 3;

        if (item == 4 && amt == 3) multi = 0.2;
        else if (item == 4 && amt == 4) multi = 1;
        else if (item == 4 && amt == 5) multi = 3;

        if (item == 5 && amt == 3) multi = 1;
        else if (item == 5 && amt == 4) multi = 3;
        else if (item == 5 && amt == 5) multi = 10;

        if (item == 6 && amt == 3) multi = 1;
        else if (item == 6 && amt == 4) multi = 3;
        else if (item == 6 && amt == 5) multi = 10;

        if (item == 7 && amt == 3) multi = 1.5;
        else if (item == 7 && amt == 4) multi = 5;
        else if (item == 7 && amt == 5) multi = 15;

        if (item == 8 && amt == 3) multi = 2;
        else if (item == 8 && amt == 4) multi = 7.5;
        else if (item == 8 && amt == 5) multi = 20;
        return multi;
    }
}
