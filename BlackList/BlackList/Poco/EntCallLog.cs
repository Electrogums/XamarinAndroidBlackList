using System;
using Android.Util;

namespace BlackList.Poco
{
    public class EntCallLog
    {
        public string numero { get; set; }
        public DateTime fecha { get; set; }
        public int duracion { get; set; }
        public Android.Provider.CallType tipo { get; set; }
        public string nombre { get; set; }
        public string imageUri { get; set; }

    }
}
