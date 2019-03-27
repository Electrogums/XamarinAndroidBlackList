using Android.App;
using Android.Widget;
using Android.OS;
using Android.Telephony;
using Android.Content;
using Android;
using Android.Content.PM;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Support.Design.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using System;
using BlackList.Util;
using System.Collections.Generic;
using BlackList.Poco;
using Java.Lang;

namespace BlackList
{
    [Activity(Label = "BlackList", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {


        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            inicializaUI();
            inicializaPermisos();
            inicializaRegistro();
            navigationView.Menu.GetItem(0).SetChecked(true);
            Fragments.CallLogFragment cl = new Fragments.CallLogFragment();
            var transaction = SupportFragmentManager.BeginTransaction();
            cl.tipoLlamada = Android.Provider.CallType.Incoming;
            transaction.Add(Resource.Id.flContent, cl);
            transaction.Commit();
        }



        private void inicializaRegistro()
        {
            if (CheckSelfPermission(Manifest.Permission.ReadPhoneState) == Permission.Granted &&
                CheckSelfPermission(Manifest.Permission.ReadCallLog) == Permission.Granted)
            {
                Receiver.IncomingCallReceiver incoming = new Receiver.IncomingCallReceiver();
                IntentFilter intent = new IntentFilter();
                intent.AddAction(TelephonyManager.ActionPhoneStateChanged);
                RegisterReceiver(incoming, intent);
            }
            else
                Toast.MakeText(this, "Permiso denegado", ToastLength.Short)
                .Show();

        }


        private void inicializaPermisos()
        {
            int Request = 0;
            if ((int)Build.VERSION.SdkInt >= 23)
            {
                string[] permisos = new string[] {
                          Manifest.Permission.ReadPhoneState,
                          Manifest.Permission.ReadCallLog,
                          };
                if (CheckSelfPermission(Manifest.Permission.ReadPhoneState) != Permission.Granted ||
                   CheckSelfPermission(Manifest.Permission.ReadCallLog) != Permission.Granted)
                    RequestPermissions(permisos, Request);

            }

        }

        private void inicializaUI()
        {
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            if (navigationView != null)
                setupDrawerContent(navigationView);

            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.hello, Resource.String.hello);
            drawerLayout.AddDrawerListener(toggle);
            toggle.SyncState();


        }

        void setupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                Fragments.CallLogFragment cl = new Fragments.CallLogFragment();
                var transaction = SupportFragmentManager.BeginTransaction();
                e.MenuItem.SetChecked(true);
                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.navOutGoing://salientes
                        //setFragment(0);
                        cl.tipoLlamada = Android.Provider.CallType.Outgoing;
                        break;
                    case Resource.Id.navIncoming://entrantes
                        cl.tipoLlamada = Android.Provider.CallType.Incoming;
                        break;
                    case Resource.Id.navAll://todas
                        cl.tipoLlamada = Android.Provider.CallType.AnsweredExternally;
                        break;
                    case Resource.Id.navMissed://perdidas
                        cl.tipoLlamada = Android.Provider.CallType.Missed;
                        break;
                
                }
                transaction.Replace(Resource.Id.flContent, cl);
                //transaction.AddToBackStack("home");
                transaction.Commit();
                drawerLayout.CloseDrawers();
            };
        }

    }
}

