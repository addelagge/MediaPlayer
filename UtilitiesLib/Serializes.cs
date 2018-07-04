//Fredric Lagedal AH2318, 2017-09-19, Assignment 1

namespace MediaPlayerLib
{
    /// <summary>
    /// Klasser som implementerar detta interface måste skriva metoder för serializing/deserializng
    /// </summary>
    public interface Serializes
    {
        void Serialize(string fileName);

        void DeSerialize(string fileName);
    }
}
