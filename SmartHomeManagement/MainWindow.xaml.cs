using System;
using System.Windows;
using System.Windows.Controls;

namespace SmartHomeManagement
{
    public partial class MainWindow : Window
    {
        private CustomDictionary<string, string> devices;

        public MainWindow()
        {
            InitializeComponent();
            devices = new CustomDictionary<string, string>();
            UpdateDeviceList();
        }

        private void AddDevice_Click(object sender, RoutedEventArgs e)
        {
            string deviceId = DeviceIdTextBox.Text;
            string status = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(deviceId) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please enter a device ID and select a status.");
                return;
            }

            try
            {
                devices.Add(deviceId, status);
                UpdateDeviceList();
                ClearInputs();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("A device with this ID already exists.");
            }
        }

        private void UpdateStatus_Click(object sender, RoutedEventArgs e)
        {
            string deviceId = DeviceIdTextBox.Text;
            string status = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(deviceId) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please enter a device ID and select a status.");
                return;
            }

            try
            {
                devices.Update(deviceId, status);
                UpdateDeviceList();
                ClearInputs();
            }
            catch (KeyNotFoundException)
            {
                MessageBox.Show("Device not found.");
            }
        }

        private void RemoveDevice_Click(object sender, RoutedEventArgs e)
        {
            string deviceId = DeviceIdTextBox.Text;

            if (string.IsNullOrEmpty(deviceId))
            {
                MessageBox.Show("Please enter a device ID.");
                return;
            }

            devices.Remove(deviceId);
            UpdateDeviceList();
            ClearInputs();
        }

        private void UpdateDeviceList()
        {
            DevicesListBox.Items.Clear();
            foreach (var device in devices.GetAllItems())
            {
                DevicesListBox.Items.Add($"{device.Key}: {device.Value}");
            }
        }

        private void ClearInputs()
        {
            DeviceIdTextBox.Clear();
            StatusComboBox.SelectedIndex = -1;
        }
    }
}