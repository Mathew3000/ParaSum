using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;

namespace ParaSum
{
    public partial class Form1 : Form
    {

        #region Constants
        private const string HEADER_MAIN_STRING = "# Created by ParaSum by Mathew96";
        private const string FILE_NOT_FOUND_STRING = "FILE_NOT_FOUND";
        private const string CURRENT_FOLDER_ALIAS = "*";
        private const char FILENAME_SUM_DELIMITER = ' ';
        private const string MARK_NOT_FOUND = "<missing>";
        private const string MARK_MISSMATCH = "<missmatch>";
        private const string MARK_PASSED = "<passed>";
        #endregion

        #region Typedefs
        
        private struct SumPathCombo
        {
            public string sum;
            public string path;
        }

        private enum VerifyState
        {
            Passed = 0,
            FileNotFound = 1,
            SumNotMatching = 2
        }

        #endregion

        #region Variables

        string scanPath = "";
        bool scanSubDir = false;
        bool isFinished = false;
        int filesTotal = 0;
        int filesDone = 0;
        int filesFailed = 0;

        Stopwatch stopwatch = new Stopwatch();

        private List<string> filePaths = new List<string>();
        private List<SumPathCombo> sums = new List<SumPathCombo>();
        List<string> readSums = new List<string>();
        private List<VerifyState> states = new List<VerifyState>();
        private List<string> diffPaths = new List<string>();

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region Member Functions

        private List<SumPathCombo> GenerateAllMD5Sums (List<string> fileNames)
        {
            stopwatch.Start();
            filesDone = 0;
            filesFailed = 0;
            isFinished = false;

            foreach (string fileName in fileNames)
            {
                ThreadPool.QueueUserWorkItem(GenerateMD5Thread, fileName);
            }

            return sums;
        }

        private void GenerateMD5Thread(object state)
        {
            SumPathCombo sumPath = new SumPathCombo
            {
                sum = GenerateMD5(state as string),
                path = state as string
            };

            bool running = true;

            while (running)
            {
                if (Monitor.TryEnter(sums, 20))
                {
                    try
                    {
                        sums.Add(sumPath);
                        if (Monitor.TryEnter(filesDone, 10))
                        {
                            try
                            {
                                filesDone++;
                                running = false;
                                if(filesDone == filesTotal)
                                {
                                    isFinished = true;
                                    stopwatch.Stop();
                                }
                            }
                            finally
                            {
                                //Monitor.Exit(filesDone);
                            }
                        }
                        else
                        {
                            Thread.Sleep(5);
                        }
                    }
                    finally
                    {
                        Monitor.Exit(sums);
                    }
                }
                else
                {
                    Thread.Sleep(10);
                }
            }
        }

        private string GenerateMD5(string filePath)
        {
            try
            {
                // md5 implementation by "Jon Skeet" https://stackoverflow.com/questions/10520048/calculate-md5-checksum-for-a-file
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(filePath))
                    {
                        var hash = md5.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                }
            }
            catch
            {
                return FILE_NOT_FOUND_STRING;
            }
        }

        private void ScanForFiles(string path, bool recursive = false)
        {
            if (path == "")
            {
                return;
            }

            SearchOption so = SearchOption.TopDirectoryOnly;
            if(recursive)
            {
                so = SearchOption.AllDirectories;
            }

            string[] files = Directory.GetFiles(path, "*", so);

            filesTotal = files.Length;

            foreach (string file in files)
            {
                lb_files.Items.Add(file);
            }
        }

