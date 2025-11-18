using System.Media;

namespace BTLT04
{
    public partial class GameOverScreen : Form
    {
        bool isCloseByMyButton=false;
        public GameOverScreen(Result result) : this()
        {
            TimePlayBox.Text += result.PlayTime.ToString();
            ScoreBox.Text += result.Score.ToString();
        }

        public GameOverScreen()
        {
            InitializeComponent();
            PlayGameOverMusic();
            RestartButton.Click += RestartButton_Click;
            BackStartScreenButton.Click += BackStartScreenButton_Click;
            FormClosed += GameOverScreen_FormClosed;
        }

        private void GameOverScreen_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (!isCloseByMyButton&&Owner!=null)
            {
                Owner.Show();
            }    
        }

        private void BackStartScreenButton_Click(object? sender, EventArgs e)
        {
            if (Owner == null) return;
            Owner.Show();
            isCloseByMyButton = true;
            Close();
        }

        private void RestartButton_Click(object? sender, EventArgs e)
        {
            var mainScreen = new MainScreen();
            mainScreen.Show();
            mainScreen.Owner = Owner;
            isCloseByMyButton = true;
            Close();
        }

        private static async Task PlayGameOverMusic()
        {
            var musicGameOver = new SoundPlayer("Resources/SoundOfFail.wav");
            musicGameOver.Play();
            await Task.Delay(2000);
            musicGameOver = new SoundPlayer("Resources/MainScreenSound.wav");
            musicGameOver.PlayLooping();
        }
    }
}