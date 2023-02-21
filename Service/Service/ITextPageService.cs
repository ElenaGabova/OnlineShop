using Domain;

namespace Service
{
    public interface ITextPageService
    {
        /// <summary>
        /// Edit text pages
        /// </summary>
        /// <param name="role"></param>
        public void Edit(TextPage newTextPage);

        /// <summary>
        /// Get text pages
        /// </summary>
        /// <returns></returns>
        public TextPage GetTextPage();

    }
}