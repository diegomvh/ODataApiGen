using Microsoft.Extensions.Logging;

namespace ODataApiGen
{
    public class DirectoryManager
    {
        private ILogger Logger {get; } = Program.LoggerFactory.CreateLogger<DirectoryManager>();
        public string Output {get; private set;}
        public DirectoryInfo DirectoryInfo {get; private set;}

        public void PrepareOutput(bool purgeOutput)
        {
            Logger.LogDebug($"Preparing output path '{Output}'...");
            if (Directory.Exists(Output) && purgeOutput)
            {
                Logger.LogInformation("Purging output directory...");
                Directory.Delete(Output, true);
            }
            Logger.LogInformation("Folder doesn't exists, creating...");
            Directory.CreateDirectory(Output);
        }

        public void PrepareFolders(IEnumerable<string> directories)
        {
            var dsList = directories.ToList();
            dsList.Sort();
            foreach (var ds in dsList)
            {
                if (!Directory.Exists( Path.Combine(DirectoryInfo.FullName, ds)))
                {
                    Logger.LogDebug($"Creating subdirectory '{ds}'");
                    DirectoryInfo.CreateSubdirectory(ds);
                }
            }
        }

        public DirectoryManager(string outFolder)
        {
            Output = outFolder;
            DirectoryInfo = new DirectoryInfo(outFolder);
        }

        public void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
