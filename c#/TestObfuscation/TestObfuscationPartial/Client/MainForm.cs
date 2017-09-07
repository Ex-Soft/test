using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : Form
    {
        private CustomClass _customClass;

        public MainForm()
        {
            _customClass = new CustomClass("SmthValue1Value", "SmthValue2Value");

            InitializeComponent();

            textBox1.DataBindings.Add(new Binding("Text", _customClass, nameof(CustomClass.SmthValue1), true, DataSourceUpdateMode.OnPropertyChanged));
            textBox2.DataBindings.Add(new Binding("Text", _customClass, "SmthValue2", true, DataSourceUpdateMode.OnPropertyChanged));

            Localize();

            textBox3.Text = Core.Security.Encode(_customClass.SmthValue1);
        }

        private void Localize()
        {
            var customAttributeSmthValue = GetAttributeValue(nameof(CustomClass.SmthValue1));
            File.WriteAllText($"{DateTime.Now.Ticks}_Localize.txt", $"{nameof(Localize)}() customAttributeSmthValue = \"{customAttributeSmthValue}\"");
            label1.Text = ConfigurationManager.AppSettings[customAttributeSmthValue];
            customAttributeSmthValue = GetAttributeValue("SmthValue2");
            File.WriteAllText($"{DateTime.Now.Ticks}_Localize.txt", $"{nameof(Localize)}() customAttributeSmthValue = \"{customAttributeSmthValue}\"");
            label2.Text = ConfigurationManager.AppSettings[customAttributeSmthValue];
        }

        private string GetAttributeValue(string propertyName)
        {
            var type = typeof(CustomClass);

            PropertyInfo pi;
            if ((pi = type.GetProperty(propertyName)) == null)
                return string.Empty;

            CustomAttribute customAttribute;
            return (customAttribute = Attribute.GetCustomAttributes(pi).OfType<CustomAttribute>().FirstOrDefault()) != null ? customAttribute.SmthValue : string.Empty;
        }
    }
}
