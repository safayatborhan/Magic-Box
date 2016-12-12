using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace magic_box_with_C_sharp
{
    public partial class Form1 : Form
    {
        int input;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0, j, k, count1 = 0, temp = 1, m, n;
                string message;
                //scanf("%d",&input);
                input = int.Parse(textBox1.Text);
                int[,] ara = new int[25, 25];
                j = (input / 2);
                while (true)
                {
                    k = 1;
                    while (k <= input)
                    {
                        //printf("%d %d\n",i,j);
                        //label1.Text = i.ToString() + " " + j.ToString();
                        message = i.ToString() + " " + j.ToString() + '\n';
                        //MessageBox.Show(message);

                        ara[i, j] = temp++;
                        i--;
                        j--;
                        if (i == -1)
                            i = input - 1;
                        if (j == -1)
                            j = input - 1;
                        if (i == -1 && j == -1)
                        {
                            i = -1;
                            j = -1;
                        }
                        count1++;
                        k++;
                        if (k == input + 1)
                        {
                            if (i == input - 1 && j == input - 1)
                            {
                                i = 1;
                                j = 0;
                            }
                            else
                            {
                                if (input % 2 == 0)
                                {
                                    i = i + 2;
                                    j = j + 1;
                                    if (i == input)
                                        i = 0;
                                    if (j == input)
                                        j = 0;
                                }
                                else
                                {
                                    i = i + 2;
                                    j++;
                                }
                            }
                        }
                    }

                    if (count1 == input * input)
                        break;
                }

                for (m = 0; m <= input - 1; m++)
                {
                    for (n = 0; n <= input - 1; n++)
                    {
                        label1.Text += String.Format("{0,7:d2}", ara[m, n]);
                    }
                    label1.Text += "\n";
                }
                label1.Text += "\n\n";
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Magic box.pdf", FileMode.Create));
            doc.Open();
            Paragraph paragraph = new Paragraph("     Magic Box :\n\n" + label1.Text +"\n");
            doc.Add(paragraph);
            doc.Close();
        }
    }
}
