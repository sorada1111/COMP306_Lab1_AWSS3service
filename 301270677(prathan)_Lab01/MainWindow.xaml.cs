using Amazon.S3;
using Amazon;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _301270677_prathan__Lab01
{
    public partial class MainWindow : Window
    {
        private S3BucketService s3Service = new S3BucketService();
        public ObservableCollection<S3Bucket> bucketCollection = new ObservableCollection<S3Bucket>();

        public MainWindow()
        {
            InitializeComponent();

            // Load the initial list of buckets
            LoadBucketListAsync();
            DataContext = this;
        }
         private void BucketOperationButton_Click(object sender, RoutedEventArgs e)
        {

            BucketWindow bucketWindow = new BucketWindow(bucketCollection);
            this.IsEnabled = false;

            bucketWindow.Closed += (s, args) => { this.IsEnabled = true; };
            bucketWindow.Show();

        }

        private async void LoadBucketListAsync()
        {
            try
            {
                bucketCollection = await s3Service.GetS3BucketListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading bucket list: " + ex.Message);
            }
        }


        private void ObjectOperationButton_Click(object sender, RoutedEventArgs e)
        {
            ObjectWindow objectWindow = new ObjectWindow(bucketCollection);
            this.IsEnabled = false;

            objectWindow.Closed += (s, args) => { this.IsEnabled = true; };

            objectWindow.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
