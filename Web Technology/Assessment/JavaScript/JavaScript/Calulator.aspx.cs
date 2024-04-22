using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JavaScript
{
    public partial class Calulator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMultiply_Click(object sender, EventArgs e)
        {
            double num1Value = Convert.ToDouble(num1.Text);
            double num2Value = Convert.ToDouble(num2.Text);
            double result = num1Value * num2Value;
            lblResult.Text = "Result: " + result;
        }
        protected void btnDivide_Click(object sender, EventArgs e)
        {
            double num1Value = Convert.ToDouble(num1.Text);
            double num2Value = Convert.ToDouble(num2.Text);
            if (num2Value != 0)
            {
                double result = num1Value / num2Value;
                lblResult.Text = "Result: " + result;
            }
            else
            {
                lblResult.Text = "Division by zero is not allowed.";
            }
        }
    }
}
