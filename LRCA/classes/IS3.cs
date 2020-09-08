using LRCA.classes.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRCA.classes
{
    public interface IS3
    {
        string TryAddToAmazonBucket(Stream stream, string fileName, string subDirectory);
        string TryDelete(string id);
        bool TryDelete(string id, string subFolder);
        List<clsImageRepository> TryGetAllImagesAsync(string startAfter);
    }
}
