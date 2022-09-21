using KHOpenApi.NET;
using KFOpenApi.NET;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // ocx�������̽� �߰�
        private AxKHOpenAPI axKHOpenAPI; // ���� (������)
        private AxKFOpenAPI axKFOpenAPI; // �ؿ� (������ �۷ι�)

        public Form1()
        {
            InitializeComponent();

            // ActiveX ����
            axKHOpenAPI = new AxKHOpenAPI(Handle);
            axKHOpenAPI.OnEventConnect += new _DKHOpenAPIEvents_OnEventConnectEventHandler(this.axKHOpenAPI_OnEventConnect);
            button_login_KH.Enabled = axKHOpenAPI.Created;

            axKFOpenAPI = new AxKFOpenAPI(Handle);
            axKFOpenAPI.OnEventConnect += new _DKFOpenAPIEvents_OnEventConnectEventHandler(this.axKFOpenAPI_OnEventConnect);
            button_login_KF.Enabled = axKFOpenAPI.Created;
        }

        // �����α��� �̺�Ʈ �ڵ鷯
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

        // �ؿܷα��� �̺�Ʈ �ڵ鷯
        private void axKFOpenAPI_OnEventConnect(object sender, _DKFOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                textBox2.Text = "�α��� ����";
            }
            else
            {
                textBox2.Text = "�α��� ����";
            }
        }

        private void button_login_KH_Click(object sender, EventArgs e)
        {
            // ���� �α��� ��û
            axKHOpenAPI.CommConnect();
        }

        private void button_login_KF_Click(object sender, EventArgs e)
        {
            // �ؿ� �α��� ��û
            axKFOpenAPI.CommConnect(1);
        }
    }
}
