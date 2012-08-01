using System;
using System.Collections;
using System.Globalization;
using System.IO;

namespace ApplicationUtils.Utils
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class PathUtils
	{
		public static string CombinePaths(string path1, string path2)
		{
			if (path1 == null)
			{
				throw new ArgumentNullException("path1");
			}
			if (path2 == null)
			{
				throw new ArgumentNullException("path2");
			}

			if (Path.IsPathRooted(path2))
			{
				return path2;
			}

			char separatorChar = Path.DirectorySeparatorChar;
			char[] splitChars = new char[] {'/', separatorChar};

			// Now we split the Path by the Path Separator
			String[] path2Parts = path2.Split(splitChars);

			ArrayList arList = new ArrayList();

			// for each Item in the path that differs from ".." we just add it 
			// to the ArrayList, but skip empty parts
			for (int iCount = 0; iCount < path2Parts.Length; iCount++)
			{
				string currentPart = path2Parts[iCount];

				// skip empty parts or single dot parts
				if (currentPart.Length == 0 || currentPart == ".")
				{
					continue;
				}

				// if we get a ".." Try to remove the last item added (as if 
				// going up in the Directory Structure)
				if (currentPart == "..")
				{
					if (arList.Count > 0 && ((string) arList[arList.Count - 1] != ".."))
					{
						arList.RemoveAt(arList.Count - 1);
					}
					else
					{
						arList.Add(currentPart);
					}
				}
				else
				{
					arList.Add(currentPart);
				}
			}

			bool trailingSeparator = (path1.Length > 0 && path1.IndexOfAny(splitChars, path1.Length - 1) != -1);

			// if the first path ends in directory seperator character, then 
			// we need to omit that trailing seperator when we split the path
			string[] path1Parts;
			if (trailingSeparator)
			{
				path1Parts = path1.Substring(0, path1.Length - 1).Split(splitChars);
			}
			else
			{
				path1Parts = path1.Split(splitChars);
			}

			int counter = path1Parts.Length;

			// if the second path starts with parts to move up the directory tree, 
			// then remove corresponding parts in the first path
			//
			// eg. path1 = d:\whatever\you\want\to\do 
			//     path2 = ../../test
			//     
			//     ->
			//
			//     path1 = d:\whatever\you\want
			//     path2 = test
			ArrayList arList2 = (ArrayList) arList.Clone();
			for (int i = 0; i < arList2.Count; i++)
			{
				// never discard first part of path1
				if ((string) arList2[i] != ".." || counter < 2)
				{
					break;
				}

				// skip part of current directory
				counter--;

				arList.RemoveAt(0);
			}

			string separatorString = separatorChar.ToString(CultureInfo.InvariantCulture);

			// if path1 only has one remaining part, and the original path had
			// a trailing separator character or the remaining path had multiple
			// parts (which were discarded by a relative path in path2), then
			// add separator to remaining part
			if (counter == 1 && (trailingSeparator || path1Parts.Length > 1))
			{
				path1Parts[0] += separatorString;
			}

			string combinedPath = Path.Combine(string.Join(separatorString, path1Parts,
			                                               0, counter), string.Join(separatorString, (String[]) arList.ToArray(typeof (String))));

			// if path2 ends in directory separator character, then make sure
			// combined path has trailing directory separator character
			if (path2.EndsWith("/") || path2.EndsWith(separatorString))
			{
				combinedPath += Path.DirectorySeparatorChar;
			}

			return combinedPath;
		}

		public static bool TryCreatePath(string path)
		{
			try
			{
				DirectoryInfo di = new DirectoryInfo(path);
				if (di.Exists)
				{
					return true;
				}
				else
				{
					di.Create();
					return true;
				}
			}
			catch
			{
				return false;
			}
		}

    public static void DeleteFolder(string path)
    {
      try
      {
        Directory.Delete(path, true);
      }
      catch (Exception exception)
      {
        //Do nothing
      }
      
    }

    public static string GetFolderPathFromFilePath(string filePath)
    {
      return Path.GetDirectoryName(filePath); 
    }

    public static bool CreateFolderPathRecursiveable(string folderPath)
    {
      try
      {
        Directory.CreateDirectory(folderPath);
        return true;
      }
      catch (Exception exception)
      {
        return false;
      } 
    }

    /// <summary>
    /// Get foldername from path. eg: result from "c:\driver\vga\hp" is "hp"
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static  string  GetFolderNameFromPath(string filePath)
    {
      string[] names = filePath.Split('\\');
      return names[names.Length - 1];
    }
	}
}