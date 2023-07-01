using System;
using Newtonsoft.Json;

namespace ImageStreaming.Shared.Persistence.Common.Extensions
{
    public static class JsonExtensions
    {
        /// <summary>
        /// Serializes the specified object to a JSON string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeObject<T>(this T value)
        {
            string result = string.Empty;
            if (value != null)
            {
                try
                {
                    result = JsonConvert.SerializeObject(value);
                }
                catch
                {
                    result = string.Empty;
                }
            }

            return result;
        }

        /// <summary>
        /// Deserializes the JSON to the specified .NET type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string value)
        {
            T result;
            if (string.IsNullOrEmpty(value))
            {
                result = default;
            }
            else
            {
                try
                {
                    result = JsonConvert.DeserializeObject<T>(value);
                }
                catch
                {
                    result = default;
                }
            }

            return result;
        }
    }
}

