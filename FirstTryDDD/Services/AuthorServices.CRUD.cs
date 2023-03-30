using FirstTryDDD.API.DTOs.AuthorDTOs;
using FirstTryDDD.API.Services.AbstractionServices;
using FirstTryDDD.Core.AggregateModels.AuthorAggregate;
using FirstTryDDD.Infrastructure.Data;
using FirstTryDDD.SharedKarnel.Enums;
using FirstTryDDD.SharedKarnel.Extensions;
using FirstTryDDD.SharedKarnel.Models;
using Microsoft.EntityFrameworkCore;
using SCodes = FirstTryDDD.SharedKarnel.Models.StatusCodes;

namespace FirstTryDDD.API.Services
{
    public partial class AuthorServices : BaseServices
    {
        #region Local Variables + Contructor
        private readonly AppDbContext _context;
        public AuthorServices(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Main Methods


        #region GetAllAsync 
        public async Task<Response> GetAllAsync(int pageNumber, int pageSize)
        {
            try
            {
                IEnumerable<Author> authors = await _context.Author.Skip((pageNumber - 1) * pageSize)
                                                                   .Take(pageSize)
                                                                   .ToListAsync();

                return new GlobalResponse
                {
                    Result = ResponseResult.Success,
                    Status = SCodes.Status200OK,
                    Object = PagedList<GetAllAuthorsResponse>.ToPagedList(authors.ToCastedList(a => new GetAllAuthorsResponse(a)), await _context.Author.CountAsync(), pageNumber, pageSize)
                }; 

            }
            catch(Exception ex)
            {
                return GetException(ex); 
            }
        }
        #endregion

        #region GetByIdAsync

        #endregion

        #region PostAsync

        #endregion

        #region PutAsync

        #endregion

        #region DeleteAsync

        #endregion

        #endregion
    }

}
