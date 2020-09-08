using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using System;
using System.Configuration;
using System.IO;

namespace LRCA.classes
{
    public static class AwsProfile
    {
        private static IAmazonS3 instance;
        public static IAmazonS3 SoleInstance
        {
            get
            {
                if (instance == null)
                {
                    var chain = new CredentialProfileStoreChain(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "credentials"));
                    AWSCredentials awsCredentials;
                    if (chain.TryGetAWSCredentials("basic_profile", out awsCredentials))
                    {
                        instance = new AmazonS3Client(awsCredentials, Amazon.RegionEndpoint.USEast1);
                        
                    }
                }

                AmazonS3Config config = new AmazonS3Config();
                config.ServiceURL = "testsourcespoon.s3.amazonaws.com";
                config.RegionEndpoint = Amazon.RegionEndpoint.USEast1;

                AmazonS3Client s3Client = new AmazonS3Client(
                        "AKIAT7GDR5AFSJIPM3F7",
                        "uzFr84vIezA9mxs9H3hZf5UR0kkkjN0UUbn2gfOW",
                        config
                        );
                instance = s3Client;

                return instance;
            }
        }
    }
}