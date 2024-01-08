using Amazon.S3;
using Microsoft.Extensions.Configuration;
using Amazon;
using Amazon.Runtime;
using System.IO;

namespace _301270677_prathan__Lab01
{
    public static class Connection
    {
        public readonly static IAmazonS3 s3Client;

        static Connection()
        {
            s3Client = GetS3Client();
        }
        private static IAmazonS3 GetS3Client()
        {
            return new AmazonS3Client(GetBasicAWSCredentials(), RegionEndpoint.CACentral1);
        }

        private static BasicAWSCredentials GetBasicAWSCredentials()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            string awsAccessKey = builder.Build().GetSection("AWS").GetSection("AccessKeyId").Value;
            string awsSecretKey = builder.Build().GetSection("AWS").GetSection("SecretAccessKey").Value;

            return new BasicAWSCredentials(awsAccessKey, awsSecretKey);
        }
    }
}
