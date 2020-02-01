using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public int TrackIndex = 0;

    private MusicSong song;

    // Start is called before the first frame update
    void Start()
    {
        this.song = GameObject.FindObjectOfType<MusicSong>();
        if(this.song == null)
        {
            Debug.Log(string.Format("Goal {0} was unable to find song", this.gameObject.name));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(string.Format("Goal collided with {0}", collision.gameObject.name));

        GameObject.Destroy(collision.gameObject);
        GameObject.Destroy(this.gameObject);

        if(this.song != null)
        {
            this.song.DoCrossfade(this.TrackIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
