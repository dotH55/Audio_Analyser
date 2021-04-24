using Android.Bluetooth;
using Java.IO;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Spectrum.Models
{
    public class BluetoothManager
    {
        private const string Uux = "00001101-0000-1000-8000-00805F9B34FB";
        private BluetoothDevice result;
        private BluetoothSocket mSocket;
        private BufferedReader reader;
        private System.IO.Stream mStream;
        private InputStreamReader mReader;

        public BluetoothManager() 
        {
            result = null;
            
            
        }

        
        private UUID getUux()
        {
            return UUID.FromString(Uux);
        }

        private void close(IDisposable aConnectedObject)
        {
            if (aConnectedObject == null) return;
            try
            {
                aConnectedObject.Dispose();
            }catch (Exception ex)
            {
                Debug.WriteLine("************************************************************");
                Debug.WriteLine("");
                Debug.WriteLine("");
                Debug.WriteLine("**Error: " + ex.GetBaseException());
                Debug.WriteLine("");
                Debug.WriteLine("");
                Debug.WriteLine("");
                Debug.WriteLine("************************************************************");
            }
            aConnectedObject = null;
        }

        public void getAllDevices()
        {
            BluetoothAdapter btAdapter = BluetoothAdapter.DefaultAdapter;
            var devices = btAdapter.BondedDevices;
            if(devices != null && devices.Count > 0)
            {
                foreach(BluetoothDevice mDevice in devices)
                {
                    openDeviceConnection(mDevice);
                    Debug.WriteLine("************************************************************");
                    Debug.WriteLine("");
                    Debug.WriteLine("");
                    Debug.WriteLine(mDevice);
                    Debug.WriteLine("");
                    Debug.WriteLine("");
                    Debug.WriteLine("");
                    Debug.WriteLine("************************************************************");

                }
            }
        }

        public String getDataFromDevice()
        {
            return reader.ReadLine();
        }


        private void openDeviceConnection(BluetoothDevice btDevice)
        {
            try
            {
                mSocket = btDevice.CreateRfcommSocketToServiceRecord(getUux());
                mSocket.Connect();
                mStream = mSocket.InputStream;
                mReader = new InputStreamReader(mStream);
                reader = new BufferedReader(mReader);
            }catch (Exception ex)
            {
                //close(mSocket);
                close(mStream);
                //close(mReader);
                Debug.WriteLine("************************************************************");
                Debug.WriteLine("");
                Debug.WriteLine("");
                Debug.WriteLine("**Error: " + ex.GetBaseException());
                Debug.WriteLine("");
                Debug.WriteLine("");
                Debug.WriteLine("");
                Debug.WriteLine("************************************************************");
            }
        }

    }
}
