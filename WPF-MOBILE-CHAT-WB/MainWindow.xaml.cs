using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using AIMLbot;
using System.Speech.Synthesis;


namespace WPF_MOBILE_CHAT_WB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetBotResponse();
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public void GetBotResponse()
        {
            Bot AI = new Bot();
            AI.loadSettings(); //It will Load Settings from its Config Folder with this code
            AI.loadAIMLFromFiles(); //With this Code It Will Load AIML Files from its AIML Folder
            AI.isAcceptingUserInput = false; //With this Code it will Disable UserInput For Now
            User myuser = new User("Username Here", AI); //With This Code We Will Add The User Through AI/Bot
            AI.isAcceptingUserInput = true; //Now The User Input is Enabled Again with this Code
            Request r = new Request(t2.Text, myuser, AI); //With This Code it will Request The Response From AIML Folders
            Result res = AI.Chat(r); //With This Code It Will Get Result
            t1.Text =res.Output; //With this Code It Will Write the Result of Textbox1 Response to Textbox2 text
            //Now Coding Is Finished!
            //Now Add/Copy & Paste AIML Folder & Config Folder to the Project Directory
            //Now Test the Bot (Without Voice)

            //Now Adding Bot Voice
            SpeechSynthesizer reader = new SpeechSynthesizer(); //Add System.Speech Reference First In Order To Creating It.
            reader.Speak(res.Output); //Set Reader To Response Output of AIML To Speak

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (e.Ke == Keys.Return)
            //{
              GetBotResponse();
            //    e.Handled = e.SuppressKeyPress = true; //This Code for Disabling Beep Sound On Enter Key
            //}

        }




    }
}
