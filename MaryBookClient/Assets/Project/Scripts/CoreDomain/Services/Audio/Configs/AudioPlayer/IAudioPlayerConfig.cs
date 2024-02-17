﻿using UnityEngine;

namespace Project.CoreDomain.Services.Audio.Configs.AudioPlayer
{
    public interface IAudioPlayerConfig
    {
        string Id { get; }
        AudioClip Clip { get; }
        float FadeSeconds { get; }
        bool IsLoop { get; }
    }
}