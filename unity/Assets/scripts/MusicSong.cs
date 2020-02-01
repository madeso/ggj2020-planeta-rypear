using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSong : MonoBehaviour
{
    public MusicTrack[] Tracks;

    public void DoCrossfade(int track)
    {
        if(track >= this.Tracks.Length)
        {
            Debug.Log(string.Format("Index too large: {0}", track));
            return;
        }

        this.Tracks[track].DoCrossfade();
    }

    public bool IsDone
    {
        get
        {
            if(this.Tracks.Length == 0)
            {
                return false;
            }

            foreach(var t in this.Tracks)
            {
                if(t.IsDone == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
