using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using JetBrains.Annotations;

namespace QuikGraph.Tests
{
    /// <summary>
    /// Test helpers related to serialization.
    /// </summary>
    internal static class SerializationTestHelpers
    {
        [Pure]
        [NotNull]
        public static T SerializeAndDeserialize<T>([NotNull] T @object)
        {
            // Round-trip the exception: Serialize and de-serialize with a BinaryFormatter
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                // "Save" object state
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                bf.Serialize(ms, @object);
#pragma warning restore SYSLIB0011 // Type or member is obsolete

                // Re-use the same stream for de-serialization
                ms.Seek(0, 0);

                // Replace the original exception with de-serialized one
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                return (T)bf.Deserialize(ms);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
        }
    }
}