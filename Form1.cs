using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dymo;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using System.IO;
using System.Drawing.Printing;
using Microsoft.Office.Interop.Word;
using Microsoft.VisualBasic;
using System.Drawing;

/*
    This application allows you to print all XML labels from a ZIP file.
    Simply click the button on the form, load the ZIP and the printer will start automatically.
    Has been tested for the DYMO LabelWriter 450 Turbo.

    This application was created because I got tired of having to print each label individually.
    
    You can use this code freely, if you have any questions you can contact me on GitHub.

    Disclaimer: I used some code to control the ZipStream, which can be found here -
    http://stackoverflow.com/questions/12715945/unzip-a-memorystream-contains-the-zip-file-and-get-the-files
    
     EDIT 23 / 02 / 17
    Added the option to print to a Toshiba B-FV4D, because my company asked me to.
    Changed button names to allow the adaptation of the printing to the new printer.
    Uses the Word 15.0 library reference.

    ToDo : FilePicker & Inserting text dynamically, filename generation
*/

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void printBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DymoAddInClass _dymoAddin = new DymoAddInClass();
                DymoLabelsClass _dymoLabel = new DymoLabelsClass();

                // this call returns a list of objects on the label
                string[] objNames = _dymoLabel.GetObjectNames(false).Split(new Char[] { '|' });

                // Create OpenFileDialog
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.DefaultExt = ".zip";
                dlg.Filter = "ZIP Files (.zip)|*.zip";

                dlg.ShowDialog();

                // Open document
                string filename = dlg.FileName;

                // Get the file path to use
                string thePath = System.IO.Path.GetDirectoryName(dlg.FileName);

                ZipFile zf = null;

                // Open the stream 
                FileStream fs = File.OpenRead(filename);
                zf = new ZipFile(fs);

                // List that will hold all the files found in the ZIP
                List<string> Files = new List<string>();

                //Loop over the files
                foreach (ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile)
                    {
                        continue;
                    }

                    String entryFileName = zipEntry.Name;
                    // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                    // Optionally match entrynames against a selection list here to skip as desired.
                    // The unpacked length is available in the zipEntry.Size property.

                    byte[] buffer = new byte[4096];     // 4K is optimum
                    Stream zipStream = zf.GetInputStream(zipEntry);

                    // Manipulate the output filename here as desired.
                    String fullZipToPath = Path.Combine(thePath, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);
                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                    // of the file, but does not waste memory.
                    // The "using" will close the stream even if an exception occurs.
                    using (FileStream streamWriter = File.Create(fullZipToPath))
                    {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);

                        Files.Add(fullZipToPath);
                    }
                }

                for (int i = 0; i < Files.Count; i++)
                {
                    if (_dymoAddin.Open(Files[i]))
                    {
                        _dymoAddin.Print(1, false);
                    }
                }

                if (zf != null)
                {
                    zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                    zf.Close(); // Ensure we release resources
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnPrintToshiba_Click(object sender, EventArgs e)
        {//Allows printing labels to the Toshiba B-FV4D
            PrintDocument pDoc = new PrintDocument();

            //Get the name to use for the document creation
            string fNameToUse = Interaction.InputBox("What name will the document have?", "Name your document") + ".docx";

            //Don't allow a blanc file name
            if (string.IsNullOrEmpty(fNameToUse.ToString()))
            {
                MessageBox.Show("Please enter a file name.");
                return;
            }

            //String that will hold the folder to be used
            string folderToUse = null;

            //Show the folder dialog and allow the user to select a path
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    folderToUse = fbd.SelectedPath;
                }
                else
                {
                    MessageBox.Show("You have not selected a folder to write the document to.");
                    return;
                }
            }

            string fPath = folderToUse + "\"" + fNameToUse;

            //Create a new document, don't forget the docx extension
            if (!CreateDocument(fPath))
            {
                MessageBox.Show("Error in file creation");
                return;
            }

            pDoc.PrinterSettings.PrintFileName = fPath;

            //Point towards the labelprinter, make sure the name is correct
            pDoc.PrinterSettings.PrinterName = "TOSHIBA B-FV4 LabelPrinter";

            if (pDoc.PrinterSettings.IsValid)
            {   //Print the document
                //pDoc.Print();
                MessageBox.Show("Print successfull! FilePath = " + fPath);
            }
            else MessageBox.Show("Printer is invalid.");
        }

        private bool CreateDocument(string fileNameToUse)
        {//Setup and create the document
            bool Returner = false;

            try
            {
                //Create a new instance of the word application
                Microsoft.Office.Interop.Word.Application wApp = new Microsoft.Office.Interop.Word.Application();

                //Don't show the animation of the Word application
                wApp.ShowAnimation = false;

                //Don't show the Word app to the user
                wApp.Visible = false;

                //Catch missing variables by using an object
                object mWApp = System.Reflection.Missing.Value;

                //Create a new document
                Microsoft.Office.Interop.Word.Document wDoc = wApp.Documents.Add(ref mWApp, ref mWApp, ref mWApp, ref mWApp);

                /*
                The margins for our type of paper are
                            Upper: 0.5f
                Left: 2.5f                  Right: 2.5f
                            Lower: 5f
                */

                //Because this is a label, no header nor footer will be added, we do need to set the margins tough.
                wDoc.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientPortrait;
                wDoc.PageSetup.TopMargin = InchesToPoints(0.5f);
                wDoc.PageSetup.BottomMargin = InchesToPoints(5f);
                wDoc.PageSetup.LeftMargin = InchesToPoints(2.5f);
                wDoc.PageSetup.RightMargin = InchesToPoints(2.5f);

                object fName = fileNameToUse;

                //Fill the document with information (ToDo : use CALIBRI 26)
                wDoc.Content.Text += "Put your text here";

                //A fontsize of 24 displays nicely on the label
                //wDoc.ActiveWindow.Selection.Font.Size = 24;

                Range wRange = wDoc.ActiveWindow.Selection.Range;
                wRange.Font.Size = 24;
                wRange.Font.Name = "Calibri";

                //Save the document
                //wDoc.SaveAs2(ref mWApp, ref mWApp, ref mWApp);
                wDoc.SaveAs2(ref fName);

                //Close and clean the document
                wDoc.Close(ref mWApp, ref mWApp, ref mWApp);

                wDoc = null;

                wApp.Quit();

                wApp = null;

                Returner = true;
            }
            catch (Exception)
            {
                Returner = false;
            }

            return Returner;
        }

        private float InchesToPoints(float fInches)
        {
            return fInches * 72.0f;
        }
    }
}
