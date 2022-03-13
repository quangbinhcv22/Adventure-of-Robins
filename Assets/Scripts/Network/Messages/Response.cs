using System;

namespace Network.Messages
{
    [Serializable]
    public class Response<T>
    {
        public string id;
        public T data;
        public string error;
    }
}