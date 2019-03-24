using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BlackList.Poco;

namespace BlackList.Util
{
    public class ContactViewHolder : RecyclerView.ViewHolder
    {
        public ImageView imageUri { get;  set; }
        public TextView numeroNombre { get;  set; }
        public TextView duracion { get;  set; }
        public TextView tipo { get;  set; }
        public TextView nombre { get;  set; }
        public TextView fecha { get;  set; }

        public ContactViewHolder(View item) : base(item)
        {

            imageUri = item.FindViewById<ImageView>(Resource.Id.imageUri);
            numeroNombre = item.FindViewById<TextView>(Resource.Id.numero);
            //duracion = item.FindViewById<TextView>(Resource.Id.duracion);
            //tipo = item.FindViewById<TextView>(Resource.Id.tipo);
            //nombre = item.FindViewById<TextView>(Resource.Id.nombre);
            fecha = item.FindViewById<TextView>(Resource.Id.fecha);

        }

    }
}
