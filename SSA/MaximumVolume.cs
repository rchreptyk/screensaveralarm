using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAudioApi;

namespace SSA
{
    /// <summary>
    /// This class sets the volume of the system to the maximum volume
    /// as long as it exists. Calling `Revert()` or `Dispose()` will reset
    /// volume back to before.
    /// </summary>
    /// <example>
    /// using(new MaximumVolume())
    /// {
    ///     //Volume is maximum here   
    /// }
    /// </example>
    /// <example>
    /// var volume = new MaximumVolume();
    /// //Volume is maximum here
    /// volume.Revert();
    /// </example>
    class MaximumVolume : IDisposable
    {
        private AudioEndpointVolume volumeControl;
        private float oldVolume;
        private bool wasMuted;

        public MaximumVolume()
        {
            var enumator = new MMDeviceEnumerator();
            var device = enumator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
            volumeControl = device.AudioEndpointVolume;

            maximizeVolume();
        }

        private void maximizeVolume()
        {
            wasMuted = volumeControl.Mute;
            oldVolume = volumeControl.MasterVolumeLevel;

            volumeControl.Mute = false;
            volumeControl.MasterVolumeLevel = volumeControl.VolumeRange.MaxdB;
        }

        public void Revert()
        {
            volumeControl.MasterVolumeLevel = oldVolume;
            volumeControl.Mute = wasMuted;
        }

        public void Dispose()
        {
            Revert();
        }
    }
}
