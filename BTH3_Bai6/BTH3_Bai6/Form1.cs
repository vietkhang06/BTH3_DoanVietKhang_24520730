using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH3_Bai6
{
    public partial class Form1 : Form
    {
        decimal num1 = 0m;
        decimal num2 = 0m;
        string operation = "";
        bool isOperationPerformed = false;
        decimal memorySaved = 0m;
        public Form1()
        {
            InitializeComponent();
        }
        private void numBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (tbDisplay.Text == "0" || isOperationPerformed)
            {
                tbDisplay.Text = button.Text;
            }
            else 
            {
                tbDisplay.Text += button.Text;
            }
            isOperationPerformed = false;
        }
        private void operatorBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (isOperationPerformed)
            {
                operation = button.Text;
                return;
            }

            if (operation == "")
            {
                num1 = Decimal.Parse(tbDisplay.Text);
            }
            else
            {
                btnEqual_Click(sender, e);
            }

            operation = button.Text;
            isOperationPerformed = true;
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (operation == "")
            {
                return;
            }

            if (!isOperationPerformed)
            {
                num2 = Decimal.Parse(tbDisplay.Text);
            }

            switch (operation)
            {
                case "+":
                    tbDisplay.Text = (num1 + num2).ToString();
                    break;
                case "-":
                    tbDisplay.Text = (num1 - num2).ToString();
                    break;
                case "*":
                    tbDisplay.Text = (num1 * num2).ToString();
                    break;
                case "/":
                    if (num2 == 0) tbDisplay.Text = "Cannot divide by zero";
                    else
                    {
                        tbDisplay.Text = (num1 / num2).ToString();
                    }
                    break;
                default:
                    break;
            }

            Decimal.TryParse(tbDisplay.Text, out num1);
            isOperationPerformed = true;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            tbDisplay.Text = "0";
            num1 = 0m;
            num2 = 0m;
            operation = "";
            isOperationPerformed = false;
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            tbDisplay.Text = "0";
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (tbDisplay.Text.Length > 0)
            {
                tbDisplay.Text = tbDisplay.Text.Remove(tbDisplay.Text.Length - 1, 1);
            }
            if (tbDisplay.Text == "")
            {
                tbDisplay.Text = "0";
            }
        }

        private void btnMS_Click(object sender, EventArgs e)
        {
            memorySaved = Decimal.Parse(tbDisplay.Text);
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            tbDisplay.Text = memorySaved.ToString();
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            memorySaved = 0m;
        }

        private void btnMplus_Click(object sender, EventArgs e)
        {
            memorySaved += Decimal.Parse(tbDisplay.Text);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbDisplay.Text);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My Calculator created by 24520730 - Doan Viet Khang", "About");
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (isOperationPerformed)
            {
                tbDisplay.Text = "0.";
                isOperationPerformed = false; 
            }
            else if (!tbDisplay.Text.Contains("."))
            {
                tbDisplay.Text += ".";
            }
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            if (Decimal.TryParse(tbDisplay.Text, out decimal currentValue))
            {
                if (currentValue < 0)
                {
                    tbDisplay.Text = "Invalid input";
                }
                else
                {
                    double result = Math.Sqrt((double)currentValue);
                    tbDisplay.Text = result.ToString();
                }
            }
            isOperationPerformed = true;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (operation == "")
            {
                if (Decimal.TryParse(tbDisplay.Text, out decimal currentValue))
                {
                    tbDisplay.Text = (currentValue / 100m).ToString();
                }
            }
            else
            {
                if (Decimal.TryParse(tbDisplay.Text, out decimal currentValue))
                {
                    num2 = num1 * (currentValue / 100m);
                    tbDisplay.Text = num2.ToString();
                }
            }
            isOperationPerformed = true;
        }

        private void btnInverse_Click(object sender, EventArgs e)
        {
            if (Decimal.TryParse(tbDisplay.Text, out decimal currentValue))
            {
                if (currentValue == 0)
                {
                    tbDisplay.Text = "Cannot divide by zero";
                }
                else
                {
                    tbDisplay.Text = (1m / currentValue).ToString();
                }
            }
            isOperationPerformed = true;
        }

        private void btnToggleSign_Click(object sender, EventArgs e)
        {
            if (Decimal.TryParse(tbDisplay.Text, out decimal currentValue))
            {
                if (currentValue != 0m)
                {
                    currentValue = currentValue * -1;
                    tbDisplay.Text = currentValue.ToString();
                }
            }
        }
    }
}