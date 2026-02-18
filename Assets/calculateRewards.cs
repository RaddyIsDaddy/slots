using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calculateRewards : MonoBehaviour
{

    public static Text winText;

    public static List<List<int>> rowIncludes = new List<List<int>>()
    {
        
        new List<int>(){4, 7, 10, 13}, // 1
        
        new List<int>(){4, 5, 7, 8, 10, 11, 12, 13}, // 2
        
        new List<int>(){5, 6, 8, 9, 10, 11, 12, 13}, // 3
        
        new List<int>(){6, 9, 11, 12}, // 4
        
        new List<int>(){0, 1, 8, 10, 13}, // 5
        
        new List<int>(){1, 2, 7, 9, 11, 12, 13}, // 6
        
        new List<int>(){2, 3, 8, 9, 10, 13}, // 7
        
        new List<int>(){0, 1, 5, 11, 12}, // 8
        
        new List<int>(){1, 2, 4, 6, 10, 13}, // 9
        
        new List<int>(){2, 3, 5, 11, 12}, // 10
        
        new List<int>(){0, 1, 2, 4, 6, 8, 13}, // 11
        
        new List<int>(){1, 2, 3, 5, 7, 9, 12}, // 12
        
        new List<int>(){1, 2, 3, 5, 7, 9, 11}, // 13
        
        new List<int>(){0, 1, 2, 4, 6, 8, 10}, // 14
    };
    public static List<List<Vector2Int>> lines = new List<List<Vector2Int>>()
    {
        // 1 FIRST ROW FROM BOTTOM
        new List<Vector2Int>()
        {
            new Vector2Int(0, 3),
            new Vector2Int(1, 3),
            new Vector2Int(2, 3),
            new Vector2Int(3, 3),
            new Vector2Int(4, 3),
        },

        // 2 SECOND ROW FROM BOTTOM
        new List<Vector2Int>()
        {
            new Vector2Int(0, 2),
            new Vector2Int(1, 2),
            new Vector2Int(2, 2),
            new Vector2Int(3, 2),
            new Vector2Int(4, 2),
        },

        // 3 THIRD ROW FROM BOTTOM
        new List<Vector2Int>()
        {
            new Vector2Int(0, 1),
            new Vector2Int(1, 1),
            new Vector2Int(2, 1),
            new Vector2Int(3, 1),
            new Vector2Int(4, 1),
        },

        // 4 FOUTH ROW FROM BOTTOM
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
    public static int NumberOfWins()
    {
        float r = Random.Range(0, 100);
        if (r <= 50)
        {
            return 1;
        }
        else if (r <= 75)
        {
            return 2;
        }
        else if (r <= 90)
        {
            return 3;
        }
        else
        {
            return 4;
        }
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


    public static List<double> WinMultiplier()
    {
        int item;
        int amt;

        float ri = Random.Range(0f, 100f);
        if (ri < 40f)        item = 1;
        else if (ri < 65f)   item = 2;
        else if (ri < 80f)   item = 3;
        else if (ri < 90f)   item = 4;
        else if (ri < 97f)   item = 5;
        else                item = 6;
        
        float ra = Random.Range(0f, 100f);
        if (ra < 55f)        amt = 3;
        else if (ra < 80f)   amt = 4;
        else   amt = 5;

        double multi = findMulti(item, amt);

        List<double> l = new List<double>() {item, amt, multi};
        return l;
    }
}
