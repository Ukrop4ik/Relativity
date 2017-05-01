using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource join_sound;
    public AudioSource bonus_get_sound;
    public AudioSource end_level_sound;
    public AudioSource unjoin_sound;
    public AudioSource click_sound;
    public AudioSource boom_sound;
    public AudioSource time_sound;
    public AudioSource fail_sound;
    public AudioSource teleport_sound;

    public void PlaySound(AudioEnum auidoenum)
    {
        AudioEnum a = auidoenum;
        switch (a)
        {
            case AudioEnum.Join:
                if (!join_sound.isPlaying) join_sound.Play();
                break;
            case AudioEnum.Bonus:
                if (!bonus_get_sound.isPlaying) bonus_get_sound.Play();
                break;
            case AudioEnum.EndLevel:
                if (!end_level_sound.isPlaying) end_level_sound.Play();
                break;
            case AudioEnum.Unjoin:
                if (!unjoin_sound.isPlaying) unjoin_sound.Play();
                break;
            case AudioEnum.Click:
                if (!click_sound.isPlaying) click_sound.Play();
                break;
            case AudioEnum.Boom:
                if (!boom_sound.isPlaying) boom_sound.Play();
                break;
            case AudioEnum.Time:
                if (!time_sound.isPlaying) time_sound.Play();
                break;
            case AudioEnum.Fail:
                if (!fail_sound.isPlaying) fail_sound.Play();
                break;
            case AudioEnum.Teleport:
                if (!teleport_sound.isPlaying) teleport_sound.Play();
                break;
        }
    }
}
