using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp
{
    #region WinExternal class
    /// <summary>
    /// Simple class to demonstrate WindowExternal functionality
    /// To test, load winexternal.html page and test
    /// Usage:
    /// private WinExternal winext = new WinExternal();
    /// m_CurWB.WindowExternal = winext;
    /// </summary>
    public class WinExternal
    {
        private string m_Msg = "Win external called!";
        public WinExternal()
        {

        }

        public void SaySomething()
        {
            System.Windows.Forms.MessageBox.Show("Nothing to say?");
        }

        public string AMessageFromHome
        {
            get
            {
                return m_Msg;
            }
            set
            {
                System.Windows.Forms.MessageBox.Show("Called from HTML, changing property to\r\n" + value);
            }
        }
    }
    #endregion
}
