using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/Tileset")]
public class Tileset : ScriptableObject
{
    public GameObject[] levelSegements;

    //Checks if this scriptable object is in a usable state
    public bool validate()
    {
        if(levelSegements.Length < 1)
        {
            return false;
        }
        return true;
    }
}
