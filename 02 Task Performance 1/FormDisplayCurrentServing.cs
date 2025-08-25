using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static _02_Task_Performance_1.QueuingForm;

namespace _02_Task_Performance_1
{
    public partial class FormDisplayCurrentServing : Form
    {
        
        public FormDisplayCurrentServing()
        {
            InitializeComponent();
            AutoRefresh(); 
        }
        
        private void AutoRefresh() //Refreshes the form automatically using a timer event
        {
            Timer timer = new Timer();
            timer.Interval = (1 * 1000); //1 sec
            timer.Tick += new EventHandler(RefreshTimer_Tick); 
            timer.Start();
        }


        private void RefreshTimer_Tick(object sender, EventArgs e) //After the interval this will be executed
        {
            try
            {
            if (CashierClass.CashierQueue.Contains(CashierClass.CashierQueue.Peek()))
            {
                PositionNumberLabel.Text = CashierClass.CashierQueue.Peek(); //The peek will be seen at the now serving form
            }
            }catch(System.InvalidOperationException)
            {
                //The exception will be ignored even if the queue is empty
            }
        }
    }
}
