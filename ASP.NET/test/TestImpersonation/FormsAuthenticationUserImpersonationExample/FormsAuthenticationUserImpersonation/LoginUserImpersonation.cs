using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace System.Web.UI.WebControls
{

    /// <summary>
    /// The LoginUserImpersonation control presents a link button which will when clicked on revert user impersonation.
    /// When no user is being impersonated the LoginUserImpersonation controll will not be rendered.
    /// </summary>
    [ToolboxData("<{0}:LoginUserImpersonation runat=\"server\" ID=\"LoginUserImpersonation\" />")]
    public class LoginUserImpersonation : Control
    {

        #region Variables & Properties

        private LinkButton _deimpersonateLink;

        #endregion

        #region Functions

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _deimpersonateLink = new LinkButton();
            _deimpersonateLink.Click += new EventHandler(deimpersonateLink_Click);
            Controls.Add(_deimpersonateLink);

            // Hide the link button if no user is being impersonated.
            if (UserImpersonation.IsImpersonating)
            {
                _deimpersonateLink.Text = string.Format("Return to {0}", UserImpersonation.PrevUserName);
            }
            else
            {
                _deimpersonateLink.Visible = false;
            }
        }

        void deimpersonateLink_Click(object sender, EventArgs e)
        {
            if (UserImpersonation.IsImpersonating)
            {
                if (Deimpersonate != null)
                    Deimpersonate.Invoke(this, new EventArgs());

                UserImpersonation.Deimpersonate();
            }
        }

        /// <summary>
        /// The Deimpersonate event is invoked just before user impersonation is ended.
        /// </summary>
        public event EventHandler Deimpersonate;

        #endregion
    }
}
