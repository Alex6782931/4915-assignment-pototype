using Microsoft.VisualBasic.ApplicationServices;
using System.Runtime.CompilerServices;

namespace _4915_assignment_pototype
{
    public partial class Login : Form
    {
        // 在 Login 類別內部加入這個方法
        private void ShowError(string message)
        {
            MessageBox.Show(message, "登入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool isLogin = false;
        public Login()
        {
            InitializeComponent();
            isLogin = false;
        }

        // 虛擬碼流程示意
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string inputUser = txtUsername.Text.Trim();
            string inputPass = txtPassword.Text;

            // 1. 欄位驗證
            if (string.IsNullOrEmpty(inputUser) || string.IsNullOrEmpty(inputPass))
            {
                ShowError("請輸入帳號與密碼");
                return;
            }

            // 2. 呼叫您的 DatabaseAccessController 驗證資料
            var controller = new DatabaseAccessController();
            Staff currentStaff = controller.VerifyLogin(inputUser, inputPass);

            if (currentStaff != null)
            {
                if (!currentStaff.IsActive)
                {
                    ShowError("此帳號已被停用或鎖定，請聯絡管理員。");
                    return;
                }

                // 3. 登入成功！將員工資訊存入全域變數（以便後續檢查 Role 權限）
                GlobalSession.CurrentUser = currentStaff;

                // 4. 開啟主選單（Menu Program），並關閉登入視窗
                MainMenuForm mainForm = new MainMenuForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                ShowError("帳號或密碼錯誤！");
                // 這裡可以累加錯誤次數
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
