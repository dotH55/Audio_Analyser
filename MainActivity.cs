using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;
using Android.Support.V4.App;
using System.Timers;
using Spectrum.ViewModels;

namespace Spectrum.Droid
{
    [Activity(Label = "Spectrum", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public const int REQUEST_PERMISSION_CODE = 1000;
        public static bool isGrantedPermission = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            if (CheckSelfPermission(Manifest.Permission.WriteExternalStorage) != Android.Content.PM.Permission.Granted
                && CheckSelfPermission(Manifest.Permission.RecordAudio) != Android.Content.PM.Permission.Granted
                && CheckSelfPermission(Manifest.Permission.ReadExternalStorage) != Android.Content.PM.Permission.Granted
                && CheckSelfPermission(Manifest.Permission.AccessCoarseLocation) != Android.Content.PM.Permission.Granted
                && CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Android.Content.PM.Permission.Granted
                && CheckSelfPermission(Manifest.Permission.Bluetooth) != Android.Content.PM.Permission.Granted
                && CheckSelfPermission(Manifest.Permission.BluetoothAdmin) != Android.Content.PM.Permission.Granted
                && CheckSelfPermission(Manifest.Permission.BluetoothPrivileged) != Android.Content.PM.Permission.Granted
                && CheckSelfPermission(Manifest.Permission.LocationHardware) != Android.Content.PM.Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[]{
                    Manifest.Permission.WriteExternalStorage,
                    Manifest.Permission.RecordAudio,
                    Manifest.Permission.ReadExternalStorage
                }, REQUEST_PERMISSION_CODE);
            }
            else
            {
                isGrantedPermission = true;
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            switch (requestCode)
            {
                case REQUEST_PERMISSION_CODE:
                    {
                        if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                        {
                            Toast.MakeText(this, "Granted", ToastLength.Short).Show();
                            isGrantedPermission = true;
                        }
                        else
                        {
                            Toast.MakeText(this, "Granted", ToastLength.Short).Show();
                            isGrantedPermission = false;
                        }
                        break;
                    }
            }
        }
    }
}