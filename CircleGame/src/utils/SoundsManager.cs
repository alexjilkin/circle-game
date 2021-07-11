using System.IO;
using Microsoft.Xna.Framework.Audio;

namespace CircleGame.utils
{
    public static class SoundManager
    {
        public readonly static SoundEffect positive = SoundEffect.FromFile("..\\assets\\sounds\\positive.wav");
        public readonly static SoundEffect theme = SoundEffect.FromFile("..\\assets\\sounds\\theme.wav");
        public readonly static SoundEffect hit = SoundEffect.FromFile("..\\assets\\sounds\\hit.wav");
        public readonly static SoundEffect death = SoundEffect.FromFile("..\\assets\\sounds\\death.wav");
    }
}