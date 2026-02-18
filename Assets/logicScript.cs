using System;
using System.Collections;
using System.Threading;
using UnityEditor.Tilemaps;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System.Reflection.Emit;
using UnityEditor.PackageManager;

public class logicScript : MonoBehaviour
{
    public GameObject placeholder;
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;
    public GameObject f;
    public Text winningText;


    public static int xcol = 5;
    public static int ycol = 4;

    public static GameObject[,] tiles;
    public static int[,] symbolIDs;
    public Boolean pressedSpin = false;
    public float timer = 0;
    public float timeBetweenRows = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tiles = new GameObject[xcol, ycol];
        symbolIDs = new int[xcol, ycol];
        for (int x = 0; x < xcol; x++)
        {
            spawnSlotGridRow(x);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        

    }

    public void spawnSlotGridRow(int x)
    {

        for (int y = 0; y < ycol; y++)
        {

            spawnSpecificTile(x, y);

        }
    }

    public void spawnSpecificTile(int x, int y)
    {
        float offsetx = (xcol - 1) / 2f;
        float offsety = (ycol - 1) / 2f;
        GameObject tile = tiles[x, y];

        int id = symbolIDs[x, y];
        GameObject tilePrefab = placeholder;

        if (id == 1)
        {
            tilePrefab = a;
        }else if (id == 2)
        {
            tilePrefab = b;
        }else if (id == 3)
        {
            tilePrefab = c;
        }else if (id == 4)
        {
            tilePrefab = d;
        }else if (id == 5)
        {
            tilePrefab = e;
        }else if (id == 6)
        {
            tilePrefab = f;
        }

        Vector3 startPos = new Vector3(x - offsetx, y - offsety + 5, 0);
        Vector3 targetPos = new Vector3(x - offsetx, y - offsety, 0);

        tile = Instantiate(tilePrefab, startPos, Quaternion.identity);
        tile.transform.parent = transform;
        tile.name = "Slot Tile Specific";
        tiles[x, y] = tile;

        teleportDownScript dropAnim = tile.AddComponent<teleportDownScript>();
        dropAnim.targetPosition = targetPos;
    }

    public void deleteOldTiles()
    {
        for (int x = 0; x < xcol; x++)
        {
            for (int y = 0; y < ycol; y++)
            {
                GameObject tile = tiles[x, y];
                Destroy(tile);


            }
        }
    }

    public void spin()
    {
        deleteOldTiles();
        tiles = new GameObject[xcol, ycol];
        symbolIDs = new int[xcol, ycol];

        Dictionary<int, int> lineToLetter = new();
        List<int> usedLine = new();

        int winAmt = calculateRewards.NumberOfWins();
        Debug.Log("Win Amount: " + winAmt);


        // Loop for every winning payout
        for (int i = 0; i < winAmt; i++)
        {

            List<List<Vector2Int>> allLines = calculateRewards.lines;
            List<List<Vector2Int>> usableLines = new();

            List<double> stats = calculateRewards.WinMultiplier();
            int item = (int)stats[0];
            int amt = (int)stats[1];
            double multi = stats[2];

            // Go through each line individually, where singleLine = the current line
            foreach (List<Vector2Int> singleLine in allLines)
            {


                //Now check if this is a usable line

                //#1 - If Line is empty
                if (lineSpacesEmpty(amt, singleLine))
                {
                    usableLines.Add(singleLine);
                }
                else
                {
                    if (lineOnlyHasItem(amt, item, singleLine))
                    {
                        if (symbolIDs[singleLine[0].x, singleLine[0].y] == 0)
                        {
                            usableLines.Add(singleLine);

                        }
                    }
                }
                
            }
            if (usableLines.Count == 0)
            {
                Debug.Log("Error Occured and no possible lines found");
            }
            else
            {
                // Find random usable line to use
                List<Vector2Int> line = usableLines[Random.Range(0, usableLines.Count)];
                foreach (Vector2Int lineCoord in line)
                {
                    if (lineCoord.x < amt)
                    {
                        symbolIDs[lineCoord.x, lineCoord.y] = item;
                    }
                }

            }

        }

        // Fill rest with giberish


        // now lets double check all lines
        // add later
           

        StartCoroutine(spawnRowsWait());
        pressedSpin = false;
    }

    public Boolean lineOnlyHasItem(int length, int item, List<Vector2Int> line)
    {

        foreach (Vector2Int coord in line)
        {
            if (coord.x < length)
            {
                if (symbolIDs[coord.x, coord.y] != 0 && symbolIDs[coord.x, coord.y] != item)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public Boolean lineSpacesEmpty(int length, List<Vector2Int> line)
    {
        foreach (Vector2Int coord in line)
        {
            if (coord.x < length)
            {
                if (symbolIDs[coord.x, coord.y] != 0)
                {
                    return false; 
                }
            }
        }

        return true;
    }

    IEnumerator spawnRowsWait()
    {
        for (int x = 0; x < xcol; x++)
        {
            spawnSlotGridRow(x);
            yield return new WaitForSeconds(timeBetweenRows);
        }
    }
}
