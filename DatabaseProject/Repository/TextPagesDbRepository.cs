using Database.Service;
using Entities;
using System.Linq;

namespace Database.Repository
{
    public class TextPagesDbRepository : ITextPageBase
    {
        private readonly DatabaseContext databaseContext;

        /// <summary>
        /// Init text pages  collection default
        /// </summary>
        public TextPagesDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }


        /// <summary>
        /// Get text pages
        /// </summary>
        /// <returns></returns>
        public TextPageEntity GetTextPage()
        {
            return databaseContext.TextPages.FirstOrDefault();
        }

        /// <summary>
        /// Edit text pages
        /// </summary>
        /// <param name="role"></param>
        public void Edit(TextPageEntity newTextPage)
        {
            TextPageEntity textPage = GetTextPage();
            textPage.HeaderMainText = newTextPage.HeaderMainText;
            textPage.HeaderText = newTextPage.HeaderText;
            textPage.FooterText = newTextPage.FooterText;
            textPage.AboutUsText = newTextPage.AboutUsText;
            textPage.AboutUsFooter = newTextPage.AboutUsFooter;
            textPage.DirectionsLeft = newTextPage.DirectionsLeft;
            textPage.DirectionsRight = newTextPage.DirectionsRight;
            textPage.TimetableLeft = newTextPage.TimetableLeft;
            textPage.TimetableRight = newTextPage.TimetableRight;

            databaseContext.SaveChanges();
        }
    }
}
