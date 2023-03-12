using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DanceDirectionEntity
    {
           [Key]
            /// <summary>
            /// Direction id
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// Direction name
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Directtion description
            /// </summary>
            public string Description { get; set; }
            /// <summary>
            /// Direction main photo
            /// </summary>
            public string MainPhoto { get; set; }
            /// <summary>
            /// Direction other photos
            /// </summary>
            public string[]? OtherPhotos { get; set; }

     
            /// <summary>
            /// Direction video links
            /// </summary>
            public string[]? VideoLinks { get; set; }
            /// <summary>
            /// Solo double sign
            /// </summary>
            public bool SoloDoubleSign { get; set; }
    }
}
