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

namespace EnglishConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            //EngelswoordjeCol woordjes = new EngelswoordjeCol();
            //ReadDoc.getWordDescription("C:\\Program Files (x86)\\Program test file\\english full.docx");
            //textbox1.Document.Blocks.Clear();
            createSpreadsheet.CreateSpreadsheetWorkbook(".\\test.xlsx");

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

        }

        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {
            textbox1.Document.Blocks.Clear();
            textbox2.Document.Blocks.Clear();

            //List<Engelswoodje> woordjes = ReadDoc.getWordDescription(".\\englishVersie2.docx");
            List<Engelswoodje> woordjes = ReadDoc.getWordDescription(".\\Lifestylevoc.docx");

            foreach (Engelswoodje woordje in woordjes)
            {
                textbox1.AppendText(woordje.zinEngels);
                textbox1.AppendText(Environment.NewLine);
                textbox2.AppendText(woordje.woordjeEngels);
                textbox2.AppendText(Environment.NewLine);
            }


            
            createSpreadsheet.InsertText(".\\test.xlsx", woordjes);


        }
    }
}
