using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TableTopPuzzleGenerator : MonoBehaviour
{
    private float tableLength;
    private float tableHeight;
    private float tableWidth;
    private Renderer renderer;
    private Vector3[] spawnLocations = new Vector3[9];
    Dictionary<Vector3, bool> tableItemSpawnCheck = new Dictionary<Vector3, bool>();// used to check if an item has been spawned in a certain location, makes sure  2 items are neven in the same location
    private TextMeshProUGUI tableNumberDisplay;

    [SerializeField]
    private GameObject[] tableItemPrefabs;// an array of possible spawned objects

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        tableLength = renderer.bounds.size.x;
        tableHeight = renderer.bounds.size.y;
        tableWidth = renderer.bounds.size.z;

        tableNumberDisplay = transform.Find("Canvas").Find("TableNumberDisplay").GetComponent<TextMeshProUGUI>();
        tableNumberDisplay.SetText("");
    }

    // makes a 9 x 9 grid for all spawn locations of table items which will be used in the puzzle
    public void SetSpawnLocations()
    {
        spawnLocations[0] = new Vector3(transform.position.x - tableLength / 3, tableHeight, transform.position.z + tableWidth / 3);
        spawnLocations[1] = new Vector3(transform.position.x, tableHeight, transform.position.z + tableWidth / 3);
        spawnLocations[2] = new Vector3(transform.position.x + tableLength / 3, tableHeight, transform.position.z + tableWidth / 3);

        spawnLocations[3] = new Vector3(transform.position.x - tableLength / 3, tableHeight, transform.position.z);
        spawnLocations[4] = new Vector3(transform.position.x, tableHeight, transform.position.z);
        spawnLocations[5] = new Vector3(transform.position.x + tableLength / 3, tableHeight, transform.position.z);

        spawnLocations[6] = new Vector3(transform.position.x - tableLength / 3, tableHeight, transform.position.z - tableWidth / 3);
        spawnLocations[7] = new Vector3(transform.position.x, tableHeight, transform.position.z - tableWidth / 3);
        spawnLocations[8] = new Vector3(transform.position.x + tableLength / 3, tableHeight, transform.position.z - tableWidth / 3);

        for (int i = 0; i < spawnLocations.Length; i++)
        {
            tableItemSpawnCheck.Add(spawnLocations[i], false);
        }
    }

    // places set amount of items in random positions, making sure none are in the same position
    // sets the table number to be coreespondant to the tables 'position' in the vaults passcode
    public void GenerateTableItems(int amount, int TableNumber)
    {
        for (int i = 0; i < amount; i++)
        {
            int randomlySelectedLocation;
            do
            {
                randomlySelectedLocation = Random.Range(0, 9);
            }
            while (tableItemSpawnCheck[spawnLocations[randomlySelectedLocation]] == true);

            GameObject newTableItem = Instantiate(tableItemPrefabs[Random.Range(0, tableItemPrefabs.Length)], spawnLocations[randomlySelectedLocation], Quaternion.identity);
            tableItemSpawnCheck[spawnLocations[randomlySelectedLocation]] = true;
            newTableItem.transform.rotation = Quaternion.Euler(0f, Random.Range(0, 360f), 0f);
        }

        tableNumberDisplay.SetText(TableNumber.ToString());
    }

    void Update()
    {
        
    }
}
