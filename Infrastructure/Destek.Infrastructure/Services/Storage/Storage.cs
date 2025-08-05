using Destek.Infrastructure.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Infrastructure.Services.Storage
{
    public class Storage
    {
        protected delegate bool HasFile(string pathOrContainerName, string fileName);
        protected async Task<string> FileRenameAsync(string pathOrContainerName, string fileName, HasFile hasFileMethod)
        {

            string oldName = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            string newFileName = $"{NameOperations.CharacterRegulatory(oldName)}{extension}";
            bool fileIsExists = false;
            int fileIndex = 0;
            do
            {

                //File.Exists($"{path}\\{newFileName}")
                //if (File.Exists($"{path}\\{newFileName}"))
                if (hasFileMethod(pathOrContainerName, newFileName))
                {
                    fileIsExists = true;
                    fileIndex++;
                    newFileName = $"{NameOperations.CharacterRegulatory(oldName + "-" + fileIndex)}{extension}";
                }
                else
                {
                    fileIsExists = false;
                }
            } while (fileIsExists);
            return newFileName;

        }
    }
}
