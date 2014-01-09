﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;
using System.IO;
using System.Audio;
using System.Collections.Generic;
using BrawlManagerLib;
using System.Linq;

namespace BrawlSongManager {
	public partial class MainForm : Form {
		/// <summary>
		/// The list of .brstm files in the current directory.
		/// </summary>
		private FileInfo[] brstmFiles;

		/// <summary>
		/// Same as System.Environment.CurrentDirectory.
		/// </summary>
		private string CurrentDirectory {
			get {
				return System.Environment.CurrentDirectory;
			}
			set {
				System.Environment.CurrentDirectory = value;
			}
		}

		private bool GroupSongs;

		/// <summary>
		/// Change the message on the right section of the window.
		/// If the message is not null, the audio player will be hidden.
		/// </summary>
		private string RightControl {
			get {
				return songPanel1.Visible ? null : rightLabel.Text;
			}
			set {
				songPanel1.Visible = (value == null);
				rightLabel.Text = value ?? string.Empty;
			}
		}

		private const string chooseLabel = "Choose a stage from the list on the left-hand side.",
			loadingLabel = "Loading...",
			couldNotOpenLabel = "Could not open the .PAC file.";

		public MainForm(string path, bool loadNames, bool loadBrstms, bool groupSongs) {
			InitializeComponent();

			// Setting these values also sets the items in the Options menu to the correct "Checked" value
			loadNamesFromInfopacToolStripMenuItem.Checked = songPanel1.LoadNames = loadNames;
			loadBRSTMPlayerToolStripMenuItem.Checked = songPanel1.LoadBrstms = loadBrstms;
			groupSongsByStageToolStripMenuItem.Checked = GroupSongs = groupSongs;

			// Later commands to change the titlebar assume there is a hypen in the title somewhere
			this.Text += " -";

			loadNames = loadNamesFromInfopacToolStripMenuItem.Checked;
			loadBrstms = loadBRSTMPlayerToolStripMenuItem.Checked;

			RightControl = chooseLabel;

			// Drag and drop for the left and right sides of the window. The dragEnter and dragDrop methods will check which panel the file is dropped onto.
			listBox1.AllowDrop = true;
			listBox1.DragEnter += dragEnter;
			listBox1.DragDrop += dragDrop;

			this.FormClosing += closing;

			changeDirectory(path);
		}

		private void open(FileInfo fi) {
			if (fi == null) { // No .brstm file selected (i.e. you just opened the program)
				RightControl = chooseLabel;
			} else {
					try {
						fi.Refresh(); // Update file size
						songPanel1.Open(fi);
					} catch (FileNotFoundException) {
						// This might happen if you delete the file from Explorer after this program puts it in the list
						RightControl = couldNotOpenLabel;
					}
				RightControl = null;
			}
			this.Refresh();
		}

		private void changeDirectory(string newpath) {
			CurrentDirectory = newpath; // Update the program's working directory
			this.Text = this.Text.Substring(0, this.Text.IndexOf('-')) + "- " + newpath; // Update titlebar

			refreshDirectory();

			statusToolStripMenuItem.Text = songPanel1.findInfoFile();
		}
		private void changeDirectory(DirectoryInfo path) {
			changeDirectory(path.FullName);
		}

