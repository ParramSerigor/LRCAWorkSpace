using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes;


namespace LRCA.classes
{
    public class ImgHandler
    {
        public bool RepositoryDelete(string CompId, string FileURL)
        {
            bool IsComplete = false;

            //LRCA_ImageRepository objImgRe = new LRCA_ImageRepository();
            //objImgRe.LoadDynamic_2("URL = @URL and CompanyId = @CompId", "@URL", FileURL,"@CompId", CompId, "URL");
            //if (objImgRe.Loaded)
            //{
            //    objImgRe.Delete();
            //    IsComplete = true;
            //}

            return IsComplete;
        }

        public bool RepositoryAdd(string CompId, string FileURL)
        {
            bool IsComplete = false;

            //LRCA_ImageRepository objImgRe = new LRCA_ImageRepository();
            //objImgRe.LoadDynamic_2("URL = @URL and CompanyId = @CompId", "@URL", FileURL, "@CompId", CompId, "URL");
            //if (objImgRe.Loaded)
            //{
            //    objImgRe.Delete();

            //    objImgRe.CompanyId = Convert.ToInt32(CompId);
            //    objImgRe.BranchId = 0;
            //    objImgRe.URL = FileURL;
            //    objImgRe.Save();
            //    IsComplete = true;
            //}
            //else
            //{
            //    objImgRe.CompanyId = Convert.ToInt32(CompId);
            //    objImgRe.BranchId = 0;
            //    objImgRe.URL = FileURL;
            //    objImgRe.Save();
            //    IsComplete = true;
            //}

            return IsComplete;
        }

    }
}