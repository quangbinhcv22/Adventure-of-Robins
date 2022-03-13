using System;

namespace Network.Messages
{
    [Serializable]
    public class Request
    {
        public string id;
        public object data;
    }
}