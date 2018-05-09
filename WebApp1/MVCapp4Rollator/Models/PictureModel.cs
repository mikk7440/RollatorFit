using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; //Maybe remove

namespace MVCapp4Rollator.Models
{
    public class PictureModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string URL { get; set; }
    }
}