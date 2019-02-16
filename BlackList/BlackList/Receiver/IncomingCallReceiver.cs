using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Telephony;
using Android.Widget;

namespace BlackList.Receiver
{
    [BroadcastReceiver]
    [IntentFilter(new[] { TelephonyManager.ActionPhoneStateChanged })]
    public class IncomingCallReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            try
            {
                string state = intent.GetStringExtra(TelephonyManager.ExtraState);
                string number = intent.GetStringExtra(TelephonyManager.ExtraIncomingNumber);

                if (state.ToUpper()==TelephonyManager.ExtraStateRinging.ToUpper())
                {
                    if (number=="125215215")
                    {
                      Toast.MakeText(context, number + "Is Blocked", ToastLength.Long).Show();
                      TelephonyManager manager = (TelephonyManager)context.GetSystemService(Context.TelephonyService);
                      IntPtr iTelephonyPtr = JNIEnv.GetMethodID(manager.Class.Handle, "getITelephony", "()Lcom/android/internal/telephony/ITelephony;");
                      IntPtr telephony = JNIEnv.CallObjectMethod(manager.Handle, iTelephonyPtr);
                      IntPtr iTelephonyClass = JNIEnv.GetObjectClass(telephony);
                      IntPtr iTelephonyEndCall = JNIEnv.GetMethodID(iTelephonyClass, "endCall", "()Z");
                      JNIEnv.CallBooleanMethod(telephony, iTelephonyEndCall);
                      JNIEnv.DeleteLocalRef(telephony);
                      JNIEnv.DeleteLocalRef(iTelephonyClass);
                    }

                }

            }
            catch (Exception ex)
            {
                Toast.MakeText(context,ex.Message, ToastLength.Long).Show();
            }
        }
    }
}
