
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
using log = Android.Provider.CallLog;
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
        public Android.Provider.CallType tipoLlamada { get; set; }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            CallLog cl = new CallLog();
            string querySorter = System.String.Format("{0} desc ", log.Calls.Date);
            //string queryWhere = System.String.Format("{0} CallType LIKE ?  ", tipoLlamada);
            string queryWhere = " type =  " +(int)tipoLlamada;

            List<EntCallLog> lstCallLog = cl.getCallLog((tipoLlamada==Android.Provider.CallType.AnsweredExternally?null:queryWhere), querySorter);
       
            View vw = inflater.Inflate(Resource.Layout.FragmentCallLog, container, false);
            adapter = new AdapterContacts(vw.Context, lstCallLog);
            recyclerView = vw.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.SetAdapter(adapter);
            layoutManager = new LinearLayoutManager(vw.Context, LinearLayoutManager.Vertical, false);
            recyclerView.SetLayoutManager(layoutManager);
            return vw;
            //return inflater.Inflate(Resource.Layout.FragmentCallLog, container, false);
        }
    }
}
