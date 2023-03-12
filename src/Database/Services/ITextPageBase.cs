using Entities;

namespace Database.Service
{
    public interface ITextPageBase
    {
        /// <summary>
        /// Edit text pages
        /// </summary>
        /// <param name="role"></param>
        public void Edit(TextPageEntity newTextPage);

        /// <summary>
        /// Get text pages
        /// </summary>
        /// <returns></returns>
        public TextPageEntity GetTextPage();

    }
}