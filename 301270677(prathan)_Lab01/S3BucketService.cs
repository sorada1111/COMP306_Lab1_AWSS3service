using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace _301270677_prathan__Lab01
{
    class S3BucketService
    {
        //Get all the buckets.
        public async Task<ObservableCollection<S3Bucket>> GetS3BucketListAsync()
        {
            try
            {
                ListBucketsResponse response = await Connection.s3Client.ListBucketsAsync();

                // Create a new ObservableCollection and initialize it with the Buckets from the response
                ObservableCollection<S3Bucket> observableBuckets = new ObservableCollection<S3Bucket>(response.Buckets);

                return observableBuckets;
            }
            catch (AmazonS3Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching S3 buckets: {ex.Message}");
                return new ObservableCollection<S3Bucket>();
            }
        }

        //Create bucket
        public async Task CreateBucketAsync(string bucketName)
        {
            try
            {
                await Connection.s3Client.PutBucketAsync(new PutBucketRequest
                {
                    BucketName = bucketName,
                    UseClientRegion = true
                });

                MessageBox.Show($"Bucket '{bucketName}' created successfully.");
            }
            catch (AmazonS3Exception ex)
            {
                MessageBox.Show($"Error creating bucket: {ex.Message}");
            }
        }

        //Delete a bucket
        public async Task EmptyAndDeleteBucketAsync(string bucketName)
        {
            try
            {
                // List objects in the bucket
                ListObjectsV2Response listResponse = await Connection.s3Client.ListObjectsV2Async(new ListObjectsV2Request
                {
                    BucketName = bucketName
                });

                // Check if there are objects in the bucket
                if (listResponse.S3Objects.Count > 0)
                {
                    // Delete objects one by one
                    foreach (var obj in listResponse.S3Objects)
                    {
                        await Connection.s3Client.DeleteObjectAsync(bucketName, obj.Key);
                    }

                    // After deleting all objects, delete the bucket
                    await Connection.s3Client.DeleteBucketAsync(bucketName);
                    MessageBox.Show($"Bucket '{bucketName}' and its objects deleted successfully.");
                }
                else
                {
                    // Bucket is already empty, just delete it
                    await Connection.s3Client.DeleteBucketAsync(bucketName);
                    MessageBox.Show($"Bucket '{bucketName}' deleted successfully.");
                }
            }
            catch (AmazonS3Exception ex)
            {
                MessageBox.Show($"Error deleting bucket: {ex.Message}");
            }
        }


        //Upload file To S3
        public async Task UploadFileToS3(string bucketName, string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(bucketName) || string.IsNullOrWhiteSpace(filePath))
                {
                    throw new ArgumentException("Bucket name and file path must be specified.");
                }

                using (var transferUtility = new TransferUtility(Connection.s3Client))
                {
                    var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                    {
                        BucketName = bucketName,
                        FilePath = filePath,
                        Key = Path.GetFileName(filePath), // Use the file name as the object key
                    };

                    await transferUtility.UploadAsync(fileTransferUtilityRequest);
                }
            }
            catch (AmazonS3Exception ex)
            {
                throw new Exception($"Error uploading file to S3: {ex.Message}", ex);
            }
        }

        // Object list according to the bucket name
        public async Task<ObservableCollection<S3ObjectInfo>> GetS3ObjectsAsync(string bucketName)
        {
            ObservableCollection<S3ObjectInfo> objectsInBucket = new ObservableCollection<S3ObjectInfo>();

            ListObjectsV2Request request = new ListObjectsV2Request
            {
                BucketName = bucketName,
            };

            ListObjectsV2Response response = await Connection.s3Client.ListObjectsV2Async(request);

            foreach (S3Object obj in response.S3Objects)
            {
                objectsInBucket.Add(new S3ObjectInfo { ObjectName = obj.Key, Size = obj.Size });
            }

            return objectsInBucket;
        }


    }
}
