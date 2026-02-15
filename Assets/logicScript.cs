using System;
using System.Collections;
using System.Threading;
using UnityEditor.Tilemaps;
using UnityEngine;
using Random = UnityEngine.Random;

public class logicScript : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;
    public GameObject f;


    public static int xcol = 6;
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
        GameObject tilePrefab = a;

        if (id == 0)
        {
            tilePrefab = a;
        }else if (id == 1)
        {
            tilePrefab = b;
        }

        Vector3 startPos = new Vector3(x - offsetx, y - offsety + 5, 0);
        Vector3 targetPos = new Vector3(x - offsetx, y - offsety, 0);

        tile = Instantiate(tilePrefab, startPos, Quaternion.identity);
        tile.transform.parent = transform;
        tile.name = "Slot Tile Specific";
        tiles[x, y] = tile;
        Debug.Log("Spawning x: " + x.ToString() + " and y:" + y.ToString() + " At: " + startPos.ToString());

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

            int line = Random.Range(0, 4);
            calculateRewards.WinningLine(line, 1);

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
