using System;
using System.Collections;
using System.Threading;
using UnityEditor.Tilemaps;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System.Reflection.Emit;

public class logicScript : MonoBehaviour
{
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
        GameObject tilePrefab = f;

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
        if (pressedSpin == false)
        {
            deleteOldTiles();
            pressedSpin = true;
        }
        else
        {
            tiles = new GameObject[xcol, ycol];
            symbolIDs = new int[xcol, ycol];

            Dictionary<int, int> lineToLetter = new();
            List<int> usedLine = new();

            int winAmt = calculateRewards.NumberOfWins();
            Debug.Log("Win Amount: " + winAmt);

            for (int i = 0; i < winAmt; i++)
            {
                List<int> availableLines = new(){0,1,2,3,4,5,6,7,8,9,10,11,12,13};

                List<double> stats = calculateRewards.WinMultiplier();
                int item = (int) stats[0];
                int amt = (int) stats[1];
                double multi = stats[2];
                int line = -1;
                Debug.Log("Item:  " + item + " Amount: " + amt + " Multi: " + multi);

                foreach (int l in usedLine)
                {
                    List<int> interceptLines = calculateRewards.rowIncludes[l];
                    if (lineToLetter[l] == item)
                    {
                        foreach (int u in usedLine)
                        {
                            if (interceptLines.Contains(u))
                            {
                                interceptLines.Remove(u);
                            }

                        }
                        line = interceptLines[Random.Range(0, interceptLines.Count)];
                        Debug.Log(i + " Winning Line: " + line);
                    }

                }
                if (line == -1)
                {
                    foreach (int u in usedLine)
                        {
                            if (availableLines.Contains(u))
                            {
                                availableLines.Remove(u);
                            }

                        }
                }
                
                
            }
            

            StartCoroutine(spawnRowsWait());
            pressedSpin = false;
        }
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
