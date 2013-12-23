using System;
using System.ComponentModel;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;
using System.IO;
using System.Audio;
using System.Collections.Generic;

namespace BrawlSongManager {
	public partial class MainForm : Form {
		/// <summary>
		/// The currently opened .brstm file's root node.
		/// </summary>
		private ResourceNode _rootNode;
		/// <summary>
		/// The full path to the currently opened .brstm file.
		/// </summary>
		private string _rootPath;

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

		/// <summary>
		/// Labels for RightControl.
		/// </summary>
		private Label chooseLabel, loadingLabel, couldNotOpenLabel;

		private Panel grid_app_panel;
		private PropertyGrid grid;
		private AudioPlaybackPanel app;
		private SongNameBar songNameBar;

		#region Options menu values
		private bool _loadNames, _loadBrstms, _groupSongs;

		public bool LoadNames {
			get {
				return _loadNames;
			}
			set {
				_loadNames = value;
				loadNamesFromInfopacToolStripMenuItem.Checked = value;
			}
		}

		public bool LoadBrstms {
			get {
				return _loadBrstms;
			}
			set {
				_loadBrstms = value;
				loadBRSTMPlayerToolStripMenuItem.Checked = value;
			}
		}

		public bool GroupSongs {
			get {
				return _groupSongs;
			}
			set {
				_groupSongs = value;
				groupSongsByStageToolStripMenuItem.Checked = value;
			}
		}
		#endregion

		/// <summary>
		/// Change the control used on the bottom-right section of the window.
		/// Any existing controls in that panel will be removed, and the new control's Dock property will be set to Fill.
		/// </summary>
		private Control RightControl {
			get {
				Control.ControlCollection controls = splitContainer1.Panel2.Controls;
				if (controls.Count > 0) {
					return controls[0];
				} else {
					return null;
				}
			}
			set {
				Control.ControlCollection controls = splitContainer1.Panel2.Controls;
				controls.Clear();
				controls.Add(value);
			}
		}

		public MainForm(string path, bool loadNames, bool loadBrstms, bool groupSongs) {
			InitializeComponent();

			// Setting these values also sets the items in the Options menu to the correct "Checked" value
			this.LoadNames = loadNames;
			this.LoadBrstms = loadBrstms;
			this.GroupSongs = groupSongs;

			// Later commands to change the titlebar assume there is a hypen in the title somewhere
			this.Text += " -";

			#region labels
			this.chooseLabel = new Label();
			this.chooseLabel.Name = "chooseLabel";
			this.chooseLabel.Text = "Choose a stage from the list on the left-hand side.";
			this.chooseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.chooseLabel.Dock = System.Windows.Forms.DockStyle.Fill;

			this.loadingLabel = new Label();
			this.loadingLabel.Name = "loadingLabel";
			this.loadingLabel.Text = "Loading...";
			/*this.loadingLabel.BackColor = Color.Gray;
			this.loadingLabel.ForeColor = Color.White;*/
			this.loadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.loadingLabel.Dock = System.Windows.Forms.DockStyle.Fill;

			this.couldNotOpenLabel = new Label();
			this.couldNotOpenLabel.Name = "couldNotOpenLabel";
			this.couldNotOpenLabel.Text = "Could not open the .PAC file.";
			this.couldNotOpenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.couldNotOpenLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			#endregion

			#region grid_app_panel
			grid_app_panel = new Panel();
			grid_app_panel.Dock = System.Windows.Forms.DockStyle.Fill;

			grid = new PropertyGrid();
			grid.HelpVisible = false;
			grid.Dock = DockStyle.Fill;
			grid_app_panel.Controls.Add(grid);

			app = new AudioPlaybackPanel();
			app.Dock = DockStyle.Bottom;
			grid_app_panel.Controls.Add(app);

			songNameBar = new SongNameBar();
			songNameBar.Dock = DockStyle.Top;
			grid_app_panel.Controls.Add(songNameBar);
			#endregion

			loadNames = loadNamesFromInfopacToolStripMenuItem.Checked;
			loadBrstms = loadBRSTMPlayerToolStripMenuItem.Checked;

			RightControl = chooseLabel;

			// Drag and drop for the left and right sides of the window. The dragEnter and dragDrop methods will check which panel the file is dropped onto.
			splitContainer1.Panel2.AllowDrop = true;
			splitContainer1.Panel2.DragEnter += new DragEventHandler(dragEnter);
			splitContainer1.Panel2.DragDrop += new DragEventHandler(dragDrop);
			listBox1.AllowDrop = true;
			listBox1.DragEnter += new DragEventHandler(dragEnter);
			listBox1.DragDrop += new DragEventHandler(dragDrop);

			this.FormClosing += closing;

			changeDirectory(path);
		}

