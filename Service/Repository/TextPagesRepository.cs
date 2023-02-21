using AutoMapper;
using Database.Service;
using Domain;
using Entities;
using Microsoft.Extensions.Logging;
using Service;
using System.Linq;

namespace Service.Repository
{
    public class TextPagesRepository : ITextPageService
    {
        private readonly ITextPageBase _textPageBase;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;


        public TextPagesRepository(ITextPageBase textPageBase, IMapper mapper, ILogger<TextPagesRepository> logger)
        {
            _textPageBase = textPageBase;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get text pages
        /// </summary>
        /// <returns></returns>
        public TextPage GetTextPage()
        {
            TextPage textPage = null;
            try
            {
                TextPageEntity textPageEntity = _textPageBase.GetTextPage();
                textPage = _mapper.Map<TextPage>(textPageEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Get Text Page. Error: {ex.Message}");
            }

            return textPage;
        }

        /// <summary>
        /// Edit text pages
        /// </summary>
        /// <param name="role"></param>
        public void Edit(TextPage newTextPage)
        {
            try
            {
                _textPageBase.Edit(_mapper.Map<TextPageEntity>(newTextPage));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Edit Text Page. Error: {ex.Message}");
            }

        }
    }
}
