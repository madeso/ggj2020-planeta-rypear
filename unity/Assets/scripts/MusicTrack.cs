using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrack : MonoBehaviour
{
    public float FadeTime = 1;
    public AudioSource From;
    public AudioSource To;

    public void Start()
    {
        if(this.From != null && this.To != null && this.From == this.To)
        {
            Debug.Log(string.Format("ohnoes: from and to are the same for {0}!", this.gameObject.name));
            this.To = null;
        }

        SetVolume(this.From, 1);
        SetVolume(this.To, 0);
    }

    private static void SetVolume(AudioSource src, float v)
    {
        if (src == null) return;
        src.volume = v;
    }

    float fade = 0;
    bool isfading = false;
    public bool IsDone { get; private set; } = false;

    // Update is called once per frame
    void Update()
    {
        if (isfading == false) return;

        fade += Time.deltaTime * this.FadeTime;
        if(fade > 1)
        {
            fade = 1;
            this.isfading = false;
            this.IsDone = true;
        }

        SetVolume(this.From, 1 - fade);
        SetVolume(this.To, fade);
    }

    public void DoCrossfade()
    {
        this.isfading = true;
    }
}
