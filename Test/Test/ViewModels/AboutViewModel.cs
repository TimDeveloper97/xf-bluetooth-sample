using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Test.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Test.ViewModels
{
    //[DesignTimeVisible(false)]
    public class AboutViewModel : BaseViewModel
    {
        IBluetoothLE _ble;
        IAdapter _adapter;
        IDevice _device;

        public IFileStorage FileStorage => DependencyService.Get<IFileStorage>();
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Test());
        }

        public ICommand OpenWebCommand { get; }

        private async Task Test()
        {
            string fileName = @"abc/test";
            //var local = PCLStorage.FileSystem.Current.LocalStorage;
            //if(!await FileStorage.IsFileExistAsync(fileName))
            //{
            //    await FileStorage.CreateFolder("abc");
            //    await FileStorage.CreateFile(fileName);
            //    await FileStorage.WriteTextAllAsync(fileName, "XIn chao lan 1");
            //}    

            //var result = await FileStorage.ReadAllTextAsync(fileName);
            //Title = result;

            _ble = CrossBluetoothLE.Current;
            _adapter = CrossBluetoothLE.Current.Adapter;
            _adapter.DeviceDiscovered += (s, a) =>
            {
                // Found a device
                Console.WriteLine($"Device found: {a.Device.Name}");
                if (a.Device.Name == "STM32_Device_Name") // Replace with the actual name of your STM32 device
                {
                    _device = a.Device;
                    ConnectToDevice(_device);
                }
            };
        }

        public async Task ScanForDevices()
        {
            if (!_ble.IsOn)
            {
                Console.WriteLine("Bluetooth is off");
                return;
            }

            await _adapter.StartScanningForDevicesAsync();
        }

        private async Task ConnectToDevice(IDevice device)
        {
            try
            {
                await _adapter.ConnectToDeviceAsync(device);
                Console.WriteLine($"Connected to {device.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect: {ex.Message}");
            }
        }
    }
}