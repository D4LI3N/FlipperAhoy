using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource src;
    public AudioClip game, menu, plunger, flipper, barrel, death, gameOver, bumper;
    public static Sounds instance;


    private void Awake()
    {
        instance = this;
    }

    public void Play(AudioClip sound, bool once = true)
    {
        if (once)
        {
            src.PlayOneShot(sound);
        }
        else
        {
            src.clip = sound;
            src.loop = true;
            src.Play();
        }
    }

    public void StopAll()
    {
        src.Stop();
    }



    public void Game() { Play(game, false); }
    public void Menu() { Play(menu, false); }
    public void Plunger() { Play(plunger); }
    public void Flipper() { Play(flipper); }
    public void Barrel() { Play(barrel); }
    public void Death() { Play(death); }
    public void GameOver() { Play(gameOver); }
    public void Bumper() { Play(bumper); }

    }