using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;


namespace WebAPI
{

    [Binding]
    public class DropBoxMethodsStepDefinitions
    {
        
        private JObject upload_metadata;
        private JObject get_metadata;
        private JObject delete_metadata;        

        [When(@"user uploads the file")]
        public void WhenUserUploadsTheFile()
        {
            var client = new DropboxClient();
            upload_metadata = client.UploadFile(Support.FilePath, Support.DropBoxFilePath);           
        }

        [Then(@"the file is in the Dropbox")]
        public void ThenTheFileIsInTheDropbox()
        {
            JToken nameToken, content_hashToken;
            Assert.IsTrue(upload_metadata.TryGetValue("name", out nameToken));
            Assert.IsTrue(upload_metadata.TryGetValue("content_hash", out content_hashToken));
        }

        [When(@"user tries to get the file metadata")]
        public void WhenUserTriesToGetTheFileMetadata()
        {
            var client = new DropboxClient();
            get_metadata = client.GetFileMetadata(Support.DropBoxFilePath);
            
        }

        [Then(@"user gets metadata")]
        public void ThenUserGetsMetadata()
        {
            JToken sizeToken, modifiedToken;
            Assert.IsTrue(get_metadata.TryGetValue("size", out sizeToken));
            Assert.IsTrue(get_metadata.TryGetValue("name", out modifiedToken));
        }

        [When(@"user tries to delete file from dropbox")]
        public void WhenUserTriesToDeleteFileFromDropbox()
        {
            var client = new DropboxClient();
            delete_metadata = client.DeleteFile(Support.DropBoxFilePath);
        }

        [Then(@"the file is not in the Dropbox")]
        public void ThenTheFileIsNotInTheDropbox()
        {
            JToken sizeToken, modifiedToken, errorToken;
            Assert.IsTrue(delete_metadata.TryGetValue("size", out sizeToken));
            Assert.IsTrue(delete_metadata.TryGetValue("name", out modifiedToken));
            Assert.IsFalse(delete_metadata.TryGetValue("error", out errorToken));
        }
    }
}
