using System;
using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using log = Android.Provider.CallLog;
using Java.IO;
using Java.Lang;
using BlackList.Poco;
using System.Collections.Generic;

namespace BlackList.Util
{
    public class CallLog
    {

        public List<EntCallLog> getCallLog(string queryFilter,string querySorter)
        {

            //string queryFilter = System.String.Format("{0}={1}", log.Calls.Date, dt.Ticks);
            // string querySorter = System.String.Format("{0} desc limit 100 ", log.Calls.Date);
            Android.Database.ICursor queryData = Application.Context.ContentResolver.Query(log.Calls.ContentUri, null, queryFilter, null, querySorter);
            List<EntCallLog> lstRecentCalls = new List<EntCallLog>();

            while (queryData.MoveToNext())
            {
                EntCallLog ent = new EntCallLog();
                ent.numero = queryData.GetString(queryData.GetColumnIndex(log.Calls.Number));
                ent.tipo = (Android.Provider.CallType)queryData.GetInt(queryData.GetColumnIndex(log.Calls.Type));
                ent.nombre= queryData.GetString(queryData.GetColumnIndex(log.Calls.CachedName));
                ent.duracion= queryData.GetInt(queryData.GetColumnIndex(log.Calls.Duration));
                ent.fecha= DateTime.Parse(new Java.Sql.Date(queryData.GetLong(queryData.GetColumnIndex(log.Calls.Date))).ToString());
                ent.imageUri= queryData.GetString(queryData.GetColumnIndex(log.Calls.CachedPhotoUri));
                lstRecentCalls.Add(ent);
            }
            return lstRecentCalls;
        }

       
    }
}
