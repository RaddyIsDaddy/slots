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
using System.Linq;
using System.Runtime.CompilerServices;


// I THINK FULL LINES DONT WORK? If you get x0 - 4

public class logicScript : MonoBehaviour
{
    //REELS
    public static List<List<int>> REELS = new List<List<int>>()
    {
        new List<int>()
        {
        1,2,3,1,4,2,1,5,0,2,1,3,4,1,6,2,1,3,10,2,
        1,4,2,7,1,3,2,1,5,2,1,8,3,2,1,4,0,2,1,6,
        3,1,2,4,1,7,2,1,5,3,2,1,4,10,2,1,6,3,1,2,
        4,1,8,2,1,3,2,1,5,4,1,2,7,3,1,0,2,1,6,4,
        1,2,3,1,4,2,1,5,10,2,1,3,4,1,6,2,1,3,7,2
        },
        new List<int>()
        {
        2,1,4,2,3,1,5,2,1,6,3,2,1,4,10,2,1,7,3,2,
        1,5,2,1,8,3,2,1,4,0,2,1,6,3,1,2,7,4,1,2,
        3,1,5,2,1,4,2,1,6,3,2,1,7,10,2,1,5,3,1,2,
        4,1,8,2,1,3,2,1,5,4,1,2,6,3,1,0,2,1,7,4,
        1,2,3,1,4,2,1,5,10,2,1,3,4,1,6,2,1,3,8,2
        },
        new List<int>()
        {
        3,2,1,4,2,1,6,3,2,1,5,4,1,2,7,3,2,1,10,4,
        2,1,5,3,2,1,8,4,1,2,6,3,1,2,7,4,1,0,2,5,
        3,1,2,4,1,6,2,1,5,3,2,1,7,10,2,1,4,3,1,2,
        5,1,8,2,1,3,2,1,6,4,1,2,7,3,1,0,2,1,5,4,
        1,2,3,1,4,2,1,6,10,2,1,3,4,1,5,2,1,3,7,2
        },
        new List<int>()
        {
        4,1,2,5,1,3,2,1,6,4,1,2,7,3,1,2,10,5,2,1,
        4,3,1,2,6,4,1,2,8,3,2,1,5,0,2,1,7,4,1,2,
        3,1,6,2,1,5,2,1,4,3,2,1,7,10,2,1,6,3,1,2,
        5,1,8,2,1,4,2,1,6,4,1,2,7,3,1,0,2,1,5,4,
        1,2,3,1,4,2,1,6,10,2,1,3,4,1,5,2,1,3,8,2
        },
        new List<int>()
        {
        5,1,3,2,1,6,2,1,4,3,2,1,7,5,1,2,10,6,2,1,
        4,3,1,2,5,4,1,2,8,3,2,1,6,0,2,1,7,4,1,2,
        3,1,6,2,1,5,2,1,4,3,2,1,7,10,2,1,6,3,1,2,
        5,1,8,2,1,4,2,1,6,4,1,2,7,3,1,0,2,1,5,4,
        1,2,3,1,4,2,1,6,10,2,1,3,4,1,5,2,1,3,7,2
        },
    };




    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;
    public GameObject f;
    public GameObject g;
    public GameObject h;
    public GameObject i;
    public GameObject j;
    public Text winningText;
    public AudioSource spinSound;
    public AudioSource defaultWin;

    public static int xcol = 5;
    public static int ycol = 4;

    public static GameObject[,] tiles;
    public static int[,] symbolIDs;
    public Boolean pressedSpin = false;
    public float timerPayLine = 0;
    public float timeBetweenRows = 3f;
    public float waitBetweenPayLines = 5f;
    public float waitBeforeFirstPayLine = 2f;
    float offsetx = (xcol - 1) / 2f;
    float offsety = (ycol - 1) / 2f;
    private LineRenderer payline;
    public Boolean cooldown = false;

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
        if (timerPayLine > 0)
        {
            timerPayLine += Time.deltaTime;
            if (timerPayLine >= waitBetweenPayLines)
            {
                timerPayLine = 0;
                Destroy(payline);
                winningText.text = "";
                cooldown = false;
            }
        }
        

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
        GameObject tile = tiles[x, y];

        int id = symbolIDs[x, y];
        GameObject tilePrefab;

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
        else if (id == 7)
        {
            tilePrefab = g;
        }
        else if (id == 8)
        {
            tilePrefab = h;
        }
        else if (id == 10)
        {
            tilePrefab = i;
        }
        else if (id == 0)
        {
            tilePrefab = j;
        }
        else
        {
            tilePrefab = a;
            Debug.Log("ERROR MADE TILE A SINCE IT WAS NOT SET" + id);
        }

        Vector3 startPos = new Vector3(x - offsetx, y - offsety + ycol + 1, 0);
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

        if (cooldown)
        {
            return;
        }
        cooldown = true;
        spinSound.Play();
        deleteOldTiles();
        tiles = new GameObject[xcol, ycol];
        symbolIDs = new int[xcol, ycol];


