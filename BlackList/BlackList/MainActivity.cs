using Android.App;
using Android.Widget;
using Android.OS;
using Android.Telephony;
using Android.Content;
using Android;
using Android.Content.PM;

namespace BlackList
{
    [Activity(Label = "BlackList", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
      
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
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


    }

}

