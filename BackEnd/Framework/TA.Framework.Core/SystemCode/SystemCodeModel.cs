namespace TA.Framework.Core.SystemCode
{
    public class SystemCodeModel<T>
    {
        #region Constructor

        public SystemCodeModel(
            T value,
            string description,
            string group = "",
            byte type = 0)
        {
            this.Value = value;
            this.Description = description;
            this.Group = group;
            this.Type = type;
        }

        #endregion

        #region Properties

        public T Value { get; private set; }

        public string Description { get; private set; }

        public string Group { get; private set; }

        public byte Type { get; private set; }

        #endregion
    }
}
