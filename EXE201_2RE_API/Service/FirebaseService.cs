﻿using EXE201_2RE_API.DTOs;
using EXE201_2RE_API.Repository;
using Firebase.Auth;
using Firebase.Storage;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using static EXE201_2RE_API.Configuration.ConfigurationModel;

namespace EXE201_2RE_API.Service
{
    public interface IFirebaseService
    {
        Task<ActionOutcome> UploadFileToFirebase(IFormFile file, string pathFileName);
        Task<ActionOutcome> UploadFilesToFirebase(List<IFormFile> files, string basePath);
        public Task<string> GetUrlImageFromFirebase(string pathFileName);
        public Task<ActionOutcome> DeleteFileFromFirebase(string pathFileName);
    }

    public class FirebaseService : GenericBackendService, IFirebaseService
    {
        private ActionOutcome _result;
        private FirebaseConfiguration _firebaseConfiguration;
        private readonly IConfiguration _configuration;
        public FirebaseService(IServiceProvider serviceProvider, IConfiguration configuration, FirebaseConfiguration firebaseConfiguration) : base(serviceProvider)
        {
            _result = new();
            _firebaseConfiguration = firebaseConfiguration;
            _configuration = configuration;
        }

        public async Task<ActionOutcome> DeleteFileFromFirebase(string pathFileName)
        {
            var _result = new ActionOutcome();
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig(_firebaseConfiguration.ApiKey));
                var account = await auth.SignInWithEmailAndPasswordAsync(_firebaseConfiguration.AuthEmail, _firebaseConfiguration.AuthPassword);
                var storage = new FirebaseStorage(
             _firebaseConfiguration.Bucket,
             new FirebaseStorageOptions
             {
                 AuthTokenAsyncFactory = () => Task.FromResult(account.FirebaseToken),
                 ThrowOnCancel = true
             });
                await storage
                    .Child(pathFileName)
                    .DeleteAsync();
                _result.message = "XÓA FILE THÀNH CÔNG!";
                _result.isSuccess = true;
            }
            catch (FirebaseStorageException ex)
            {
                _result.message = $"LỖI KHI XÓA FILE: {ex.Message}".ToUpper();
            }
            return _result;
        }

        public async Task<string> GetUrlImageFromFirebase(string pathFileName)
        {
            var a = pathFileName.Split("/o/")[1];
            var api = $"https://firebasestorage.googleapis.com/v0/b/cloudfunction-yt-2b3df.appspot.com/o?name={a}";
            if (string.IsNullOrEmpty(pathFileName))
            {
                return string.Empty;
            }

            var client = new RestClient();
            var request = new RestRequest(api);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jmessage = JObject.Parse(response.Content);
                var downloadToken = jmessage.GetValue("downloadTokens").ToString();
                return
                    $"https://firebasestorage.googleapis.com/v0/b/{_configuration["cloudfunction-yt-2b3df.appspot.com"]}/o/{pathFileName}?alt=media&token={downloadToken}";
            }

            return string.Empty;
        }

        public async Task<ActionOutcome> UploadFileToFirebase(IFormFile file, string pathFileName)
        {
            var _result = new ActionOutcome();
            bool isValid = true;
            if (file == null || file.Length == 0)
            {
                isValid = false;
                _result.message = "FILE ĐANG BỊ TRỐNG!";
            }
            if (isValid)
            {
                var stream = file!.OpenReadStream();
                var auth = new FirebaseAuthProvider(new FirebaseConfig(_firebaseConfiguration.ApiKey));
                var account = await auth.SignInWithEmailAndPasswordAsync(_firebaseConfiguration.AuthEmail, _firebaseConfiguration.AuthPassword);
                string destinationPath = $"{pathFileName}";

                var task = new FirebaseStorage(
                _firebaseConfiguration.Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(account.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child(destinationPath)
                .PutAsync(stream);
                var downloadUrl = await task;

                if (task != null)
                {
                    _result.result = downloadUrl;
                }
                else
                {
                    _result.isSuccess = false;
                    _result.message = "TẢI FILE LÊN LỖI!";
                }
            }
            return _result;
        }
        public async Task<ActionOutcome> UploadFilesToFirebase(List<IFormFile> files, string basePath)
        {
            var _result = new ActionOutcome();
            var uploadResults = new List<string>();

            var auth = new FirebaseAuthProvider(new FirebaseConfig(_firebaseConfiguration.ApiKey));
            var account = await auth.SignInWithEmailAndPasswordAsync(_firebaseConfiguration.AuthEmail, _firebaseConfiguration.AuthPassword);
            var storage = new FirebaseStorage(
                _firebaseConfiguration.Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(account.FirebaseToken),
                    ThrowOnCancel = true
                });

            foreach (var file in files)
            {
                if (file == null || file.Length == 0)
                {
                    _result.message = "MỘT HOẶC NHIỀU FILE BỊ TRỐNG!";
                    continue;
                }

                var stream = file.OpenReadStream();
                string destinationPath = $"{basePath}/{file.FileName}";

                var task = storage.Child(destinationPath).PutAsync(stream);
                var downloadUrl = await task;

                if (task != null)
                {
                    uploadResults.Add(downloadUrl);
                }
                else
                {
                    _result.isSuccess = false;
                    _result.message = $"TẢI FILE LÊN BỊ LỖI : {file.FileName}".ToUpper();
                }
            }

            _result.result = uploadResults;
            if (uploadResults.Count == files.Count)
            {
                _result.isSuccess = true;
                _result.message = "TẢI TOÀN BỘ FILE THÀNH CÔNG!";
            }
            else
            {
                _result.isSuccess = false;
                _result.message = "MỘT SỐ FILE BỊ LỖI KHI TẢI LÊN!";
            }

            return _result;
        }
    }
}
