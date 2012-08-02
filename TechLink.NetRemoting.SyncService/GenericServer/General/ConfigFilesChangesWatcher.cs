//#define USE_TRACING
using System.Collections;
using System.IO;
using ApplicationUtils.Utils;
using ExceptionHandler;
using log4net;

namespace GenericRemoteServer.General
{
    internal sealed class ConfigFilesChangesWatcher
    {
        private ArrayList filesToIgnore = new ArrayList();
        private bool filesChanged = false;
        private FileSystemWatcher xmlFolderWatcher;
        private FileSystemWatcher translationFolderWatcher;
        private FileSystemWatcher _editableSettingsFolderWatcher;
        private readonly object syncObj = new object();
        public event FileSystemEventHandler Changed;

        public bool EnabledRisingEvents
        {
            set
            {
                lock (syncObj)
                {
                    xmlFolderWatcher.EnableRaisingEvents = value;
                    translationFolderWatcher.EnableRaisingEvents = value;
                    _editableSettingsFolderWatcher.EnableRaisingEvents = value;
                }
            }
        }

        private void OnChanged(FileSystemEventArgs ev)
        {
            if (Changed != null)
            {
                Changed(this, ev);
            }
        }


        public bool FilesChanged
        {
            get
            {
                lock (syncObj)
                {
                    Tracing.TraceCall(filesChanged.ToString());
                    return filesChanged;
                }
            }
        }

        public void Reset()
        {
            lock (syncObj)
            {
                this.filesChanged = false;
            }
        }


        public ConfigFilesChangesWatcher()
        {
            InitFilesWatching();
        }

        private void InitFilesToIgnoreList()
        {
            filesToIgnore = new ArrayList();
            filesToIgnore.Add("FullApplicationDefinition_stream.xml");
            filesToIgnore.Add("ClassificationData.xml");
            filesToIgnore.Add("Domains.xml");
        }

        private void InitFilesWatching()
        {
            InitFilesToIgnoreList();
            //Cần phải sửa các thông tin dưới đây để watcher chạy đúng
            //xmlFolderWatcher = new FileSystemWatcher(InstallationSpecificFolders.GetPath(InstallationSpecificFoldersEnum.Xml),
            //                                         "*.xml");
            //xmlFolderWatcher.IncludeSubdirectories = false;
            //xmlFolderWatcher.Changed += watcher_Changed;
            //xmlFolderWatcher.EnableRaisingEvents = false;

            //translationFolderWatcher =
            //    new FileSystemWatcher(InstallationSpecificFolders.GetPath(InstallationSpecificFoldersEnum.Translations), "*.xml");
            //translationFolderWatcher.IncludeSubdirectories = false;
            //translationFolderWatcher.Changed += watcher_Changed;
            //translationFolderWatcher.EnableRaisingEvents = false;

            //_editableSettingsFolderWatcher = new FileSystemWatcher(InstallationSpecificFolders.GetPath(InstallationSpecificFoldersEnum.EditableSettings),"*.xml");
            //_editableSettingsFolderWatcher.IncludeSubdirectories = false;
            //_editableSettingsFolderWatcher.Changed += watcher_Changed;
            //_editableSettingsFolderWatcher.EnableRaisingEvents = false;

        }

        private void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed && !filesToIgnore.Contains(e.Name) && !filesChanged)
            {
                Tracing.TraceCall(e.Name);
                lock (syncObj)
                {
                    ProcessException.Handle("Configuration file changed: " + e.Name);
                    filesChanged = true;
                    OnChanged(e);
                }
            }
        }
    }
}