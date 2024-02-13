namespace CourseL22
{
    [AttributeUsage(AttributeTargets.All)]
    public class AccessLevelAttribute : Attribute
    {
        readonly int Level;

        public AccessLevelAttribute(int level) => Level = level;

        public int GetAccessLevel => Level;
    }
}
