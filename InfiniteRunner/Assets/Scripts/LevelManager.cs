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
    public bool running = true;
    public SideScrollerPlayer player;
    float scrollSpeed;
    List<LevelSegment> levelSegments = new List<LevelSegment>();
    public int maxActiveSegments = 5;

    public float DeletionXValue = -20;


    void Start()
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
        LevelSegment segment = starterSegment.GetComponent<LevelSegment>();
        levelSegments.Add(segment);
        segment.moveToStartOffset(this.transform);
        segment.myLevel = this;
    }

    void Update()
    {
        if (levelSegments.Count < maxActiveSegments)
        {
            CreateSegment(levelSegments[levelSegments.Count - 1].EndConnector);

        }

        List<LevelSegment> deathrow = new List<LevelSegment>();
        foreach (LevelSegment s in levelSegments)
        {
            if (s.transform.position.x < DeletionXValue)
            {
                deathrow.Add(s);
            }
            else
            {
                s.gameObject.transform.position += new Vector3(-scrollSpeed * Time.deltaTime, 0, 0);
            }
            //s.GetComponent<Rigidbody>().velocity = new Vector3(-scrollSpeed * Time.deltaTime, 0, 0);

        }
        for (int i = 0; i < deathrow.Count; i++)
        {
            deathrow[i].removeSegment();
        }

        Debug.Log("Remove this before finishing");
        //Debug
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 10;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1;
        }
    }


    public void removeLevelSegment(LevelSegment s)
    {
        levelSegments.Remove(s);
    }
    //this function selects a tile from the tileset(s) to create and instanciates it 
    void CreateSegment(Transform nextPosition)
    {
        if (running)
        {
            //randomly select a segment from pools available

            //In case of one pool(therfore pool does not need to be selected randomly)
            if (m_tilesets.Count == 1)
            {
                //randomly select tile
                int segmentCount = m_tilesets[0].levelSegements.Length;
                int segementIndex = Random.Range(0, segmentCount);
                //create and settup tile
                GameObject newSegment = Instantiate(m_tilesets[0].levelSegements[segementIndex]);
                levelSegments.Add(newSegment.GetComponent<LevelSegment>());
                newSegment.GetComponent<LevelSegment>().moveToStartOffset(nextPosition);
                newSegment.GetComponent<LevelSegment>().myLevel = this;
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
                levelSegments.Add(newSegment.GetComponent<LevelSegment>());
                newSegment.GetComponent<LevelSegment>().moveToStartOffset(nextPosition);
                newSegment.GetComponent<LevelSegment>().myLevel = this;
            }
        }
    }
}
