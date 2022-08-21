# KHOpenApi.NET 테스트

WinForms
---------------

#### Form1.cs

```c#
using KHOpenApi.NET;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // ocx인터페이스 추가
        AxKHOpenAPI axKHOpenAPI;

        public Form1()
        {
            InitializeComponent();
            // 새로 추가
            axKHOpenAPI = new AxKHOpenAPI();
            axKHOpenAPI.OnEventConnect += new _DKHOpenAPIEvents_OnEventConnectEventHandler(axKHOpenAPI_OnEventConnect);
            Controls.Add(axKHOpenAPI);
        }

        // 로그인 이벤트 핸들러
        private void axKHOpenAPI_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                textBox1.Text = "로그인 성공";
            }
            else
            {
                textBox1.Text = "로그인 실패";
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            // 로그인 요청
            axKHOpenAPI.CommConnect();
        }

    }
}

```
