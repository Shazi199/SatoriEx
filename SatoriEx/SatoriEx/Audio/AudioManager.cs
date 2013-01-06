using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace SatoriEx.Audio
{
    class AudioManager
    {
        AudioEngine audioEngine;
        WaveBank waveBank;
        SoundBank soundBank;
        Cue bgmCue;

        public AudioManager()
        {
            audioEngine = new AudioEngine(@"Content/Audio/GameAudio.xgs");
            waveBank = new WaveBank(audioEngine, @"Content/Audio/Wave Bank.xwb");
            soundBank = new SoundBank(audioEngine, @"Content/Audio/Sound Bank.xsb");
        }

        public void Update()
        {
            audioEngine.Update();
        }

        public void play(string soundname)
        {
            soundBank.GetCue(soundname).Play();
        }

        public void playBGM(string bgmname)
        {
            bgmCue = soundBank.GetCue(bgmname);
            bgmCue.Play();
        }
        public void stopBGM()
        {
            if (bgmCue != null && bgmCue.IsPlaying == true)
            {
                bgmCue.Stop(AudioStopOptions.Immediate);
            }
        }
        public void pauseBGM()
        {
            if (bgmCue != null && bgmCue.IsPlaying == true)
            {
                bgmCue.Pause();
            }
        }
        public void resumeBGM()
        {
            if (bgmCue != null && bgmCue.IsPaused == true)
            {
                bgmCue.Resume();
            }
        }
    }
}