		private void refreshDirectory() {
			int selected = listBox1.SelectedIndex;

			DirectoryInfo dir = new DirectoryInfo(CurrentDirectory);
			RightControl = chooseLabel;
			brstmFiles = dir.GetFiles("*.brstm");

			// Special code for the root directory of a drive
			if (brstmFiles.Length == 0) {
				DirectoryInfo search = new DirectoryInfo(dir.FullName + "\\private\\wii\\app\\RSBE\\pf\\sound\\strm");
				if (search.Exists) {
					changeDirectory(search); // Change to the typical song folder used by the FPC, if it exists on the drive
					return;
				}
				search = new DirectoryInfo(dir.FullName + "\\projectm\\pf\\sound\\strm");
				if (search.Exists) {
					changeDirectory(search);
					return;
				}
			}
			Array.Sort(brstmFiles, delegate(FileInfo f1, FileInfo f2) {
				return f1.Name.ToLower().CompareTo(f2.Name.ToLower()); // Sort by filename, case-insensitive
			});

			listBox1.Items.Clear();
			if (GroupSongs) {
				List<string> filenamesAdded = new List<string>();
				listBox1.Items.AddRange(SongsByStage.FromCurrentDir);
				foreach (object o in SongsByStage.FromCurrentDir) {
					if (o is SongsByStage.SongInfo) {
						filenamesAdded.Add(((SongsByStage.SongInfo)o).File.Name);
					}
				}
				foreach (FileInfo f in brstmFiles) {
					if (!filenamesAdded.Contains(f.Name)) listBox1.Items.Add(new SongsByStage.SongInfo(f));
				}
			} else {
				listBox1.Items.AddRange(brstmFiles);
			}
			listBox1.Refresh();

			// Re-select and re-load the file that was selected before
			try {
				listBox1.SelectedIndex = selected;
			} catch (ArgumentOutOfRangeException) {
				// This occurs when you delete the last item in the list (and "group songs" is off)
				listBox1.SelectedIndex = listBox1.Items.Count - 1;
			}
		}

		private void closing(object sender, FormClosingEventArgs e) {
			if (songPanel1.IsInfoBarDirty()) {
				DialogResult res = MessageBox.Show("Save changes to info.pac?", "Closing", MessageBoxButtons.YesNoCancel);
				if (res == DialogResult.Yes) {
					songPanel1.save();
				} else if (res == DialogResult.Cancel) {
					e.Cancel = true;
				}
			}
		}

