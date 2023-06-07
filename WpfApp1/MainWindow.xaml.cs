using ShareInvest.Events;
using ShareInvest.Kiwoom;

using System.Windows;
using System.Windows.Interop;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ocx인터페이스 추가
        private AxKHOpenAPI axKHOpenAPI;

        public MainWindow()
        {
            InitializeComponent();
            // ActiveX 세팅
            System.IntPtr Handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();

            axKHOpenAPI = new AxKHOpenAPI(Handle);
            axKHOpenAPI.OnEventConnect += axKHOpenAPI_OnEventConnect;
            button_login_KH.IsEnabled = axKHOpenAPI.Created;
        }

        // 국내로그인 이벤트 핸들러
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

        private void button_login_KH_Click(object sender, RoutedEventArgs e)
        {
            // 국내 로그인 요청
            axKHOpenAPI.CommConnect();
        }
    }
}