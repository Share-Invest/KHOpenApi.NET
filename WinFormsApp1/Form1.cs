using KHOpenApi.NET;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // ocx�������̽� �߰�
        AxKHOpenAPI axKHOpenAPI;

        public Form1()
        {
            InitializeComponent();
            // ���� �߰�
            axKHOpenAPI = new AxKHOpenAPI( Handle );
            axKHOpenAPI.OnEventConnect += new _DKHOpenAPIEvents_OnEventConnectEventHandler(axKHOpenAPI_OnEventConnect);

            button_login.Enabled = axKHOpenAPI.Created;
        }

        // �α��� �̺�Ʈ �ڵ鷯
        private void axKHOpenAPI_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                textBox1.Text = "�α��� ����";
            }
            else
            {
                textBox1.Text = "�α��� ����";
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            // �α��� ��û
            axKHOpenAPI.CommConnect();
        }

    }
}
