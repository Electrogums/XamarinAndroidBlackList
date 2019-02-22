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
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.abc_ic_star_black_36dp);
            SupportActionBar.SetHomeButtonEnabled(true);

            // Get our button from the layout resource,
            // and attach an event to it
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            if (navigationView != null)
                setupDrawerContent(navigationView);

            int Request = 0;
            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (CheckSelfPermission(Manifest.Permission.ReadPhoneState) != Permission.Granted)
                       RequestPermissions((new string[] {
                          Manifest.Permission.ReadPhoneState 
                          }),Request);
            }
            if (CheckSelfPermission(Manifest.Permission.ReadPhoneState) == Permission.Granted)
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
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }
        void setupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) => {
                e.MenuItem.SetChecked(true);
                drawerLayout.CloseDrawers();
            };
        }


    }

}

