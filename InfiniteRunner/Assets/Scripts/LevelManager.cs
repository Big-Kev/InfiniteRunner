using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//selects level segments from a pool or pools and instanciates them, also manages scroll speed
//Could be improved by adding a probability variable to each levelsegment
public class LevelManager : MonoBehaviour
{
    //level generation variables
    //Stores one or more tilesets to be used for generating the level
    public Tileset[] tilesets;
    List<Tileset> m_tilesets = new List<Tileset>();
    public GameObject startingTile;

    //Current level variables
    bool running = true;
    SideScrollerPlayer player;
    float scrollSpeed;
    List<LevelSegment> levelSegments = new List<LevelSegment>();
    public int maxActiveSegments = 5;



    void start()
    {
        //setting up and validating tilesets (Move this to its own function later?)
        if (tilesets.Length > 0)
        {
            //sorts all tilesets into valid(not empty) & invalid(empty)
            List<Tileset> deathrow = new List<Tileset>();
            foreach (Tileset t in tilesets)
            {
                if (t.validate())
                {
                    m_tilesets.Add(t);
                }
                else
                {
                    deathrow.Add(t);
                }
            }

            //deletes tilesets that are invalid
            for (int i = 0; i < deathrow.Count; i++)
            {
                Destroy(deathrow[i]);
            }
        }
        else
        {
            Debug.Log("No tilesets loaded into level manager");
            running = false;
        }

        //setting up game variables
        scrollSpeed = player.moveSpeed;


        //Instanciate Starter plaform
        GameObject starterSegment = Instantiate(startingTile);
        starterSegment.transform.position = new Vector3(0, 0, 0);
        levelSegments.Add(starterSegment.GetComponent<LevelSegment>());


    }

    void update()
    {
        if (levelSegments.Count < maxActiveSegments)
        {
            CreateSegment();
        }
        
    }

    //this function selects a tile from the tileset(s) to create and instanciates it 
    void CreateSegment()
    {
        if (running)
        {
            //randomly select a segment from pools available

            //In case of one pool(therfore pool does not need to be selected randomly)
            if (m_tilesets.Count == 1)
            {
                //randomly select tile
                int segmentCount = m_tilesets[1].levelSegements.Length;
                int segementIndex = Random.Range(0, segmentCount);
                //create and settup tile
                GameObject newSegment = Instantiate(m_tilesets[1].levelSegements[segementIndex]);
                //add position etc

            }
            if (m_tilesets.Count > 1)
            {
                //randomly select tileset
                int tileSetCount = m_tilesets.Count;
                int tileSetIndex = Random.Range(0, tileSetCount);
                //randomly select tile from selected tileset
                int segmentCount = m_tilesets[tileSetIndex].levelSegements.Length;
                int segementIndex = Random.Range(0, segmentCount);
                //Create and settup new tile
                GameObject newSegment = Instantiate(m_tilesets[tileSetIndex].levelSegements[segementIndex]);
                //add position etc

            }
        }
    }
}
