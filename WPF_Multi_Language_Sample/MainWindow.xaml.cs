using System.Windows;

namespace WPF_Multi_Language_Sample
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //저장된 정보로 세팅 (저장된 값이 없으면 PC국가 설정값을 기본으로 함)
            Localization.res.Culture = Properties.Settings.Default.language != string.Empty ? 
                                        new System.Globalization.CultureInfo(Properties.Settings.Default.language) : System.Globalization.CultureInfo.CurrentCulture;

            InitializeComponent();
        }

        private void cbLanguage_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //선택 정보 불러오기
            string selected = (string)((System.Windows.Controls.ComboBox)sender).SelectedItem;

            //선택 정보 저장하기
            Properties.Settings.Default.language = selected;
            Properties.Settings.Default.Save();
            
            //새 프로그램 실행
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);

            //현재 프로그램 종료
            Application.Current.Shutdown();

        }
    }
}