using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Services.File_Storage.Interfaces
{
    public interface IFileStorageService
    {
        void UplodadFile(byte[] data, string nameFile);
    }
}
