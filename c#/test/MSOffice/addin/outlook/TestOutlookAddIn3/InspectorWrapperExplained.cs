//http://www.x4u.de/Home/tabid/36/EntryId/44/Outlook-Inspector-Wrapper-explained.aspx
using System.Reflection;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System;


namespace InspectorWrapperExplained
{
    ///
    /// Eventhandler used to correctly clean up resources
    ///
    /// The unique id of the Inspector instance
    internal delegate void InspectorWrapperClosedEventHandler(Guid id);

    ///
    /// The base class for all InspectorWrappers
    ///
    internal abstract class InspectorWrapper
    {
        ///
        /// Event notifier for the InspectorWrapper.Closed event.
        /// Is raised when an Inspector has been closed.
        ///
        public event InspectorWrapperClosedEventHandler Closed;

        ///
        /// The unique Id the identifies the Inspector Window
        ///
        public Guid Id { get; private set; }

        ///
        /// The Outlook Inspector Instance
        ///
        public Outlook.Inspector Inspector { get; private set; }

        ///
        /// .ctor
        ///
        /// The Outlook Inspector instance that should be handled
        public InspectorWrapper(Outlook.Inspector inspector)
        {
            Id = Guid.NewGuid();
            Inspector = inspector;

            // register for Inspector events here
            ((Outlook.InspectorEvents_10_Event)Inspector).Close += new Outlook.InspectorEvents_10_CloseEventHandler(Inspector_Close);
            ((Outlook.InspectorEvents_10_Event)Inspector).Activate += new Outlook.InspectorEvents_10_ActivateEventHandler(Activate);
            ((Outlook.InspectorEvents_10_Event)Inspector).Deactivate += new Outlook.InspectorEvents_10_DeactivateEventHandler(Deactivate);
            ((Outlook.InspectorEvents_10_Event)Inspector).BeforeMaximize += new Outlook.InspectorEvents_10_BeforeMaximizeEventHandler(BeforeMaximize);
            ((Outlook.InspectorEvents_10_Event)Inspector).BeforeMinimize += new Outlook.InspectorEvents_10_BeforeMinimizeEventHandler(BeforeMinimize);
            ((Outlook.InspectorEvents_10_Event)Inspector).BeforeMove += new Outlook.InspectorEvents_10_BeforeMoveEventHandler(BeforeMove);
            ((Outlook.InspectorEvents_10_Event)Inspector).BeforeSize += new Outlook.InspectorEvents_10_BeforeSizeEventHandler(BeforeSize);
            ((Outlook.InspectorEvents_10_Event)Inspector).PageChange += new Outlook.InspectorEvents_10_PageChangeEventHandler(PageChange);

            // Initialize is called to give the derived Wrappers a chance to do initialization
            Initialize();
        }

        ///
        /// Eventhandler for the Inspector close event
        ///
        private void Inspector_Close()
        {
            // call the Close Method - the derived classes can implement cleanup code
            // by overriding the Close method
            Close();

            // unregister Inspector events
            ((Outlook.InspectorEvents_10_Event)Inspector).Close -= new Outlook.InspectorEvents_10_CloseEventHandler(Inspector_Close);
            ((Outlook.InspectorEvents_10_Event)Inspector).Activate -= new Outlook.InspectorEvents_10_ActivateEventHandler(Activate);
            ((Outlook.InspectorEvents_10_Event)Inspector).Deactivate -= new Outlook.InspectorEvents_10_DeactivateEventHandler(Deactivate);
            ((Outlook.InspectorEvents_10_Event)Inspector).BeforeMaximize -= new Outlook.InspectorEvents_10_BeforeMaximizeEventHandler(BeforeMaximize);
            ((Outlook.InspectorEvents_10_Event)Inspector).BeforeMinimize -= new Outlook.InspectorEvents_10_BeforeMinimizeEventHandler(BeforeMinimize);
            ((Outlook.InspectorEvents_10_Event)Inspector).BeforeMove -= new Outlook.InspectorEvents_10_BeforeMoveEventHandler(BeforeMove);
            ((Outlook.InspectorEvents_10_Event)Inspector).BeforeSize -= new Outlook.InspectorEvents_10_BeforeSizeEventHandler(BeforeSize);
            ((Outlook.InspectorEvents_10_Event)Inspector).PageChange -= new Outlook.InspectorEvents_10_PageChangeEventHandler(PageChange);

            // clean up resources and do a GC.Collect();
            Inspector = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            // raise the Close event.
            if (Closed != null) Closed(Id);
        }

        protected virtual void Initialize() { }

        ///
        /// Method gets called when another Page of the Inspector has been selected
        ///
        /// The active page name by reference
        protected virtual void PageChange(ref string ActivePageName) { }

        ///
        /// Method gets called before the Inspetor is resized
        ///
        /// To prevent resizing set Cancel to true
        protected virtual void BeforeSize(ref bool Cancel) { }

        ///
        /// Method gets called before the Inspetor is moved around
        ///
        /// To prevent moving set Cancel to true
        protected virtual void BeforeMove(ref bool Cancel) { }

