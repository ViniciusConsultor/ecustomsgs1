using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using ExceptionHandler;

namespace ApplicationUtils.Utils
{
	/// <summary>
	/// Summary description for FileUtils.
	/// </summary>
	public class FileUtils
	{

    public static string GetFileName(string path)
    {
      return Path.GetFileName(path);
    }

    public static bool MoveFile(string source, string desc)
    {
      try
      {
        File.Move(source, desc);
        return true;
      }
      catch (Exception exception)
      {
        ProcessException.Handle(exception);
        return false;
      }
    }

    public static bool MoveFile(string source, string desc, bool overrideable)
    {
      try
      {
        if (source.ToLower().CompareTo(desc.ToLower()) == 0) return true;
        File.Copy(source, desc, overrideable);
        File.Delete(source);
        return true;
      }
      catch (Exception exception)
      {
        ProcessException.Handle(exception);
        return false;
      }
    }

		public static byte[] GetFileContentWithExclisiveAccess(string fileName)
		{
			byte[] inputBytes = null;
			try
			{
				FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
				BinaryReader reader = new BinaryReader(fileStream);
				inputBytes = new byte[fileStream.Length];
				inputBytes = reader.ReadBytes((int)fileStream.Length);
				reader.Close();
				fileStream.Close();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return inputBytes;
		}


		public static byte[] GetFileContent(string fileFullPath)
		{
			return GetFileContent(fileFullPath, false);
		}

    public static string GetFileExt(string fileName)
    {
      return Path.GetExtension(fileName);
    }

		public static byte[] GetFileContent(string fileFullPath, bool throwException)
		{
			FileStream fileStream = null;
			BinaryReader reader = null;
			byte[] inputBytes = null;

			string tmpPath = Path.GetTempFileName();
			//delete the empty file
			TryDelete(tmpPath);
			try
			{
				if (File.Exists(fileFullPath))
				{
					File.Copy(fileFullPath, tmpPath);
					fileStream = new FileStream(tmpPath, FileMode.Open, FileAccess.Read);
					reader = new BinaryReader(fileStream);
					inputBytes = new byte[fileStream.Length];
					inputBytes = reader.ReadBytes((int)fileStream.Length);
					reader.Close();
					fileStream.Close();
				}
			}
			catch (Exception e)
			{
				if (fileStream != null)
				{
					fileStream.Close();
				}

				if (reader != null)
				{
					reader.Close();
				}

				TryDelete(tmpPath);

				if (throwException)
					throw;

				Debug.WriteLine(e);
			}

			return inputBytes;
		}


		public static bool SaveToFile(string filePath, byte[] content)
		{
			return SaveToFile(filePath, content, false);
		}

		public static bool SaveAsmContentToFile(string filePath, byte[] content)
		{
			try
			{
				if (content.Length == 0) return false;
				FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
				fileStream.Write(content, 0, content.Length);
				fileStream.Flush();
				fileStream.Close();
			}
			catch (Exception exception)
			{
				ProcessException.WriteErrorLog("Can not save ASM content to file: " + filePath, "FileUtils.SaveAsmContentToFile()");
				return false;
			}
			return true;
		}
		public static bool SaveImageContentToFile(string filePath, byte[] content)
		{
			try
			{
				if (content.Length == 0) return false;
				FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
				fileStream.Write(content, 0, content.Length);
				fileStream.Flush();
				fileStream.Close();
			}
			catch (Exception exception)
			{
				ProcessException.WriteErrorLog("Can not save image content to file: " + filePath, "FileUtils.SaveImageContentToFile()");
				return false;
			}
			return true;
		}

    /// <summary>
    /// Save file content into file. If the file already exists, it would be overwritten.
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="content"></param>
    /// <param name="thorwExpcetions"></param>
    /// <returns></returns>
		public static bool SaveToFile(string filePath, byte[] content, bool thorwExpcetions)
		{
			try
			{
        if (content == null) return false;

        if(!Directory.Exists(PathUtils.GetFolderPathFromFilePath(filePath)))
        {
          PathUtils.CreateFolderPathRecursiveable(PathUtils.GetFolderPathFromFilePath(filePath));
        }

				using (FileStream textWriter = new FileStream(filePath, FileMode.Create, FileAccess.Write))
				{
					using (MemoryStream stream = new MemoryStream(content))
					{
						stream.WriteTo(textWriter);
            stream.Flush();
						stream.Close();
					}
          textWriter.Flush();
					textWriter.Close();
				}
				return true;
			}
			catch (Exception e)
			{
				if (thorwExpcetions)
				{
					Debug.Fail(e.Message);
					throw;
				}
				else
				{
					ProcessException.Handle(e);
					Debug.Fail(e.Message);
				}
			}
			return false;
		}

		public static bool SaveToFile(string filePath, string content)
		{
			try
			{
				using (TextWriter textWriter = File.CreateText(filePath))
				{
					textWriter.Write(content);
				}
				return true;
			}
			catch (Exception e)
			{
				ProcessException.Handle(e);
				Debug.WriteLine(e);
			}
			return false;
		}

		public static string GetFileContentAsText(string fileFullPath)
		{
			try
			{
				string text = File.ReadAllText(fileFullPath, Encoding.Default);
				if (text.Contains("Ã") || text.Contains("¤") || text.Contains("¶"))
				{
					text = File.ReadAllText(fileFullPath, Encoding.UTF8);
				}
				return text;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public static string[] GetFileContentAsTextLines(string fileFullPath)
		{
			try
			{
				string text = File.ReadAllText(fileFullPath, Encoding.Default);
				if (text.Contains("Ã") || text.Contains("¤") || text.Contains("¶"))
				{
					return File.ReadAllLines(fileFullPath, Encoding.UTF8);
				}
				else
				{
					return File.ReadAllLines(fileFullPath, Encoding.Default);
				}
			}
			catch (Exception ex)
			{
				return new string[] { ex.Message };
			}
		}


		public static bool TryDelete(string filePath)
		{
			return TryDelete(filePath, false);
		}

		public static bool TryDelete(string filePath, bool throwExceptions)
		{
			try
			{
				File.Delete(filePath);
				if (File.Exists(filePath))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				if (throwExceptions)
				{
					throw;
				}
			}
			return false;
		}

		public static void MakeFileNotReadonly(string filePath)
		{
			try
			{
				if (File.Exists(filePath))
				{
					File.SetAttributes(filePath, File.GetAttributes(filePath) & ~FileAttributes.ReadOnly);
				}
			}
			catch
			{
			}
		}

		public static void RenameIncremental(string filePath)
		{
			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException("Cannot rename file", filePath);
			}

			string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
			string ext = Path.GetExtension(filePath);
			string dirPath = Path.GetDirectoryName(filePath);
			string[] files = Directory.GetFiles(dirPath, fileNameWithoutExt + "_bck*" + ext);
			int maxNumn = -1;
			foreach (string file in files)
			{
				string fileWithouExt = Path.GetFileNameWithoutExtension(file);
				string fileRevNumberStr = fileWithouExt.Replace(fileNameWithoutExt + "_bck", string.Empty);
				int val = -1;
				if (int.TryParse(fileRevNumberStr, out val))
				{
					maxNumn = Math.Max(maxNumn, val);
				}
			}
			string newFileName = fileNameWithoutExt + "_bck" + (++maxNumn).ToString() + ext;
			File.Copy(filePath, Path.Combine(dirPath, newFileName));
			FileUtils.TryDelete(filePath);
		}

		public static void RenameWithDateStamp(string filePath)
		{
			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException("Cannot rename file", filePath);
			}

			string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
			string ext = Path.GetExtension(filePath);
			string dirPath = Path.GetDirectoryName(filePath);

			string newFileName = fileNameWithoutExt + "_" + DateTime.Now.ToString("yyyy_MM_dd") + ext;
			int i = 0;
			while (File.Exists(Path.Combine(dirPath, newFileName)) && i < 1000000)
			{
				i++;
				newFileName = fileNameWithoutExt + "_" + DateTime.Now.ToString("yyyy_MM_dd") + "_" + i + ext;
			}

			File.Copy(filePath, Path.Combine(dirPath, newFileName));
			FileUtils.TryDelete(filePath);
		}

		public static string GetDllFileNameFromNamespace(string theNamespace)
		{
			if (string.IsNullOrEmpty(theNamespace)) return string.Empty;
			int dotPoint = theNamespace.IndexOf('.');
			if (dotPoint <= 0) return "";
			return theNamespace.Substring(0, dotPoint) + ".dll";
		}
		public static string GetPdbFileNameFromNamespace(string theNamespace)
		{
			if (string.IsNullOrEmpty(theNamespace)) return string.Empty;
			int dotPoint = theNamespace.IndexOf('.');
			return theNamespace.Substring(0, dotPoint) + ".pdb";
		}
		/// <summary>
		/// Combine path1 and path2.
		/// This function will validate the path1, this path will being created if does not existing
		/// </summary>
		/// <param name="path1">Path1 contains root path</param>
		/// <param name="path2">Path2 need to combine</param>
		/// <returns>The string that is path combined</returns>
		public static string Combine(string path1, string path2)
		{
			if (!Directory.Exists(path1))
			{
				string[] folders = path1.Split(@"\".ToCharArray());
				if (folders.Length <= 0) return string.Empty;

				string path = folders[0] + @"\";
				for (int i = 1; i < folders.Length; i++)
				{
					if (folders[i].Trim().Length == 0) continue;
					path = Path.Combine(path, folders[i]);
					Directory.CreateDirectory(path);
				}
			}
			return Path.Combine(path1, path2);
		}

		public static string GetFileNameWithoutExt(string filename)
		{
			return Path.GetFileNameWithoutExtension(filename);
		}
    public static string GetFileNameWithExt(string filename)
    {
      return Path.GetFileName(filename);
    }

	  public static void DeleteFilesInFolder(string folderName)
	  {
      if(Directory.Exists(folderName))
      {
        string[] files = Directory.GetFiles(folderName);
        if(files.Length>0)
        {
          foreach (string file in files)
          {
            try
            {
              File.Delete(file);
            }
            catch (Exception exception)
            {
              //Do nothing
            }
          }
        }
      }
	    
	  }

	  public static void DeleteFile(string fileName)
	  {
      if (File.Exists(fileName))
        File.Delete(fileName);
	  }
	}
}