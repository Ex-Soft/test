using System.Collections.Generic;
using System.ComponentModel;

namespace TestBinding
{
    class TestClass : IDataErrorInfo
    {
        string
            fString1,
            fString2;

        public string FString1
        {
            get
            {
                Validate("FString1", fString1);
                return fString1;
            }
            set
            {
                fString1 = value;
                Validate("FString1", fString1);
            }
        }

        public string FString2
        {
            get
            {
                Validate("FString2", fString2);
                return fString2;
            }
            set
            {
                fString2 = value;
                Validate("FString2", fString2);
            }
        }

        Dictionary<string, string> errors = new Dictionary<string, string>();
        string error = string.Empty;

        void Validate(string field, string value)
        {
            switch (field)
            {
                case "FString1":
                    {
                        if (string.IsNullOrWhiteSpace(value))
                            errors["FString1"] = "There is an error";
                        else
                            errors.Remove("FString1");

                        break;
                    }
                case "FString2":
                    {
                        if (string.IsNullOrWhiteSpace(value))
                            errors["FString2"] = "There is an error";
                        else
                            errors.Remove("FString2");

                        break;
                    }
            }
        }

        #region IDataErrorInfo Members

        public string Error
        {
            get
            {
                return errors.Count > 0 ? string.Format("There are {0} errors", errors.Count) : null;
            }
        }

        public string this[string columnName]
        {
            get
            {
                return errors.ContainsKey(columnName) ? errors[columnName] : null;
            }
        }

        #endregion
    }
}