		private void open(FileInfo fi) {
			RightControl = loadingLabel;
			this.Refresh();
			if (_rootNode != null) {
				_rootNode.Dispose(); _rootNode = null;
			}
			if (fi == null) { // No .brstm file selected (i.e. you just opened the program)
				RightControl = chooseLabel;
				this.Refresh();
			} else {
				try {
					fi.Refresh(); // Update file size
					_rootNode = NodeFactory.FromFile(null, _rootPath = fi.FullName);
				} catch (FileNotFoundException) {
					// This might happen if you delete the file from Explorer after this program puts it in the list
					RightControl = couldNotOpenLabel;
				}
				if (LoadNames) {
					int index = SongListIndices.indexFor(_rootPath.Substring(_rootPath.Length - 9, 3).ToUpper());
					songNameBar.Index = index;
				}
				if (LoadBrstms && _rootNode is IAudioSource) {
					grid.SelectedObject = _rootNode;
					app.TargetSource = _rootNode as IAudioSource;
					app.Enabled = grid.Enabled = true;
				} else {
					grid.SelectedObject = null;
					app.TargetSource = null;
					app.Enabled = grid.Enabled = false;
				}
				RightControl = grid_app_panel;
				this.Refresh();
			}
		}

		private void changeDirectory(string newpath) {
			CurrentDirectory = newpath; // Update the program's working directory
			this.Text = this.Text.Substring(0, this.Text.IndexOf('-')) + "- " + newpath; // Update titlebar

			refreshDirectory();

			statusToolStripMenuItem.Text = songNameBar.findInfoFile();
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

			try {
				listBox1.SelectedIndex = selected;
			} catch (ArgumentOutOfRangeException) {
				// This occurs when you delete the last item in the list (and "group songs" is off)
				listBox1.SelectedIndex = listBox1.Items.Count - 1;
			}
		}

		private void closing(object sender, FormClosingEventArgs e) {
			if (songNameBar != null && songNameBar.IsDirty) {
				DialogResult res = MessageBox.Show("Save changes to info.pac?", "Closing", MessageBoxButtons.YesNoCancel);
				if (res == DialogResult.Yes) {
					songNameBar.save();
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
						if (sender == listBox1 || _rootPath != null) {
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
						copyBrstm(filepath, CurrentDirectory + "\\" + nd.EntryText);
						refreshDirectory();
					}
				}
			} else if (_rootPath != null) {
				if (_rootNode != null) {
					_rootNode.Dispose(); // Close the file before overwriting it!
					_rootNode = null;
				}
				copyBrstm(filepath, _rootPath);
				refreshDirectory();
			}
		}

		/// <summary>
		/// This method can handle WAV files, converting them to BRSTM using BrawlLib's converter.
		/// </summary>
		/// <param name="src">a BRSTM or WAV file</param>
		/// <param name="dest">the output BRSTM path</param>
		private void copyBrstm(string src, string dest) {
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
			new AboutBSM(Icon).ShowDialog(this);
		}

		private void exportToolStripMenuItem_Click(object sender, EventArgs e) {
			using (var dialog = new SaveFileDialog()) {
				dialog.Filter = "BRSTM stream|*.brstm";
				dialog.DefaultExt = "brstm";
				dialog.AddExtension = true;
				dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

				if (dialog.ShowDialog(this) == DialogResult.OK) {
					FileOperations.Copy(_rootPath, dialog.FileName, FileOperations.FileOperationFlags.FOF_NOCONFIRMATION);
				}
			}
		}

		private void renameToolStripMenuItem_Click(object sender, EventArgs e) {
			using (NameDialog nd = new NameDialog()) {
				nd.EntryText = Path.GetFileName(_rootPath);
				if (nd.ShowDialog(this) == DialogResult.OK) {
					if (!nd.EntryText.ToLower().EndsWith(".brstm")) {
						nd.EntryText += ".brstm"; // Force .brstm extension so it shows up in the list
					}
					string from = _rootPath;
					RightControl = loadingLabel;
					if (_rootNode != null) {
						_rootNode.Dispose(); _rootNode = null;
					}
					FileOperations.Rename(from, CurrentDirectory + "\\" + nd.EntryText);
					refreshDirectory();
				}
			}
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
			if (_rootNode != null) {
				_rootNode.Dispose();
				_rootNode = null;
			}
			FileOperations.Delete(_rootPath);
			refreshDirectory();
		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
			listBox1.SelectedIndex = listBox1.IndexFromPoint(listBox1.PointToClient(Cursor.Position));
		}

		#region Options menu actions
		private void loadNamesFromInfopacToolStripMenuItem_Click(object sender, EventArgs e) {
			LoadNames = !LoadNames;
			songNameBar.Index = -1;
		}

		private void loadBRSTMPlayerToolStripMenuItem_Click(object sender, EventArgs e) {
			LoadBrstms = !LoadBrstms;
		}

		private void groupSongsByStageToolStripMenuItem_Click(object sender, EventArgs e) {
			GroupSongs = !GroupSongs;
			refreshDirectory();
		}
		#endregion

		private void saveInfopacToolStripMenuItem_Click(object sender, EventArgs e) {
			songNameBar.save();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Close();
		}

		private void defaultSongsListToolStripMenuItem_Click(object sender, EventArgs e) {
			if (splitContainerTop.Panel2Collapsed) {
				splitContainerTop.Panel2.Controls.Add(new RichTextBox() {
					Dock = DockStyle.Fill,
					Text = SongsByStage.DEFAULTS,
				});
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
			songNameBar.UpdateMenumain();
		}
	}
}
