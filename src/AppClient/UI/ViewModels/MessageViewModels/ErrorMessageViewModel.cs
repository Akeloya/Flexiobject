using FlexiObject.AppClient.Core;

using System;
using System.Collections.Generic;

namespace FlexiObject.AppClient.UI.ViewModels.MessageViewModels
{
    public class ErrorMessageViewModel : Screen
    {
        public ErrorMessageViewModel(string message, Exception exception = null)
        {
            Message = message ?? exception?.Message;
            if (exception != null)
                Exception = new ExceptionInfo(exception);
        }

        public ErrorMessageViewModel(Exception exception)
        {
            Message = exception.Message;
            if (exception != null)
                Exception = new ExceptionInfo(exception);
        }

        public static ErrorMessageViewModel Design => new(new Exception("test"));
        public string Message { get; set; }
        public ExceptionInfo Exception { get; private set; }

        public bool ShowInfo { get; set; }

        public void ShowDetailes()
        {
            ShowInfo = !ShowInfo;
        }
        public class ExceptionInfo
        {
            private readonly Exception _exception;
            public ExceptionInfo(Exception exception)
            {
                _exception = exception;
                StackFrames = exception.StackTrace?.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();
            }

            public IReadOnlyCollection<string> StackFrames { get; set; }

            public ExceptionInfo InnerException => _exception.InnerException != null ? new ExceptionInfo(_exception.InnerException) : null;
        }
    }
}
