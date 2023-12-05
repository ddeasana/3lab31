using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace demo
{
    [Serializable]
    public class Rectangle : IComparable<Rectangle>, ISerializable
    {
        public string FillColour { get; set; }
        public string OutlineColour { get; set; }
        public float Side1length { get; set; }
        public float Side2length { get; set; }
        public Rectangle() { }
        
        [JsonConstructor]
        public Rectangle(string fillColour, string outlineColour, float side1length, float side2length)
        {
            FillColour = fillColour;
            OutlineColour = outlineColour;
            Side1length = side1length;
            Side2length = side2length;
        }
        protected Rectangle(SerializationInfo info, StreamingContext context)
        {
            FillColour = info.GetString("FillColour");
            OutlineColour = info.GetString("OutlineColour");
            //Side1length = info.GetInt32("Side1length");
            //Side2length = info.GetInt32("Side2length");
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FillColour", FillColour);
            info.AddValue("OutlineColour", OutlineColour);
            //info.AddValue("Side1length", Side1length);
            //info.AddValue("Side2length", Side2length);
        }
        public float Square() { return Side1length * Side2length; }
        public float Perimeter() { return Side1length * 2 + Side2length * 2; }
        public int CompareTo(Rectangle? other)
        {
            return this.Square().CompareTo(other?.Square());
        }
        public override string ToString() =>
            "Fill colour: " + FillColour +
            ", Outline colour: " + OutlineColour +
            ", First length: " + Side1length +
            ", Second length: " + Side2length;

    }
}
