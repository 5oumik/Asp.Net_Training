using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetRnD
{
   
    public partial class CalendarUserControl : System.Web.UI.UserControl
    {
        public event CalendarVisibilityChangedEventHandler CalendarVisibilityChanged;

        public string SelectedDate
        {
            get
            {
                return txtDate.Text;
            }
            set
            {
                txtDate.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Calendar1.Visible = false;
                CalenderVisibilityChangedEventArgs visibilityData = new CalenderVisibilityChangedEventArgs(false);
            }
        }

        protected void ImgBtn_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                //Calendar1.Visible = false;
                CalenderVisibilityChangedEventArgs visibilityData = new CalenderVisibilityChangedEventArgs(false);
        }
            else
            {
                //Calendar1.Visible = true;
                CalenderVisibilityChangedEventArgs visibilityData = new CalenderVisibilityChangedEventArgs(true);
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtDate.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }

        protected virtual void OnCalendarVisibilityChanged(CalenderVisibilityChangedEventArgs args)
        {
            if(CalendarVisibilityChanged != null)
            CalendarVisibilityChanged(this, args);
        }

    }

    public class CalenderVisibilityChangedEventArgs : EventArgs
    {
        private bool isCalendarVisible;

        public CalenderVisibilityChangedEventArgs(bool isCalendarVisible)
        {
            this.isCalendarVisible = isCalendarVisible;
        }

        public bool IsCalendarVisible
        {
            get
            {
                return this.isCalendarVisible;
            }
        }

    }

    public delegate void CalendarVisibilityChangedEventHandler(object sender, CalenderVisibilityChangedEventArgs args);

  
}