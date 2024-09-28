using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    GameObject[] tables;// the tables that will be used to display the puzzle to the player
    Vault vault;// for setting the vault passcode
    private int[] passCodeDigits;// an array of the digits in the passcode, used for setting up the puzzle by telling tables how many items to spawn
    private TextMeshProUGUI clueNoteText;
    void Start()
    {
        GenerateTableTopPuzzle();
    }

    // randomly generates a passcode based on how many tables there are
    private void SetPassCode()
    {
        vault.passCode = "";
        for (int i = 0; i < passCodeDigits.Length; i++)
        {
            passCodeDigits[i] = Random.Range(0, 10);
            vault.passCode += passCodeDigits[i];
        }
    }

    private void GenerateTableItems()
    {
        for (int i = 0; i < tables.Length; i++)
        {
            tables[i].GetComponent<TableTopPuzzleGenerator>().SetSpawnLocations();// sets a 9 x 9 grid of all possible spawn locations for table items
            tables[i].GetComponent<TableTopPuzzleGenerator>().GenerateTableItems(passCodeDigits[i], i+1);// makes the table generate number of items based on its position in the passcode and the actual number in that position
        }
    }

    // each table swaps its position with a random table
    private void ShuffleTables()
    {
        for (int i = 0; i < tables.Length; i++)
        {
            Vector3 currentPosition = tables[i].transform.position;
            Quaternion currentRotation = tables[i].transform.rotation;

            int swappedTable;

            do
            {
                swappedTable = Random.Range(0, tables.Length - 1);
            }
            while (swappedTable == i);

            tables[i].transform.position = tables[swappedTable].transform.position;
            tables[i].transform.rotation = tables[swappedTable].transform.rotation;

            tables[swappedTable].transform.position = currentPosition;
            tables[swappedTable].transform.rotation = currentRotation;
        }
    }

    private void GenerateTableTopPuzzle()
    {
        tables = GameObject.FindGameObjectsWithTag("PuzzleTable");
        vault = GameObject.FindGameObjectWithTag("Vault").GetComponent<Vault>();
        passCodeDigits = new int[tables.Length];
        clueNoteText = GameObject.FindGameObjectWithTag("ClueNoteText").GetComponent<TextMeshProUGUI>();
        ShuffleTables();
        SetPassCode();
        GenerateTableItems();
        SetClue();
    }

    // makes the objects related to collection/ ally puzzle to be collectable
    public void ActivateCollectionPuzzle()
    {
        for(int i = 0; i < GameObject.FindGameObjectsWithTag("Batteries").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("Batteries")[i].AddComponent<Collectable>();
        }
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Money").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("Money")[i].AddComponent<Collectable>();
        }
    }

    private void SetClue()
    {
        clueNoteText.SetText("Code: \n" + passCodeDigits[0] + "X" + passCodeDigits[2] + "XX");
    }
}
