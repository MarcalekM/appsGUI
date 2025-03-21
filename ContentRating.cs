using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appsGUI
{
    internal class ContentRating
    {
        public int ContentRatingId { get; set; }
        public string ContentRatingName { get; set; }

        public ContentRating(int contentRatingId, string contentRatingName)
        {
            ContentRatingId = contentRatingId;
            ContentRatingName = contentRatingName;
        }
    }
}