        int reelnum = -1;
        foreach (List<int> reel in REELS)
        {
            reelnum++;
            int index = Random.Range(0, reel.Count - ycol);
            for (int i = 0; i < ycol; i++)
            {
                int item = reel[index];
                symbolIDs[reelnum, i] = item;
                index++;
            }
        }


        List<List<Vector2Int>> winningLines = new();
        Dictionary<List<Vector2Int>, int> winlinesAmt = new();
        List<List<Vector2Int>> lines = calculateRewards.lines;
        int lnum = -1;
        foreach (List<Vector2Int> l in lines)
        {
            lnum++;
            int item = 100;
            Boolean lineDone = false;
            foreach (Vector2Int box in l)
            {
                if (lineDone == false) 
                {
                    // Line has not failed yet

                    if (item == 100)
                    {
                        if (box.x == 4)
                        {
                            // If first 3 symbols are wilds - Line is a full win
                            Debug.Log(lnum + " First 3 symbols wild");
                            winningLines.Add(l);
                            winlinesAmt.Add(l, box.x + 1);
                            lineDone = true;
                        }

                        else if(symbolIDs[box.x, box.y] != 10)
                        {
                            // First non wild item
                            Debug.Log(lnum + " Found first non wild item");
                            item = symbolIDs[box.x, box.y];
                        }

                    }

                    else
                    {

                        if (box.x == 4)
                        {
                            // We are on last x 
                            if (item == symbolIDs[box.x, box.y] || symbolIDs[box.x, box.y] == 10)
                            {
                                // Last X AND the last x is continued part of line
                                Debug.Log(lnum + " Full Line");
                                winningLines.Add(l);
                                winlinesAmt.Add(l, box.x + 1);
                                lineDone = true;
                            }
                            else
                            {
                                // Last X but last is not the continued line item
                                Debug.Log(lnum + " 1 Away from full line");
                                winningLines.Add(l);
                                winlinesAmt.Add(l, box.x);
                                lineDone = true;
                            }
                        }

                        else
                        {
                            // It is not the last x
                            if (item == symbolIDs[box.x, box.y])
                            {
                                // Last item is current item
                                item = symbolIDs[box.x, box.y];
                            }
                            else if (symbolIDs[box.x, box.y] != 10)
                            {
                                // This item does not follow the lines pattern.
                                if (box.x >= 3)
                                {
                                    Debug.Log(lnum + " Line of size: " + box.x);
                                    // The total pattern was 3 tiles or more
                                    winningLines.Add(l);
                                    winlinesAmt.Add(l, box.x);
                                    lineDone = true;
                                }
                                else
                                {
                                    // End of line which is not 3 tiles
                                    Debug.Log(lnum + " Line failed.");
                                    lineDone = true;
                                }
                            }
                        }

                    }
                }
            }
        }


        StartCoroutine(spawnRowsWait(winningLines, winlinesAmt));
        pressedSpin = false;

    }

    public void drawPayLine(List<Vector2Int> line, int amt)
    {
        if (payline == null)
        {
            payline = gameObject.GetComponent<LineRenderer>();

            if (payline == null)
            {
                payline = gameObject.AddComponent<LineRenderer>();
                payline.sortingOrder = 0;
            }
            payline.startColor = Color.orangeRed;
            payline.endColor = Color.red;
            payline.startWidth = 0.05f;
            payline.endWidth = 0.05f;
        }

        payline.positionCount = amt;

        Vector3 startCoord = new();
        Vector3 endCoord = new();
        int item = 0;
        for (int i = 0; i < amt; i++)
        {
            Vector3 coord = new Vector3(line[i].x - offsetx, line[i].y - offsety, 0);
            payline.SetPosition(i, coord);

            if (symbolIDs[line[i].x, line[i].y] != 10)
            {
                item = symbolIDs[line[i].x, line[i].y];
            }

            if (i == 0)
            {
                startCoord = coord;
            }
            else if (i == amt - 1)
            {
                endCoord = coord;
            }

        }

        Vector3 middle = (startCoord + endCoord) / 2;
        winningText.transform.position = Camera.main.WorldToScreenPoint(middle);
        double multi = calculateRewards.findMulti(item, amt);
        winningText.text = multi.ToString() + "x";
        defaultWin.PlayOneShot(defaultWin.clip);
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

    IEnumerator spawnRowsWait(List<List<Vector2Int>> winningLines, Dictionary<List<Vector2Int>, int> winlinesAmt)
    {
        for (int x = 0; x <= xcol; x++)
        {
            if (x == xcol)
            {
                StartCoroutine(spawnPayLines(winningLines, winlinesAmt));
            }
            else
            {
                spawnSlotGridRow(x);

                if (x == xcol - 1)      { yield return new WaitForSeconds(waitBeforeFirstPayLine); }
                else                    { yield return new WaitForSeconds(timeBetweenRows);  }

            }
        }
    }

    IEnumerator spawnPayLines(List<List<Vector2Int>> winningLines, Dictionary<List<Vector2Int>, int> winlinesAmt)
    {
        foreach (List<Vector2Int> line in winningLines)
        {

            
            int amt = winlinesAmt[line];
            drawPayLine(line, amt);
            yield return new WaitForSeconds(waitBetweenPayLines);
        }
        timerPayLine += Time.deltaTime;

    }
}
