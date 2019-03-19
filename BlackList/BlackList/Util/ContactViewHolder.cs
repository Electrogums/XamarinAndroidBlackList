using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BlackList.Poco;

namespace BlackList.Util
{
    public class ContactViewHolder: RecyclerView.ViewHolder
    {
     
        public TextView Caption { get; private set; }


        public ContactViewHolder(View item) : base(item) {
            Caption =  item.FindViewById<TextView>(Resource.Id.numero);
         }

    }
}
