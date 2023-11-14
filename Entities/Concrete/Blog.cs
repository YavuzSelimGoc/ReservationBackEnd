using System;
using Core.Entities;

namespace Entities.Concrete
{
	public class Blog:IEntity
	{
        public int BlogId { get; set; }
        public int CategoryId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogImage { get; set; }
        public string BlogContent { get; set; }
        public string BlogText { get; set; }
        public string BlogWriter { get; set; }
        public string BlogUrl { get; set; }
        public string BlogFaq { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public DateTime BlogDate { get; set; }
        public string BlogTag { get; set; }
        public bool BlogStatus { get; set; }
        

    }
}

