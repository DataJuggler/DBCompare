

#region Using Statements

using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

#endregion

namespace DBCompare
{

    #region class SerializationManager
    /// <summary>
    /// This class handles serialization / deserialization and
    /// compares two objects to test if they have changed.
    /// </summary>
    internal class SerializationManager
    {

        #region HasObjectChanged(byte[] serializedObject, object currentObject)
        /// <summary>
        /// This method compares two objects and returns true 
        /// if the two objects are different.
        /// </summary>
        /// <param name="serializedObject">The serialized object to compare</param>
        /// <param name="currentObject">The current objec to serialize before comparing.</param>
        /// <returns></returns>
        public static bool HasObjectChanged(byte[] cachedArray, object currentObject)
        {
            // initial value
            bool changes = false;
            
            // serialize the currentObject
            byte[] currentArray = SerializeObject(currentObject);
            
            // verify both objects exist
            if ((cachedArray != null) && (currentArray != null))
            {
                // now check the length
                if(currentArray.Length != cachedArray.Length)
                {
                    // the object has changed
                    changes = true;
                }
                else
                {
                    // ok the lengths are the same, now check
                    // if the values for each byte are the same
                    for(int x = 0; x < currentArray.Length; x++)
                    {
                        // now get both bytes
                        byte cachedByte = cachedArray[x];
                        byte currentByte = currentArray[x];
                        
                        // if this bytes do not match
                        if(cachedByte != currentByte)
                        {
                            // this object has changes
                            changes = true;
                        }
                    }
                }
            }
            
            // return value
            return changes;
        }
        #endregion

        #region DeserializeObject(byte[] serializedObject)
        /// <summary>
        /// This method serializes an object to a byte array.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static object DeserializeObject(byte[] serializedObject)
        {
            // initial value
            object obj = null;
            
            // you can not deserialize a null object.
            if(serializedObject != null)
            {
                // Create a memory stream
                MemoryStream ms = new MemoryStream(serializedObject);
                
                // Create a binary formatter
                BinaryFormatter bf1 = new BinaryFormatter();
                
                // set the position to start at the beginning
                ms.Position = 0;

                // deserialize the object now.
                obj = bf1.Deserialize(ms);
            }
            
            // return value
            return obj;
        }
        #endregion

        #region SerializeObject(object objectToSerialize)
        /// <summary>
        /// This method serializes an object to a byte array.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static byte[] SerializeObject(object objectToSerialize)
        {
            // initila value
            byte[] serializedObject = null;
            
            try
            {
                // if the object exists
                if(objectToSerialize != null)
                {
                    // Create memory stream
                    MemoryStream ms = new MemoryStream();

                    // create binary formatter
                    BinaryFormatter bf1 = new BinaryFormatter();

                    // serialize the object
                    bf1.Serialize(ms, objectToSerialize);

                    // return this memory stream ToArray() 
                    serializedObject = ms.ToArray();
                }
            }
            catch (Exception error)
            {
                // Show user error
                throw(error);
            }
            
            // return value
            return serializedObject;
        }
        #endregion

    }
    #endregion
    
}