        private void SaveSumsToFile()
        {
            string filePath = "";

            sfd_main.InitialDirectory = scanPath;
            sfd_main.Filter = "md5 files (*.md5)|*.md5|All Files (*.*)|*.*";
            if (sfd_main.ShowDialog() == DialogResult.OK)
            {
                filePath = sfd_main.FileName;

                List<string> outLines = new List<string>();

                outLines.Add(HEADER_MAIN_STRING);
                outLines.Add("# Took: " + stopwatch.Elapsed.Minutes.ToString() + "m" + stopwatch.Elapsed.Seconds.ToString() + "s" + stopwatch.Elapsed.Milliseconds.ToString() + "ms");
                outLines.Add("# Timestamp: " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
                outLines.Add("");

                for (int i = 0; i < filePaths.Count; i++)
                {
                    outLines.Add(sums[i].sum + FILENAME_SUM_DELIMITER + sums[i].path.Replace(scanPath, CURRENT_FOLDER_ALIAS));
                }

                File.WriteAllLines(filePath, outLines);
            }
        }

        private void VerifySums()
        {
            string filePath = "";

            ofd_main.InitialDirectory = scanPath;
            ofd_main.Filter = "md5 files (*.md5)|*.md5|All Files (*.*)|*.*";
            if (ofd_main.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd_main.FileName;

                readSums = new List<string>();
                filePaths = new List<string>();
                sums = new List<SumPathCombo>();
                states = new List<VerifyState>();

                List<string> inLines = new List<string>(File.ReadAllLines(filePath));

                foreach (string line in inLines)
                {
                    if((line == "") || (line.StartsWith("#")))
                    {
                        continue;
                    }

                    string[] parts = line.Split(new[] { FILENAME_SUM_DELIMITER }, 2);

                    readSums.Add(parts[0]);
                    filePaths.Add(parts[1].Replace(CURRENT_FOLDER_ALIAS, scanPath));
                }

                filesTotal = filePaths.Count;

                lb_files.Items.Clear();

                GenerateAllMD5Sums(filePaths);
                ti_verify.Enabled = true;
            }
        }

        private void VerifySumsCheck()
        {
            filesFailed = 0;
            diffPaths = new List<string>();

            for (int i = 0; i < sums.Count; i++)
            {
                int index = filePaths.FindIndex(path => path == sums[i].path);

                if (sums[i].sum == FILE_NOT_FOUND_STRING)
                {
                    lb_files.Items.Add(MARK_NOT_FOUND + " \t" + filePaths[index]);
                    states.Add(VerifyState.FileNotFound);
                    filesFailed++;
                    diffPaths.Add(sums[i].path);
                }
                else if (sums[i].sum == readSums[index])
                {
                    lb_files.Items.Add(MARK_PASSED + " \t" + filePaths[index]);
                    states.Add(VerifyState.Passed);
                }
                else
                {
                    lb_files.Items.Add(MARK_MISSMATCH + " \t" + filePaths[index]);
                    states.Add(VerifyState.SumNotMatching);
                    filesFailed++;
                    diffPaths.Add(sums[i].path);
                }
            }
        }

        // Unused
        private void ExportDiff()
        {
            string exportPath;

            DialogResult result = fbd_scan.ShowDialog();
            if (result == DialogResult.OK)
            {
                exportPath = fbd_scan.SelectedPath;
            }
            else
            {
                return;
            }

            foreach(string path in diffPaths)
            {
                string outPath = path.Replace(scanPath, exportPath);
                if (!Directory.Exists(Path.GetDirectoryName(outPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                }
                File.Copy(path, outPath);
            }

        }

        #endregion

        #region UI

        private void bt_generate_Click(object sender, EventArgs e)
        {
            if(lb_files.Items.Count == 0)
            {
                return;
            }

            filePaths = lb_files.Items.OfType<string>().ToList();

            GenerateAllMD5Sums(filePaths);
        }

        private void cb_subdir_CheckedChanged(object sender, EventArgs e)
        {
            scanSubDir = cb_subdir.Checked;
        }

        private void bt_browse_Click(object sender, EventArgs e)
        {
            DialogResult result = fbd_scan.ShowDialog();
            if (result == DialogResult.OK)
            {
                scanPath = fbd_scan.SelectedPath;
                tb_path.Text = scanPath;
            }
        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            lb_files.Items.Clear();
        }

        private void bt_scanFiles_Click(object sender, EventArgs e)
        {
            ScanForFiles(scanPath, scanSubDir);
        }

        private void ti_ui_Tick(object sender, EventArgs e)
        {
            lbl_done.Text = filesDone.ToString();
            lbl_total.Text = filesTotal.ToString();
            lbl_failed.Text = filesFailed.ToString();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            SaveSumsToFile();
        }

        private void bt_verify_Click(object sender, EventArgs e)
        {
            VerifySums();
        }

        private void ti_verify_Tick(object sender, EventArgs e)
        {
            if (isFinished)
            {
                VerifySumsCheck();
                ti_verify.Enabled = false;
            }
        }

        private void bt_export_Click(object sender, EventArgs e)
        {
            ExportDiff();
        }

        #endregion
    }
}
