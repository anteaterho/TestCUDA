using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CsharpApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            textBox1.Text = "1";
            textBox2.Text = "2";
        }

        void button1_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);

            int[] src1 = { a, a * 10, a * 100, a * 10, a };
            int[] src2 = { b, b * 10, b * 100, b * 10, b };
            int[] dst = { 0, 0, 0, 0, 0 };

            exportCppFunctionAdd(src1, src2, dst, 5);

            textBox3.Text = dst[0] + " , " + dst[1] + " , " + dst[2] + " , " + dst[3] + " , " + dst[4];
        }

        [DllImport("TestCUDA.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern void exportCppFunctionAdd(int[] src, int[] src2, int[] dst, int length);
    }
}
