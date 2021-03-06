﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public int TrackIndex = 0;

    private MusicSong song;
    private MeshRenderer mesh;

    public MeshRenderer[] Partners;

    IEnumerable<MeshRenderer> Meshes
    {
        get
        {
            if (this.mesh != null)
            {
                yield return this.mesh;
            }
            foreach(var m in this.Partners)
            {
                yield return m;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.mesh = GetComponent<MeshRenderer>();
        foreach(var m in this.Meshes)
        {
            m.enabled = false;
        }
        this.song = GameObject.FindObjectOfType<MusicSong>();
        if(this.song == null)
        {
            Debug.Log(string.Format("Goal {0} was unable to find song", this.gameObject.name));
        }

        bool has_meshes = false;
        foreach(var m in this.Meshes)
        {
            has_meshes = true;
        }
        if(has_meshes == false)
        {
            Debug.Log(string.Format("No meshes for {0}", this.gameObject.name));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Movement>();
        if (player != null) return;

        var thing = collision.gameObject.GetComponent<Thing>();
        if (thing == null) return;

        if(this.TrackIndex != thing.TrackIndex)
        {
            return;
        }

        foreach(var m in Meshes)
        {
            if (m.enabled)
            {
                // return;
            }
        }
        Debug.Log(string.Format("Goal {1} collided with {0}", collision.gameObject.name, this.gameObject.name));

        GameObject.Destroy(collision.gameObject);

        foreach(var m in Meshes)
        {
            m.enabled = true;
        }


        if (this.song != null)
        {
            this.song.DoCrossfade(this.TrackIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