        ///
        /// Method gets called before the Inspetor is minimized
        ///
        /// To prevent minimizing set Cancel to true
        protected virtual void BeforeMinimize(ref bool Cancel) { }

        ///
        /// Method gets called before the Inspetor is maximized
        ///
        /// To prevent maximizing set Cancel to true
        protected virtual void BeforeMaximize(ref bool Cancel) { }

        ///
        /// Method gets called when the Inspector is deactivated
        ///
        protected virtual void Deactivate() { }

        ///
        /// Method gets called when the Inspector is activated
        ///
        protected virtual void Activate() { }

        ///
        /// Derived classes can do a cleanup by overriding this method.
        ///
        protected virtual void Close() { }

        ///
        /// This Fabric method returns a specific InspectorWrapper or null if not handled.
        ///
        /// The Outlook Inspector instance
        /// Returns the specific Wrapper or null
        public static InspectorWrapper GetWrapperFor(Outlook.Inspector inspector)
        {
            // retrieve the message class using late binding
            string messageClass = (string)inspector.CurrentItem.GetType().InvokeMember("MessageClass", BindingFlags.GetProperty, null, inspector.CurrentItem, null);

            switch (messageClass)
            {
                case "IPM.Contact":
                    return new ContactItemWrapper(inspector);
                case "IPM.Appintment":
                    return new AppointmentItemWrapper(inspector);
            }

            return null;
        } 
    }

    internal class ContactItemWrapper : InspectorWrapper
    {
        ///
        /// .ctor
        ///
        /// The Outlook Inspector instance that should be handled
        public ContactItemWrapper(Outlook.Inspector inspector) : base(inspector)
        {
        }

        ///
        /// The Object instance behind the Inspector (CurrentItem)
        ///
        public Outlook.ContactItem Item { get; private set; }

        ///
        /// Method is called when the Wrapper has been initialized
        ///
        protected override void Initialize()
        {
            // Get the Item of the current Inspector
            Item = (Outlook.ContactItem)Inspector.CurrentItem;

            // Register for the Item events
            Item.Open += new Outlook.ItemEvents_10_OpenEventHandler(Item_Open);
            Item.Write += new Outlook.ItemEvents_10_WriteEventHandler(Item_Write);
        }

        ///
        /// This Method is called when the Item is saved.
        ///
        /// When set to true, the save operation is cancelled
        void Item_Write(ref bool Cancel)
        {
            //TODO: Implement something
        }

        ///
        /// This Method is called when the Item is visible and the UI is initialized.
        ///
        /// When you set this property to true, the Inspector is closed.
        void Item_Open(ref bool Cancel)
        {
            //TODO: Implement something
        }

        ///
        /// The Close Method is called when the Inspector has been closed.
        /// Do your cleanup tasks here.
        /// The UI is gone, can't access it here.
        ///
        protected override void Close()
        {
            // unregister events
            Item.Write -= new Outlook.ItemEvents_10_WriteEventHandler(Item_Write);
            Item.Open -= new Outlook.ItemEvents_10_OpenEventHandler(Item_Open);

            // required, just stting to NULL may keep a reference in memory of the Garbage Collector.
            Item = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }

    ///
    /// We derive a Wrapper for each MessageClass / ItemType
    ///
    internal class AppointmentItemWrapper : InspectorWrapper
    {
        ///
        /// The Object instance behind the Inspector (CurrentItem)
        ///
        public Outlook.AppointmentItem Item { get; private set; }

        ///
        /// .ctor
        ///
        /// The Outlook Inspector instance that should be handled
        public AppointmentItemWrapper(Outlook.Inspector inspector) : base(inspector)
        {
        }

        ///
        /// Method is called when the Wrapper has been initialized
        ///
        protected override void Initialize()
        {
            // Get the Item of the current Inspector
            Item = (Outlook.AppointmentItem)Inspector.CurrentItem;

            // Register for the Item events
            Item.Open += new Outlook.ItemEvents_10_OpenEventHandler(Item_Open);
            Item.Write += new Outlook.ItemEvents_10_WriteEventHandler(Item_Write);
        }

        ///
        /// This Method is called when the Item is visible and the UI is initialized.
        ///
        /// When you set this property to true, the Inspector is closed.
        void Item_Open(ref bool Cancel)
        {
            //TODO: Implement something
        }

        ///
        /// This Method is called when the Item is saved.
        ///
        /// When set to true, the save operation is cancelled
        void Item_Write(ref bool Cancel)
        {
            //TODO: Implement something
        }

        ///
        /// The Close Method is called when the Inspector has been closed.
        /// Do your cleanup tasks here.
        /// The UI is gone, can't access it here.
        ///
        protected override void Close()
        {
            // unregister events
            Item.Write -= new Outlook.ItemEvents_10_WriteEventHandler(Item_Write);
            Item.Open -= new Outlook.ItemEvents_10_OpenEventHandler(Item_Open);

            // Release references to COM objects
            Item = null;

            // required, just stting to NULL may keep a reference in memory of the Garbage Collector.
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    } 
}