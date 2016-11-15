using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using InspectorWrapperExplained;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace TestOutlookAddIn3
{
    public partial class ThisAddIn
    {
        ///
        /// Holds a reference to the Application.Inspectors collection
        /// Required to get notifications for NewInspector events.
        ///
        private Outlook.Inspectors _inspectors;

        ///
        /// A dictionary that holds a reference to the Inspectors handled by the add-in
        ///
        private Dictionary<Guid, InspectorWrapper> _wrappedInspectors;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            _wrappedInspectors = new Dictionary<Guid, InspectorWrapper>();
            _inspectors = Globals.ThisAddIn.Application.Inspectors;
            _inspectors.NewInspector += new Outlook.InspectorsEvents_NewInspectorEventHandler(WrapInspector);

            // Handle also already existing Inspectors
            // (e.g. Double clicking a .msg file)
            foreach (Outlook.Inspector inspector in _inspectors)
            {
                WrapInspector(inspector);
            }
        }

        ///
        /// Wraps an Inspector if required and remember it in memory to get events of the wrapped Inspector
        ///
        /// The Outlook Inspector instance
        void WrapInspector(Outlook.Inspector inspector)
        {
            InspectorWrapper wrapper = InspectorWrapper.GetWrapperFor(inspector);
            if (wrapper != null)
            {
                // register for the closed event
                wrapper.Closed += new InspectorWrapperClosedEventHandler(wrapper_Closed);
                // remember the inspector in memory
                _wrappedInspectors[wrapper.Id] = wrapper;
            }
        }

        ///
        /// Method is called when an inspector has been closed
        /// Removes reference from memory
        ///
        /// The unique id of the closed inspector
        void wrapper_Closed(Guid id)
        {
            _wrappedInspectors.Remove(id);
        } 
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // do the homework and cleanup
            _wrappedInspectors.Clear();
            _inspectors.NewInspector -= new Outlook.InspectorsEvents_NewInspectorEventHandler(WrapInspector);
            _inspectors = null;
            GC.Collect();
            GC.WaitForPendingFinalizers(); 
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
