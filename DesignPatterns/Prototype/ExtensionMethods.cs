using System.Text.Json;

namespace DesignPatterns.Prototype
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            string serializedObj = JsonSerializer.Serialize<T>(self);

            if (serializedObj == "{}")
                throw new Exception("Make sure the class is serializable");
            T originalObj;
            try
            {
                originalObj = JsonSerializer.Deserialize<T>(serializedObj)!;
            }
            catch (NotSupportedException)
            {
                throw new Exception("Make sure the class is deserializable");
            }

            return originalObj;
        }
    }
}
