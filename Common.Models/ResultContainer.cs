using Common.Helpers;
using Newtonsoft.Json;
using System;

namespace Common.Models
{
    public class ResultContainer
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("snackbarType")]
        public string SnackbarType { get; set; }

        public ResultContainer()
        {
            Success = false;
            SnackbarType = null;
        }

        public void SetResult(string message)
        {
            Success = true;
            Message = message;
            SnackbarType = EnumHelper.GetDescription(SnackbarTypes.Success);
        }

        public void SetResult(InfoMessages message)
        {
            Success = true;
            Message = EnumHelper.GetDescription(message);
            SnackbarType = EnumHelper.GetDescription(SnackbarTypes.Success);
        }

        public void SetResult(string message, SnackbarTypes snackbarType)
        {
            Success = true;
            Message = message;
            SnackbarType = EnumHelper.GetDescription(snackbarType);
        }

        public void SetResult(InfoMessages message, SnackbarTypes snackbarType)
        {
            Success = true;
            Message = EnumHelper.GetDescription(message);
            SnackbarType = EnumHelper.GetDescription(snackbarType);
        }

        public void SetError(Errors error, SnackbarTypes snackbarType)
        {
            Success = false;
            Message = EnumHelper.GetDescription(error);
            SnackbarType = EnumHelper.GetDescription(snackbarType);
        }

        public void SetError(string message, SnackbarTypes snackbarType)
        {
            Success = false;
            Message = message;
            SnackbarType = EnumHelper.GetDescription(snackbarType);
        }

        public void SetError(Exception exception)
        {
            Success = false;
            Message = exception.Message;
            SnackbarType = EnumHelper.GetDescription(SnackbarTypes.Error);
        }

        public void SetError(Exception exception, SnackbarTypes snackbarType)
        {
            Success = false;
            Message = exception.Message;
            SnackbarType = EnumHelper.GetDescription(snackbarType);
        }
    }

    public sealed class ResultContainer<TObject> : ResultContainer
    {
        [JsonProperty("content")]
        public TObject Content { get; set; }

        public void SetResult(string message, TObject content)
        {
            Success = true;
            Message = message;
            SnackbarType = EnumHelper.GetDescription(SnackbarTypes.Success);
            Content = content;
        }

        public void SetResult(InfoMessages message, TObject content)
        {
            Success = true;
            Message = EnumHelper.GetDescription(message);
            SnackbarType = EnumHelper.GetDescription(SnackbarTypes.Success);
            Content = content;
        }

        public void SetResult(InfoMessages message, SnackbarTypes snackbarType, TObject content)
        {
            Success = true;
            Message = EnumHelper.GetDescription(message);
            SnackbarType = EnumHelper.GetDescription(snackbarType);
            Content = content;
        }

        public void SetResult(string message, SnackbarTypes snackbarType, TObject content)
        {
            Success = true;
            Message = message;
            SnackbarType = EnumHelper.GetDescription(snackbarType);
            Content = content;
        }
    }
}
