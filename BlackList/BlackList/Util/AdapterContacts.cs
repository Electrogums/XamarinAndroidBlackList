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

        List<string> numeros;     
        private Context context;

        public AdapterContacts(Context context, List<string> numeros)
        {
            this.context = context;
            this.numeros = numeros;
        }

        public override int ItemCount => numeros.Count;

        public override void OnBindViewHolder(V7.RecyclerView.ViewHolder viewHolder, int position)
        {
           
            // Replace the contents of the view with that element
            var item = numeros[position];

           var holder = viewHolder as ContactViewHolder;
               holder.Caption.Text = item;

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
