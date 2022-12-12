using System.CodeDom.Compiler;

namespace Activity01_EditorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = rtext;
            textBox.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = rtext;
            textBox.Redo();

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = rtext;
            textBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = rtext;
            textBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = rtext;
            textBox.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = rtext;
            textBox.SelectAll();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog myfile=new OpenFileDialog();
            myfile.InitialDirectory = @"C:\\";
            myfile.Filter = "txt files|*.txt | Allfiles(*.*) | *.*";
            myfile.FilterIndex = 2;

            if(myfile.ShowDialog()== DialogResult.OK)
            {
                try
                {
                    string[] lines=File.ReadAllLines(myfile.FileName);
                    foreach(string line in lines)
                    {
                        rtext.Text += line+"\n";
                    }

                }
                catch(Exception ex)
                {

                    MessageBox.Show("Error "+ex.Message);
                }

            }

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontdialog=new FontDialog();
            if(fontdialog.ShowDialog()== DialogResult.OK)
            {
                rtext.SelectionFont=fontdialog.Font;
            }

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;

            if(colorDialog.ShowDialog()== DialogResult.OK)
            {
                rtext.SelectionColor = colorDialog.Color;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txtFiles|*.txt | all files(*.*)|*.*";
            saveFileDialog.FilterIndex = 2;

            if(saveFileDialog.ShowDialog()== DialogResult.OK)
            {
                String filename=saveFileDialog.FileName;
                
                File.WriteAllText( filename, rtext.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            
            form1.Show();
          
            

        }
    }
}