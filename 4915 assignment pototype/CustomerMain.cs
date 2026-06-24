using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class CustomerMain : Form
    {
        // 【新增】定义一个私有变量，用来在当前窗体中保存登录成功的 customerId
        private string _loggedInCustomerId;

        /// <summary>
        /// 保留无参数构造函数，防止 Visual Studio 窗体设计器（Designer）报错
        /// </summary>
        public CustomerMain()
        {
            InitializeComponent();
            AttachEventHandlers();
        }

        /// <summary>
        /// 【新增】带有参数的构造函数，用于从登录界面传入 customerId
        /// </summary>
        public CustomerMain(string customerId) : this() // : this() 会自动先调用上面的无参构造函数（初始化组件和绑定事件）
        {
            _loggedInCustomerId = customerId;

            // 选填：你可以在这里或者 Load 事件里测试是否成功拿到 ID
            // MessageBox.Show($"当前登录的客户 ID 是: {_loggedInCustomerId}");
        }

        /// <summary>
        /// Binds the click events of the designer buttons to their respective logic methods.
        /// </summary>
        private void AttachEventHandlers()
        {
            btnviewhistory.Click += Btnviewhistory_Click;
            btnaddress.Click += Btnaddress_Click;
            btnpayment.Click += Btnpayment_Click;
            btnlogout.Click += Btnlogout_Click;
        }

        // 1. Order Product
        /*private void Btnmakeorder_Click(object sender, EventArgs e)
        {
            MakeOrder orderForm = new MakeOrder();
            NavigateTo(orderForm);

            MessageBox.Show("Navigating to Order Product Screen...", "Prototype Action");
        }*/

        // 2. View Order History
        private void Btnviewhistory_Click(object sender, EventArgs e)
        {
            OrderHistory orderForm = new OrderHistory();
            NavigateTo(orderForm);

            MessageBox.Show("Navigating to Order History Screen...", "Prototype Action");
        }


        private void Btnaddress_Click(object sender, EventArgs e)
        {
            Address orderForm = new Address();
            NavigateTo(orderForm);

            MessageBox.Show("Navigating to Address Management Screen...", "Prototype Action");
        }

        // 5. Modify Payment Information
        private void Btnpayment_Click(object sender, EventArgs e)
        {
            payment orderForm = new payment();
            NavigateTo(orderForm);

            MessageBox.Show("Navigating to Payment Information Screen...", "Prototype Action");
        }

        // 6. Logout
        private void Btnlogout_Click(object sender, EventArgs e)
        {
            // 1. 先弹窗询问，不要先急着建新窗体
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 2. 解除 FormClosed 事件绑定（非常关键！）
                // 因为你的 FormClosed 绑定了 Application.Exit()。
                // 如果不解除，点注销关闭当前窗体时，会把整个程序（包括新打开的登录页）一起强行关掉。
                this.FormClosed -= CustomerMain_FormClosed;

                // 3. 打开登录新窗体
                Login loginForm = new Login();
                loginForm.Show();

                // 4. 【核心修复】使用 Close() 彻底关闭并释放当前的 CustomerMain，而不是 Hide()
                this.Close();
            }
        }

        /// <summary>
        /// Helper method to streamline form transition mechanics
        /// </summary>
        private void NavigateTo(Form nextForm)
        {
            this.Hide();            // Hides the current dashboard
            nextForm.ShowDialog();  // Opens the next screen as a modal window
            this.Show();            // Brings the dashboard back once the sub-screen is closed
        }

        private void CustomerMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void CustomerMain_Load(object sender, EventArgs e)
        {
            lblwelcome.Text = $"Welcome, User: {_loggedInCustomerId}";
        }
    }
}