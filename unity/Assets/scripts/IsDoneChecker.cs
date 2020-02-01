using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsDoneChecker : MonoBehaviour
{
    private MusicSong song;
    public float TimeToNext = 3;

    float cursor = 0;


    void Start()
    {
        this.song = GameObject.FindObjectOfType<MusicSong>();
        if (this.song == null)
        {
            Debug.Log(string.Format("IsDoneChecker {0} was unable to find song", this.gameObject.name));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(this.song == null) { return; }

        if(this.song.IsDone == false)
        {
            return;
        }

        cursor += Time.deltaTime;

        if(cursor > this.TimeToNext)
        {
            cursor = -42;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
