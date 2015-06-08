using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Game
{
    class GameSound
    {

        private static SoundPlayer menuSound = new SoundPlayer(@"../../Electrical_Sweep-Sweeper-1760111493.ogg");
        private static SoundPlayer sniperSound = new SoundPlayer(@"../../50_sniper_shot.ogg");


        public static void PlaySniper() 
        {
            sniperSound.Play();
        }

        public static void PlayMenuSound()
        {
            menuSound.PlayLooping();
        }

        public static void StopMenuSound()
        {
            menuSound.Stop();
        }
    }
}
