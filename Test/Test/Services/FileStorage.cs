//using PCLStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Services;

namespace Test.Services
{
    //public class FileStorage : IFileStorage
    //{
    //    protected IFolder _rootFolder = FileSystem.Current.LocalStorage;
    //    public async Task<bool> IsFileExistAsync(string fileName)
    //    {
    //        // get hold of the file system  
    //        IFolder folder = _rootFolder ?? FileSystem.Current.LocalStorage;
    //        ExistenceCheckResult folderexist = await folder.CheckExistsAsync(fileName);

    //        // already run at least once, don't overwrite what's there  
    //        if (folderexist == ExistenceCheckResult.FileExists)
    //        {
    //            return true;
    //        }
    //        return false;
    //    }

    //    public async Task<bool> IsFolderExistAsync(string folderName)
    //    {
    //        // get hold of the file system  
    //        IFolder folder = _rootFolder ?? FileSystem.Current.LocalStorage;
    //        ExistenceCheckResult folderexist = await folder.CheckExistsAsync(folderName);
    //        // already run at least once, don't overwrite what's there  
    //        if (folderexist == ExistenceCheckResult.FolderExists)
    //        {
    //            return true;
    //        }
    //        return false;
    //    }

    //    public async Task<IFolder> CreateFolder(string folderName)
    //    {
    //        IFolder folder = _rootFolder ?? FileSystem.Current.LocalStorage;
    //        folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.ReplaceExisting);
    //        return folder;
    //    }

    //    public async Task<IFile> CreateFile(string filename)
    //    {
    //        IFolder folder = _rootFolder ?? FileSystem.Current.LocalStorage;
    //        IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
    //        return file;
    //    }
    //    public async Task<bool> WriteTextAllAsync(string filename, string content = "")
    //    {
    //        IFile file = await CreateFile(filename);
    //        await file.WriteAllTextAsync(content);
    //        return true;
    //    }

    //    public async Task<string> ReadAllTextAsync(string fileName)
    //    {
    //        string content = "";
    //        IFolder folder = _rootFolder ?? FileSystem.Current.LocalStorage;
    //        bool exist = await IsFileExistAsync(fileName);
    //        if (exist == true)
    //        {
    //            IFile file = await folder.GetFileAsync(fileName);
    //            content = await file.ReadAllTextAsync();
    //        }
    //        return content;
    //    }
    //    public async Task<bool> DeleteFile(string fileName)
    //    {
    //        IFolder folder = _rootFolder ?? FileSystem.Current.LocalStorage;
    //        bool exist = await IsFileExistAsync(fileName);
    //        if (exist == true)
    //        {
    //            IFile file = await folder.GetFileAsync(fileName);
    //            await file.DeleteAsync();
    //            return true;
    //        }
    //        return false;
    //    }
        //public async Task SaveImage(byte[] image, String fileName, IFolder rootFolder = null)
        //{
        //    // get hold of the file system  
        //    IFolder folder = rootFolder ?? FileSystem.Current.LocalStorage;

        //    // create a file, overwriting any existing file  
        //    IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

        //    // populate the file with image data  
        //    using (System.IO.Stream stream = await file.OpenAsync(FileAccess.ReadAndWrite))
        //    {
        //        stream.Write(image, 0, image.Length);
        //    }
        //}

        //public async static Task<byte[]> LoadImage(byte[] image, String fileName, IFolder rootFolder = null)
        //{
        //    // get hold of the file system  
        //    IFolder folder = rootFolder ?? FileSystem.Current.LocalStorage;

        //    //open file if exists  
        //    IFile file = await folder.GetFileAsync(fileName);
        //    //load stream to buffer  
        //    using (System.IO.Stream stream = await file.OpenAsync(FileAccess.ReadAndWrite))
        //    {
        //        long length = stream.Length;
        //        byte[] streamBuffer = new byte[length];
        //        stream.Read(streamBuffer, 0, (int)length);
        //        return streamBuffer;
        //    }

        //}
    //}
}
