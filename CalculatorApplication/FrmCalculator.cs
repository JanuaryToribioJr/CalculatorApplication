using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApplication
{
    public partial class Form1 : Form
    {
        CalculatorClass calc = new CalculatorClass();
        public delegate T Formula<T>(T n1, T n2);
        public Form1(CalculatorClass calc)
        {
            this.calc = calc;
            InitializeComponent();
        }
        public Form1()
        {
            InitializeComponent();
        }
        public class CalculatorClass 
        {
            public Formula<double> Total;
            public event Formula<double> CalculateEvent
            {
                add
                {
                    MessageBox.Show("Added to delegate");
                    Total += value;
                }
                remove
                {
                    MessageBox.Show("Removed to delegate");
                    Total -= value;
                }
            }
            public double GetSum(double num1, double num2)
            {
                return num1 + num2;
            }
            public double GetDifference(double num1, double num2)
            {
                return num1 - num2;
            }
            public double GetMultiplication(double num1, double num2)
            {
                return num1 * num2;
            }
            public double GetDivision(double num1, double num2)
            {
                return num1 / num2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double n1 = Convert.ToDouble(num1.Text);
            double n2 = Convert.ToDouble(num2.Text);
            string Operator = op.SelectedItem.ToString();

                if (Operator == "+")
                {
                    calc.CalculateEvent += new Formula<double>(calc.GetSum);
                    ans.Text = calc.GetSum(n1, n2).ToString();
                    calc.CalculateEvent -= new Formula<double>(calc.GetSum);
                }
                else if (Operator == "-")
                {
                    calc.CalculateEvent += new Formula<double>(calc.GetDifference);
                    ans.Text = calc.GetDifference(n1, n2).ToString();
                    calc.CalculateEvent -= new Formula<double>(calc.GetDifference);
                }
                else if (Operator == "*")
                {
                    calc.CalculateEvent += new Formula<double>(calc.GetMultiplication);
                    ans.Text = calc.GetMultiplication(n1, n2).ToString();
                    calc.CalculateEvent -= new Formula<double>(calc.GetMultiplication);
                }
                else if (Operator == "/")
                {
                    if (n2 != 0)
                    {
                        calc.CalculateEvent += new Formula<double>(calc.GetDivision);
                        ans.Text = calc.GetDivision(n1, n2).ToString();
                        calc.CalculateEvent -= new Formula<double>(calc.GetDivision);
                    }
                    else
                    {
                        ans.Text = "Undefined";
                    }
                }

        }
       
    }

}