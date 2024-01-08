using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace _301270677_prathan__Lab01
{
    public partial class BucketWindow : Window
    {
        private S3BucketService s3Service = new S3BucketService();
        public ObservableCollection<S3Bucket> bucketCollection { get; set; }

        public BucketWindow(ObservableCollection<S3Bucket> bucketCollection)
        {
            InitializeComponent();
            this.bucketCollection = bucketCollection; // Initialize the property
            bucketDataGrid.ItemsSource = bucketCollection;
            bucketNameTextBox.TextChanged += bucketNameTextBox_TextChanged;
            bucketDataGrid.SelectionChanged += bucketDataGrid_SelectionChanged;
            DataContext = this;
           
        }

        private async void CreateBucket_Click(object sender, RoutedEventArgs e)
        {
            string bucketName = bucketNameTextBox.Text.Trim();
            if(!string.IsNullOrEmpty(bucketName) ) 
            {
                await s3Service.CreateBucketAsync(bucketName);
                S3Bucket newBucket = new S3Bucket
                {
                    BucketName = bucketName,
                    CreationDate = DateTime.Now
                };

                bucketCollection.Add(newBucket);
                bucketNameTextBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Please enter a valid bucket name.");
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Show the label message when the TextBox gets focus
            textBoxHintLabel.Visibility = Visibility.Visible;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Hide the label message when the TextBox loses focus
            textBoxHintLabel.Visibility = Visibility.Collapsed;
        }

        private async void DeleteBucket_Click(object sender, RoutedEventArgs e)
        {
            S3Bucket selectedBucket = (S3Bucket)bucketDataGrid.SelectedItem;
            if (selectedBucket != null)
            {
                await s3Service.EmptyAndDeleteBucketAsync(selectedBucket.BucketName);
                bucketCollection.Remove(selectedBucket);
            }
            else
            {
                MessageBox.Show("Please select a bucket to delete.");
            }
        }
        private void BackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bucketNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            createBucket_btn.IsEnabled = !string.IsNullOrEmpty(bucketNameTextBox.Text.Trim());

        }

        private void bucketDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            deleteBucket_btn.IsEnabled = bucketDataGrid.SelectedItem != null;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // To unselect the item in the DataGrid
            bucketDataGrid.SelectedItem = null;

            // To disable the Delete Bucket button
            deleteBucket_btn.IsEnabled = false;
        }
    }
}
