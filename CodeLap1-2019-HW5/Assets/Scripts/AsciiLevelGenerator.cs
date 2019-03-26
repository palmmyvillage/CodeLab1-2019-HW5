using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AsciiLevelGenerator : MonoBehaviour
{

    private const string LEVEL = "/level0.txt"; //storing file name in string
    private string levelGenerator; //use this to randomly generate level

    public List<int> numbers;
    

    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
        ImplementLevel();
    }

    
    //use this to implement level
    #region ImplementLevel

    public void ImplementLevel()
    {
        for (int i = 0; i < 50; i++) //ini all numbers into list
        {
            numbers.Add(i+1);
        }
        
        string filePath = Application.dataPath + LEVEL;
        File.WriteAllText(filePath,levelGenerator); //write or overwrite the file for level ganeration
        
        string[] inputLines = File.ReadAllLines(filePath); //split line

        for (int y = 0; y < inputLines.Length; y++)
        {
            string line = inputLines[y];
            for (int x = 0; x < line.Length; x++)
            {
                if (line[x] == 'x')
                {
                    GameObject newTile = Instantiate(Resources.Load("Prefabs/Tile")) as GameObject;
                    newTile.transform.position = new Vector3(x - line.Length / 2f, inputLines.Length / 2f - y) * 1.2f;

                    int randomNum = numbers[Random.Range(0, numbers.Count)];
                    newTile.GetComponentInChildren<TextMesh>().text = randomNum.ToString();
                    numbers.Remove(randomNum);
                }
            }
        }
    }

    #endregion

    
    
    //use this to generate level
    #region GenerateLevel

    public void GenerateLevel()
    {
        string tileSet = "x-";
        int tileNum = 50;
        int spaceMax = 104;
        int space = spaceMax;
        int lineRange = 0;

        for (int i = 0; i < spaceMax; i++)
        {
            if (tileNum < space) //check if there is space left
            {
                char tile = tileSet[Random.Range(0, tileSet.Length)];

                if (tile == 'x' && tileNum > 0) //check if get number and there is number left
                {
                    tileNum--;
                    levelGenerator += tile;
                }
                else
                {
                    levelGenerator += '-';
                }
            }
            else
            {
                levelGenerator += 'x';
            }
            
            space--;
            lineRange++;

            if (lineRange == 13)
            {
                levelGenerator += '\n';
                lineRange = 0;
            }
        }
    }

    #endregion
}
