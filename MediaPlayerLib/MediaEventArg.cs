using System;

namespace MediaPlayerLib
{
    /// <summary>
    /// Klass som används för att att skicka info om en mediafil via ett EventHandler anrop. Ärver av EventArgs.
    /// </summary>
    public class MediaEventArg : EventArgs
    {
        public MediaFile MediaFile { get; set; }
    }
}
