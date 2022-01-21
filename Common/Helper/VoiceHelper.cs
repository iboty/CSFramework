using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetSpeech;

namespace CSFramework.Common.Helper
{
    public   class VoiceHelper
    {
        public static void Speak(string text)
        {

            try
            {
                var flags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
                var sp = new SpVoice();
                sp.Voice = sp.GetVoices("name=Microsoft LiLi", "").Item(0);
                sp.Rate = -1;
                sp.Speak(text, flags);
            }
            catch
            {
                //In
            }
           
        }
    }
}