		public void dragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) { // Must be a file
				string[] s = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (s.Length == 1) { // Can only drag and drop one file
					string filename = s[0].ToLower();
					if (filename.EndsWith(".brstm") || filename.EndsWith(".wav")) {
						if (sender == listBox1/* || songPanel1.FileOpen*/) {
							e.Effect = DragDropEffects.Copy;
						}
					}
				}
			}
		}

		public void dragDrop(object sender, DragEventArgs e) {
			string[] s = (string[])e.Data.GetData(DataFormats.FileDrop);
			string filepath = s[0].ToLower();
			if (sender == listBox1) {
				using (NameDialog nd = new NameDialog()) {
					nd.EntryText = s[0].Substring(s[0].LastIndexOf('\\') + 1); // Textbox on the dialog ("Text" is already used by C#)
					if (nd.ShowDialog(this) == DialogResult.OK) {
						if (!nd.EntryText.ToLower().EndsWith(".brstm")) {
							nd.EntryText += ".brstm"; // Force .brstm extension so it shows up in the list
						}
						if (string.Equals(nd.EntryText, Path.GetFileName(songPanel1.RootPath), StringComparison.InvariantCultureIgnoreCase)) {
							songPanel1.Close(); // in case the file is already open
						}
						copyBrstm(filepath, CurrentDirectory + "\\" + nd.EntryText);
						refreshDirectory();
					}
				}
			}/* else if (songPanel1.FileOpen) {
				if (_rootNode != null) {
					_rootNode.Dispose(); // Close the file before overwriting it!
					_rootNode = null;
				}
				copyBrstm(filepath, _rootPath);
				refreshDirectory();
			}*/
		}

		/// <summary>
		/// This method can handle WAV files, converting them to BRSTM using BrawlLib's converter.
		/// </summary>
		/// <param name="src">a BRSTM or WAV file</param>
		/// <param name="dest">the output BRSTM path</param>
		public static void copyBrstm(string src, string dest) {
			if (src.EndsWith(".brstm")) {
				FileOperations.Copy(src, dest); // Use FileOperations (calls Windows shell -> asks for confirmation to overwrite)
			} else {
				BrstmConverterDialog bcd = new BrstmConverterDialog();
				bcd.AudioSource = src;
				if (bcd.ShowDialog() == DialogResult.OK) {
					// Make a temporary node to put the data in, and export it.
					// This avoids the need to use pointers directly.
					RSTMNode tmpNode = new RSTMNode();
					tmpNode.ReplaceRaw(bcd.AudioData);
					tmpNode.Export(dest);
					tmpNode.Dispose();
				}
				bcd.Dispose();
			}
		}

		/// <summary>
		/// Calls open() on the song selected in listBox1.
		/// </summary>
		private void loadSelectedFile() {
			object o = listBox1.SelectedItem;
			if (o is SongsByStage.SongInfo) {
				SongsByStage.SongInfo s = (SongsByStage.SongInfo)o;
				s.File.Refresh();
				listBox1.Refresh();
				open(s.File);
			} else if (o is FileInfo) {
				open((FileInfo)o);
			} else if (o is string) {
				open(null);
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
			loadSelectedFile();
		}

		private void changeDirectoryToolStripMenuItem_Click(object sender, EventArgs e) {
			FolderBrowserDialog fbd = new FolderBrowserDialog();
//			fbd.SelectedPath = CurrentDirectory; // Uncomment this if you want the "change directory" dialog to start with the current directory selected
			if (fbd.ShowDialog() == DialogResult.OK) {
				changeDirectory(fbd.SelectedPath);
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			new AboutBSM(Icon, System.Reflection.Assembly.GetExecutingAssembly()).ShowDialog(this);
		}

		private void exportToolStripMenuItem_Click(object sender, EventArgs e) {
			songPanel1.Export();
		}

		private void renameToolStripMenuItem_Click(object sender, EventArgs e) {
			songPanel1.Rename();
			refreshDirectory();
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
			songPanel1.Delete();
			refreshDirectory();
		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
			listBox1.SelectedIndex = listBox1.IndexFromPoint(listBox1.PointToClient(Cursor.Position));
		}

		#region Options menu actions
		private void loadNamesFromInfopacToolStripMenuItem_Click(object sender, EventArgs e) {
			songPanel1.LoadNames = !songPanel1.LoadNames;
		}

		private void loadBRSTMPlayerToolStripMenuItem_Click(object sender, EventArgs e) {
			songPanel1.LoadBrstms = !songPanel1.LoadBrstms;
		}

		private void groupSongsByStageToolStripMenuItem_Click(object sender, EventArgs e) {
			GroupSongs = !GroupSongs;
			refreshDirectory();
		}
		#endregion

		private void saveInfopacToolStripMenuItem_Click(object sender, EventArgs e) {
			songPanel1.save();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Close();
		}

		private void defaultSongsListToolStripMenuItem_Click(object sender, EventArgs q) {
			if (splitContainerTop.Panel2Collapsed) {
				var r = new ReadOnlySearchableRichTextBox() {
					Dock = DockStyle.Fill,
					Text = ReadOnlySearchableRichTextBox.HELP + "\n\n" + SongsByStage.DEFAULTS,
				};
				splitContainerTop.Panel2.Controls.Add(r);
				splitContainerTop.Panel2Collapsed = false;
			} else {
				splitContainerTop.Panel2.Controls.Clear();
				splitContainerTop.Panel2Collapsed = true;
			}
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.PageDown) {
				e.Handled = true;
				if (listBox1.SelectedIndex == listBox1.Items.Count - 1) {
					listBox1.SelectedIndex = 0;
				} else {
					listBox1.SelectedIndex++;
				}
			} else if (e.KeyCode == Keys.PageUp) {
				e.Handled = true;
				if (listBox1.SelectedIndex <= 0) {
					listBox1.SelectedIndex = listBox1.Items.Count - 1;
				} else {
					listBox1.SelectedIndex--;
				}
			}
		}

		private void updateMumenumainToolStripMenuItem_Click(object sender, EventArgs e) {
			songPanel1.UpdateMenumain();
		}
	}
}
