using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomCalendar
{
    // Specifies the default tag to generate for our CustomCalendar control 
    // when it is dragged from visual studio toolbox on to the webform 
    [ToolboxData("<{0}:CustomCalendar runat=server></{0}:CustomCalendar>")]
    // All composite custom controls inheirt from the base CompositeControl class 
    // that contains all the common functionality needed by all composite controls.
    [System.Drawing.ToolboxBitmap(typeof(Calendar))]
    public class CustomCalendar : CompositeControl
    {
        // Child controls required by the CustomCalendar control
        TextBox textBox;
        ImageButton imageButton;
        Calendar calendar;

        [Category("Appearance")]
        [Description("Sets the image icon for the calendar control")]
        public string ImageButtonImageUrl
        {
            get
            {
                // This method checks if the child controls are created, if not, 
                // it triggers a call to CreateChildControls() method.
                EnsureChildControls();
                return imageButton.ImageUrl != null ? imageButton.ImageUrl : string.Empty;
            }
            set
            {
                EnsureChildControls();
                imageButton.ImageUrl = value;
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets the selected date of custom calendar control")]
        public DateTime SelectedDate
        {
            get
            {
                EnsureChildControls();
                return string.IsNullOrEmpty(textBox.Text) ? DateTime.MinValue : Convert.ToDateTime(textBox.Text);
            }

            set
            {
                if (value != null)
                {
                    EnsureChildControls();
                    textBox.Text = value.ToShortDateString();
                }
                else
                {
                    EnsureChildControls();
                    textBox.Text = "";
                }
            }
        }

        // All child controls are required to be created by overriding 
        // CreateChildControls method inherited from the base Control class
        // CompositeControl inherits from WebControl and WebControl class
        // inherits from Control class
        protected override void CreateChildControls()
        {
            Controls.Clear();

            textBox = new TextBox();
            textBox.ID = "dateTextBox";
            textBox.Width = Unit.Pixel(80);

            imageButton = new ImageButton();
            imageButton.ID = "calendarImageButton";
            imageButton.Click += new ImageClickEventHandler(imageButton_Click);

            calendar = new Calendar();
            calendar.ID = "calendarControl";
            calendar.Visible = false;
            calendar.SelectionChanged += new EventHandler(calendar_SelectionChanged);

            // Add Child controls to CustomCalendar control
            this.Controls.Add(textBox);
            this.Controls.Add(imageButton);
            this.Controls.Add(calendar);

        }

        void calendar_SelectionChanged(object sender, EventArgs e)
        {
            // Populate the text box wit the selected date
            textBox.Text = calendar.SelectedDate.ToShortDateString();
            // Make the calendar invisible
            calendar.Visible = false;
        }

        void imageButton_Click(object sender, ImageClickEventArgs e)
        {
            // If the calendar is visible, make it invisible
            if (calendar.Visible)
            {
                calendar.Visible = false;
            }
            // If the calendar is invisible, make it visible
            else
            {
                calendar.Visible = true;
                // if the user has not already selected a date, then set
                // set the VisibleDate of the calendar to today's date
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    calendar.VisibleDate = DateTime.Today;
                }
                // if the user has already selected a date, then set
                // set the VisibleDate of the calendar to the selected date
                // by retrieving it from the textbox
                else
                {
                    DateTime output = DateTime.Today;
                    bool isDateTimeConverionSuccessful = DateTime.TryParse(textBox.Text, out output);
                    calendar.VisibleDate = output;
                }
            }
        }

        // Render the child controls using HtmlTextWriter object
        protected override void Render(HtmlTextWriter writer)
        {
            AddAttributesToRender(writer);
            writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "1");

            writer.RenderBeginTag(HtmlTextWriterTag.Table);

            writer.RenderBeginTag(HtmlTextWriterTag.Tr);

            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            textBox.RenderControl(writer);
            writer.RenderEndTag();

            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            imageButton.RenderControl(writer);
            writer.RenderEndTag();

            writer.RenderEndTag();
            writer.RenderEndTag();

            calendar.RenderControl(writer);
        }

        protected override void RecreateChildControls()
        {
            EnsureChildControls();
        }
    }

}
