using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetSpeech;

namespace CSFramework.Common.Tool
{
    public class VoicePlayer
    {
        private  readonly SpVoice _spVoice = new SpVoice();

        public  VoicePlayer()
        {
            _spVoice.Voice = _spVoice.GetVoices().Item(0);
            _spVoice.Rate = -1;
        }


        public void Speck(string str)
        {
            if (string.IsNullOrEmpty(str)) return;
            _spVoice.Speak(str, SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }

        public void Pause()
        {
            _spVoice.Pause();
        }


        public void Resume()
        {
            _spVoice.Resume();
        }


        public void Stop()
        {
            _spVoice.Speak(string.Empty, SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
        }
    }
}
