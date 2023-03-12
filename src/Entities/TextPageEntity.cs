using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class TextPageEntity
    {
        [Key]
        public Guid Id { get; set; } =  Guid.NewGuid();

        /// <summary>
        /// Text in HeaderMainText
        /// </summary>
        public string? HeaderMainText { get; set; }

        /// <summary>
        /// Text in HeaderText
        /// </summary>
        public string? HeaderText { get; set; }

        /// <summary>
        /// Text in FooterText
        /// </summary>
        public string? FooterText { get; set; }

        /// <summary>
        /// Text in page about Us
        /// </summary>
        public string AboutUsText { get; set; }

        /// <summary>
        /// Text in page about Us
        /// </summary>
        public string AboutUsFooter { get; set; }

        /// <summary>
        /// Text in page left
        /// </summary>
        public string DirectionsLeft { get; set; }

        /// <summary>
        /// Text in page left
        /// </summary>
        public string DirectionsRight { get; set; }

        /// <summary>
        /// Text in page left
        /// </summary>
        public string TimetableLeft { get; set; }
        /// <summary>
        /// Text in page left
        /// </summary>
        public string TimetableRight { get; set; }

        public TextPageEntity()
        {
            Id = Guid.NewGuid();
        }

    }

}
