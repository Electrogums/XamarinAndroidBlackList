using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Views;
using BlackList.Fragments;
using BlackList.Poco;
using V7 = Android.Support.V7.Widget;
namespace BlackList.Util
{
    public class AdapterContacts :V7.RecyclerView.Adapter
    {

        private Context context;
        private List<EntCallLog> lstCallLog;

        public AdapterContacts(Context context, List<EntCallLog> lstCallLog)
        {
            this.context = context;
            this.lstCallLog = lstCallLog;
        }

        public override int ItemCount => lstCallLog.Count;

        public override void OnBindViewHolder(V7.RecyclerView.ViewHolder viewHolder, int position)
        {
           
            // Replace the contents of the view with that element
            var item = lstCallLog[position];
            var holder = viewHolder as ContactViewHolder;
            //holder.nombre.Text = item.nombre;
            //holder.duracion.Text = item.duracion.ToString();
                holder.fecha.Text = item.fecha.ToShortDateString();
            //holder.tipo.Text = item.tipo.ToString();
            if (item.nombre==null)
                holder.numeroNombre.Text= item.numero.ToString();
            else
                holder.numeroNombre.Text = item.nombre;
            switch (item.tipo)
            {
                case Android.Provider.CallType.Incoming:
                    holder.imageUri.SetImageResource(Resource.Drawable.incoming);
                    break;
                case Android.Provider.CallType.Missed:
                    holder.imageUri.SetImageResource(Resource.Drawable.missed);
                    break;

                case Android.Provider.CallType.Outgoing:
                    holder.imageUri.SetImageResource(Resource.Drawable.outgoing);
                    break;
                default:
                    holder.imageUri.SetImageResource(Resource.Drawable.all);
                    break;

            }

        }

        public override V7.RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup and inflate your layout here
            var id = Resource.Layout.CardContact;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            return new ContactViewHolder(itemView);
        }
    }
}
