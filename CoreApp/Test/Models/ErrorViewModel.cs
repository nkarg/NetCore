using System;

namespace Test.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public bool MyProperty { get { return !string.IsNullOrEmpty(RequestId); } }
    }
}