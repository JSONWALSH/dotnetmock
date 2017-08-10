        public string SaveToBlob<T>(ref IEnumerable<T> ItemsToSave, string PathToItem)
        {
            StorageCredentials Credentials = new StorageCredentials(ConfigurationManager.AppSettings["AzureStorageAccount"], ConfigurationManager.AppSettings["AzureStorageKey"]);
            CloudStorageAccount Storage = new CloudStorageAccount(Credentials, false);
            CloudBlobClient BlobClient = Storage.CreateCloudBlobClient();
            CloudBlobContainer Container = BlobClient.GetContainerReference("images");
            CloudBlockBlob blob = Container.GetBlockBlobReference(Path.GetFileName(PathToItem));
            using (MemoryStream ms = new MemoryStream())
            {
                if (typeof(Bitmap) == typeof(T))
                {
                    AzureBlobService azure = new AzureBlobService();
                     azure.saveBlobAsync("id", "serviceOptions", "serviceOptions");
                    foreach (var item in ItemsToSave.ToList())
                    {
                        ((Bitmap)item).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }

                ImageToSave.First().Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Position = 0;
                blob.UploadFromStream(ms);
             
                return blob.StorageUri.PrimaryUri.ToString();
            }
        }
        
        public void ProcessAccount(string accountNumber)
        {
            foreach (var accountTask in GetTasksForAccountWithSubAccounts(accountNumber))
            {
                var account = accountTask.Result;
                process();
            }
        }

        public IEnumerable<Task<Airport>> GetTasksForAccountWithSubAccounts(string accountNumber)
        {
            var parentAccountTask = Sync("parent", 1);   //_repository.Get();
            yield return parentAccountTask;

            var parentAccount = parentAccountTask.Result;
            foreach (var childAccountNumber in parentAccount.Name)
            {
                var childAccountTask = Sync("child", 2);
                yield return childAccountTask;
            }
        }
