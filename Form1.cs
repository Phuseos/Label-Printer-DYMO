using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dymo;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using System.IO;

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

    ToDo : Inserting text dynamically
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
        {
            // Create a new instance of the Form2 class
            Form2 settingsForm = new Form2();

            // Show the settings form
            settingsForm.Show();
        }
    }
}
