using ShareInvest.Events;
using ShareInvest.Kiwoom;

using System.Windows;
using System.Windows.Interop;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            nint Handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();

            axKHOpenAPI = new AxKHOpenAPI(Handle);
            axKHOpenAPI.OnEventConnect += AxKHOpenAPI_OnEventConnect;
            button_login_KH.IsEnabled = axKHOpenAPI.Created;
        }
        void AxKHOpenAPI_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
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
        void Button_login_KH_Click(object sender, RoutedEventArgs e)
        {
            axKHOpenAPI.CommConnect();
        }
        readonly AxKHOpenAPI axKHOpenAPI;
    }
}