using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using ApplicationUtils.Utils.XMLProcessing;
using ExceptionHandler;

namespace ApplicationUtils.Utils.FileServer
{
    [Serializable]
    public class UploadingFileInfo
    {
        public UploadingFileInfo() { }

        public UploadingFileInfo(string errorId, string fileFullName, bool isUploaded)
        {
            _errorId = errorId;
            _fileFullName = fileFullName;
            _isUploaded = isUploaded;
        }

        private string _errorId = string.Empty;
        public string ErrorId
        {
            get { return _errorId; }
            set { _errorId = value; }
        }

        private string _fileFullName = string.Empty;
        public string FileFullName
        {
            get { return _fileFullName; }
            set { _fileFullName = value; }
        }

        private bool _isUploaded = false;
        public bool IsUploaded
        {
            get { return _isUploaded; }
            set { _isUploaded = value; }
        }

    }

    public class UploadingFiles
    {
        public UploadingFiles() { }
        public UploadingFiles(string errorId, string[] files)
        {
            AddUploadingFiles(errorId, files);
        }
        private List<UploadingFileInfo> _files = new List<UploadingFileInfo>();
        [XmlArrayItem("UploadingFile")]
        public List<UploadingFileInfo> Files
        {
            get { return _files; }
            set { _files = value; }
        }

        public bool AddUploadingFiles(string errorId, string[] files)
        {
            try
            {
                lock (_files)
                {
                    if (files != null)
                    {

                        for (int i = 0; i < files.Length; i++)
                        {
                            bool isExisting = false;
                            foreach (UploadingFileInfo fileInfo in _files)
                            {
                                if (fileInfo.FileFullName.ToLower().Equals(files[i].ToLower()))
                                {
                                    isExisting = true; break;
                                }
                            }
                            if (!isExisting)
                            {
                                UploadingFileInfo uploadingFileInfo = new UploadingFileInfo(errorId, files[i], false);
                                _files.Add(uploadingFileInfo);
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                ProcessException.Handle(e, "UploadingFiles.AddUploadingFiles() Error");

            }
            return false;
        }

        public bool MarkUploaded(string errorId, string fileName)
        {
            try
            {
                lock (_files)
                {
                    foreach (UploadingFileInfo file in _files)
                    {
                        if (file.ErrorId.Equals(errorId) && file.FileFullName.ToLower().Equals(fileName.ToLower()))
                        {
                            _files.Remove(file);
                            //file.IsUploaded = true;
                            break;
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                ProcessException.Handle(e, "UploadingFiles.AddUploadingFiles() Error");
            }
            return false;
        }

        public string GetErrorIDByFileName(string fileName)
        {
            try
            {
                lock (_files)
                {
                    foreach (UploadingFileInfo fileInfo in _files)
                    {
                        if (fileInfo.FileFullName.ToLower().Equals(fileName.ToLower()))
                            return fileInfo.ErrorId;
                    }
                }
            }
            catch (Exception exception)
            {
                ProcessException.Handle(exception, "UploadingFiles.GetErrorIDByFileName() Error");
            }

            return null;
        }
    }

    public class UploadingFileManager
    {
        public static void SaveUploadingInfo(UploadingFiles uploadingFiles, string fileName)
        {
            try
            {
                ObjectXMLSerializer<UploadingFiles>.Save(uploadingFiles, fileName);
            }
            catch (Exception exception)
            {
                ProcessException.Handle(exception, "UploadingFileManager.SaveUploadingInfo() Error");
            }

        }

        public static UploadingFiles LoadUploadingInfo(string fileName)
        {
            UploadingFiles uploadingFiles = new UploadingFiles();
            try
            {
                uploadingFiles = ObjectXMLSerializer<UploadingFiles>.Load(fileName);
            }
            catch (Exception exception)
            {
                ProcessException.Handle(exception, "UploadingFileManager.LoadUploadingInfo() Error");
            }

            return uploadingFiles;
        }
    }

}
