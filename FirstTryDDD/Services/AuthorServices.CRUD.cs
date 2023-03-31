using FirstTryDDD.API.DTOs.AuthorDTOs;
using FirstTryDDD.API.Services.AbstractionServices;
using FirstTryDDD.Core.AggregateModels.AuthorAggregate;
using FirstTryDDD.Infrastructure.Data;
using FirstTryDDD.SharedKarnel.Enums;
using FirstTryDDD.SharedKarnel.Extensions;
using FirstTryDDD.SharedKarnel.Models;
using FirstTryDDD.SharedKarnel.Services;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
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
        public async Task<Response> GetByIdAsync(Guid id)
        {
            try
            {
                Author author = await _context.Author.FirstOrDefaultAsync(a => a.Id == id);

                if (author == null)
                    return new SimpleErrorResponse
                    {
                        Result = ResponseResult.Error,
                        Status = SCodes.Status404NotFound,
                        MsgException = "Cannot find this author"
                    };

                return new GlobalResponse
                {
                    Result = ResponseResult.Success,
                    Status = SCodes.Status200OK,
                    Object = new GetAuthorByIdResponse(author)
                }; 
            }
            catch(Exception ex)
            {
                return GetException(ex); 
            }
        }
        #endregion

        #region PostAsync
        public async Task<Response> PostAsync(PostAuthorRequest req)
        {
            try
            {
                DateTime today = DateTime.UtcNow; 

                Author author = new ()
                {
                    PhoneNumber = req.PhoneNumber,
                    Name = req.Name,
                    Email = req.Email,
                    Password = req.Password,
                    Age = req.Age,
                    CreatedDate = today, 
                    UpdatedDate = today, 
                };

                _context.Author.Add(author);
                await _context.SaveChangesAsync();

                return new GlobalResponse
                {
                    Result = ResponseResult.Success,
                    Status = SCodes.Status201Created,
                    Object = new PostAuthorResponse(author)
                }; 
            }
            catch(Exception ex)
            {
                return GetException(ex); 
            }
        }
        #endregion

        #region PutAsync
        public async Task<Response> PutAsync(PutAuthorRequest req)
        {
            try
            {
                Author author = await _context.Author.FindAsync(req.Id); 

                if(author == null)
                    return new SimpleErrorResponse
                    {
                        Result = ResponseResult.Error,
                        Status = SCodes.Status404NotFound,
                        MsgException = "Cannot find this author"
                    };

                author.Name = GenericServices<string>.IsDefaultValue(req.Name) ? author.Name : req.Name; 
                author.PhoneNumber = GenericServices<string>.IsDefaultValue(req.PhoneNumber) ? author.PhoneNumber : req.PhoneNumber; 
                author.Email = GenericServices<string>.IsDefaultValue(req.Email) ? author.Email : req.Email; 
                author.Password = GenericServices<string>.IsDefaultValue(req.Password) ? author.Password : req.Password; 
                author.Age = GenericServices<int?>.IsDefaultValue(req.Age) ? author.Age : req.Age;

                author.UpdatedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return new GlobalResponse
                {
                    Result = ResponseResult.Success,
                    Status = SCodes.Status200OK,
                    Object = new PutAuthorResponse(author)
                }; 
            }
            catch(Exception ex)
            {
                return GetException(ex); 
            }
        }
        #endregion

        #region DeleteAsync 
        public async Task<Response> DeleteAsync(Guid id)
        {
            try
            {
                Author author = await _context.Author.FindAsync(id);

                if (author == null)
                    return new SimpleErrorResponse
                    {
                        Result = ResponseResult.Error,
                        Status = SCodes.Status404NotFound,
                        MsgException = "Cannot find this author"
                    };

                _context.Author.Remove(author);
                await _context.SaveChangesAsync();

                return new Response
                {
                    Result = ResponseResult.Success,
                    Status = SCodes.Status200OK
                }; 
            }
            catch(Exception ex)
            {
                return GetException(ex); 
            }
        }
        #endregion

        #endregion
    }

}
