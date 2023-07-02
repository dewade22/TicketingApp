#nullable disable
namespace TA.Framework.Core.SystemCode
{
    public abstract class SystemStringCodeBase
    {
        #region Fields 

        private List<SystemCodeModel<string>> codeList;

        #endregion

        #region Properties

        protected ICollection<SystemCodeModel<string>> CodeList
        {
            get
            {
                if (this.codeList == null)
                {
                    this.codeList = new List<SystemCodeModel<string>>();
                }

                return this.codeList;
            }
        }

        #endregion

        #region PublicMethods

        public string GetDescription(string code)
        {
            return this.codeList.Single(item => item.Value == code).Description;
        }

        public bool IsExisted(string code)
        {
            return this.codeList.Any(item => item.Value == code);
        }

        public Dictionary<string, string> ToDictionary()
        {
            return this.codeList.ToDictionary(item => item.Value, item => item.Description);
        }

        public SystemCodeModel<string> GetItem(string code)
        {
            return this.codeList.Single(item => item.Value == code);
        }

        #endregion
    }
}
