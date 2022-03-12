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

    public static class ResponseExtension
    {
        public static Response<T> ToType<T>(this Response<object> response)
        {
            return new Response<T>()
            {
                id = response.id,
                data = (T)response.data,
                error = response.error,
            };
        }
    }
}