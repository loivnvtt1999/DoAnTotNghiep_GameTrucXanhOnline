using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BUS;
using ModelGame;

namespace TrucXanh_WebVersion.Models
{
    public class _modelImage
    {
        busImage busImageObject = new busImage();
        public List<tblImage> getListImage()
        {
            return busImageObject.getListImage();
        }
        public void insertImage (tblImage img)
        {
             busImageObject.insertImage(img);
        }
        public void removeImage(int id)
        {
            busImageObject.removeImage(id);
        }
    }
}