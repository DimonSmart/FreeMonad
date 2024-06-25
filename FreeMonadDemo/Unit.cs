namespace FreeMonadDemo
{

    /// <summary>
    /// Represents a unit type, used to signify the absence of a specific value.
    /// </summary>
    public class Unit
    {
        public static readonly Unit Value = new Unit();

        private Unit() { }

        public override string ToString() => "Unit";
    }
}