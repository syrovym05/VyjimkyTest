using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestVyjimky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ShowIcon = false;
            this.CenterToScreen();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int soucet = 0;
            int pocet = 0;

            for (int i = 0; i < textBox1.Lines.Count(); i++)
            {
                try
                {                    
                    int cislo = Convert.ToInt32(textBox1.Lines[i]);
                    if (cislo < 0)
                    {
                        checked { soucet += cislo; }
                        pocet++;
                    }
                }                
                catch(FormatException ex)
                {
                    MessageBox.Show(ex.Message + " (Zadávej pouze čísla)");
                }
                catch(OverflowException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (ArithmeticException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            try
            {                
                if (pocet == 0) 
                {
                    throw new DivideByZeroException("Nebylo zadáno žádné záporné číslo!");
                }
                else
                {
                    double prumer = Math.Round(((double)soucet / (double)pocet), 3);
                    label2.Text = "Průměr všech záporných čísel je: ";
                    label1.Text = prumer.ToString();
                }
                
            }           
            catch (ArithmeticException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
