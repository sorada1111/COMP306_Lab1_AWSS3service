using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace _301270677_prathan__Lab01
{
    public partial class ObjectWindow : Window
    {
        private S3BucketService s3Service = new S3BucketService();
        public ObservableCollection<S3Bucket> bucketCollection { get; set; }
        public ObservableCollection<S3ObjectInfo> objectCollection { get; set; }

        public ObjectWindow(ObservableCollection<S3Bucket> bucketCollection)
        {
            InitializeComponent();
            this.bucketCollection = bucketCollection;
        }
        private void backToMainWindow_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ObjectWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // put the observablecollection of all the bucke to the combobox
            bucketComboBox.ItemsSource = bucketCollection.Select(bucket => bucket.BucketName).ToList();
            objectPathTextBox.TextChanged += objectPathTextBox_TextChanged;
        }
        private async void Upload_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedBucket = bucketComboBox.SelectedItem as string;
                string filePath = objectPathTextBox.Text;
                string fileName = System.IO.Path.GetFileName(filePath);
                long fileSize = new System.IO.FileInfo(filePath).Length;
                if (string.IsNullOrWhiteSpace(selectedBucket) || string.IsNullOrWhiteSpace(filePath))
                {
                    MessageBox.Show("Please select a bucket and a file to upload.");
                    return;
                }
                // Upload the selected file to the selected bucket
                await s3Service.UploadFileToS3(selectedBucket, filePath);

                S3ObjectInfo uploadedObject = new S3ObjectInfo { ObjectName = fileName, Size = fileSize };
                objectCollection.Add(uploadedObject);
                MessageBox.Show("Upload completed successfully.");
                objectPathTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*"; 

            if (openFileDialog.ShowDialog() == true)
            {
                // User selected a file, update the TextBox with the selected file path
                objectPathTextBox.Text = openFileDialog.FileName;
            }
        }
        private async void BucketComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                string selectedBucket = bucketComboBox.SelectedItem as string;

                if (string.IsNullOrWhiteSpace(selectedBucket))
                {
                    // Handle the case where no bucket is selected, e.g., clear the DataGrid
                    objectDataGrid.ItemsSource = null;
                    return;
                }
                // Fetch objects from the selected bucket
                objectCollection = await s3Service.GetS3ObjectsAsync(selectedBucket);
                objectDataGrid.ItemsSource = objectCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void objectPathTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            upload_btn.IsEnabled = !string.IsNullOrEmpty(objectPathTextBox.Text.Trim());     
        }
    }
}
