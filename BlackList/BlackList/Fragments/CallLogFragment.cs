
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using BlackList.Poco;
using BlackList.Util;

namespace BlackList.Fragments
{
    public class CallLogFragment : Android.Support.V4.App.Fragment
    {
      
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        RecyclerView recyclerView;
        RecyclerView.LayoutManager layoutManager;
        AdapterContacts adapter;
        List<string> lstnumeros = new List<string>();       
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            CallLog cl = new CallLog();
            List<EntCallLog> lstCallLog=cl.getCallLog(String.Empty,String.Empty);
            foreach (EntCallLog item in lstCallLog)
            {
                lstnumeros.Add(item.numero);
            }

            View vw = inflater.Inflate(Resource.Layout.FragmentCallLog, container, false);
            adapter = new AdapterContacts(vw.Context, lstnumeros);
            recyclerView = vw.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.SetAdapter(adapter);
            layoutManager = new LinearLayoutManager(vw.Context, LinearLayoutManager.Vertical, false);
            recyclerView.SetLayoutManager(layoutManager);
            return vw;
            //return inflater.Inflate(Resource.Layout.FragmentCallLog, container, false);
        }
    }
}
