﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;
using System.IO;
using BrawlManagerLib;
using System.Audio;

namespace BrawlSongManager {
	public partial class SongPanel : UserControl {
		/// <summary>
		/// The currently opened .brstm file's root node.
		/// </summary>
		private ResourceNode _rootNode;
		/// <summary>
		/// The full path to the currently opened .brstm file.
		/// </summary>
		private string _rootPath;

		public bool LoadNames;
		public bool LoadBrstms;

		public string RootPath {
			get {
				return _rootPath;
			}
		}
		public bool FileOpen {
			get {
				return _rootPath != null;
			}
		}

		public SongPanel() {
			InitializeComponent();

			AllowDrop = true;
			this.DragEnter += SongPanel_DragEnter;
			this.DragDrop += SongPanel_DragDrop;
		}

		public void Close() {
			if (_rootNode != null) {
				_rootNode.Dispose();
				_rootNode = null;
			}
			_rootPath = null;

			grid.SelectedObject = null;
			app.TargetSource = null;
			app.Enabled = grid.Enabled = false;
			songNameBar.Index = -1;
		}
		public void Open(FileInfo fi) {
			if (_rootNode != null) {
				_rootNode.Dispose();
				_rootNode = null;
			}
			_rootPath = fi.FullName;
			_rootNode = NodeFactory.FromFile(null, _rootPath);
			if (LoadNames) {
				string filename = Path.GetFileNameWithoutExtension(_rootPath).ToUpper();
				int index = (from s in SongIDMap.Songs
							 where s.Filename == filename
							 select s.InfoPacIndex ?? -1)
							 .DefaultIfEmpty(-1).First();
				songNameBar.Index = index;
			} else {
				songNameBar.Index = -1;
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
		}

		public void Export() {
			using (var dialog = new SaveFileDialog()) {
				dialog.Filter = "BRSTM stream|*.brstm";
				dialog.DefaultExt = "brstm";
				dialog.AddExtension = true;
				dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

				if (dialog.ShowDialog(this) == DialogResult.OK) {
					File.Copy(RootPath, dialog.FileName, true);
				}
			}
		}
		public void Rename() {
			using (NameDialog nd = new NameDialog()) {
				nd.EntryText = Path.GetFileName(RootPath);
				if (nd.ShowDialog(this) == DialogResult.OK) {
					if (!nd.EntryText.ToLower().EndsWith(".brstm")) {
						nd.EntryText += ".brstm"; // Force .brstm extension so it shows up in the list
					}
					string from = RootPath;
					Close();
					FileOperations.Rename(from, System.Environment.CurrentDirectory + "\\" + nd.EntryText);
				}
			}
		}
		public void Delete() {
			if (_rootNode != null) {
				_rootNode.Dispose();
				_rootNode = null;
				FileOperations.Delete(_rootPath);
				Close();
			}
		}

		public string findInfoFile() {
			return songNameBar.findInfoFile();
		}
		public bool IsInfoBarDirty() {
			return songNameBar.IsDirty;
		}
		public void save() {
			songNameBar.save();
		}
		public void UpdateMenumain() {
			songNameBar.UpdateMenumain();
		}

		private void SongPanel_DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) { // Must be a file
				string[] s = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (s.Length == 1) { // Can only drag and drop one file
					string filename = s[0].ToLower();
					if (filename.EndsWith(".brstm") || filename.EndsWith(".wav")) {
						e.Effect = DragDropEffects.Copy;
					}
				}
			}
		}

		private void SongPanel_DragDrop(object sender, DragEventArgs e) {
			string[] s = (string[])e.Data.GetData(DataFormats.FileDrop);
			string filepath = s[0].ToLower();
			if (FileOpen) {
				if (_rootNode != null) {
					_rootNode.Dispose(); // Close the file before overwriting it!
					_rootNode = null;
				}
				MainForm.copyBrstm(filepath, _rootPath);
				Open(new FileInfo(_rootPath));
				//refreshDirectory();
			}
		}
	}
}
