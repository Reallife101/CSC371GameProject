using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class musicData
{
    public bool[] songsInUse;
    public bool[] songsUnlocked;

    public musicData(musicManager mm)
    {
        songsInUse = mm.songsInUse;
        songsUnlocked = mm.songsUnlocked;

    }

    public musicData(bool[] inUse, bool[] Unlocked)
    {
        songsInUse = inUse;
        songsUnlocked = Unlocked;

    }
}
