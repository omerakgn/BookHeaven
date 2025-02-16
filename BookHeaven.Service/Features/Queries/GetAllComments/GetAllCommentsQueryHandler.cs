using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.Features.Queries.GetAllComments;
using BookHeaven.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHeaven.Service.Features.Queries.GetAllComments
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQueryRequest, GetAllCommentsQueryResponse>
    {
        private readonly AppDbContext _context;

        public GetAllCommentsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllCommentsQueryResponse> Handle(GetAllCommentsQueryRequest request, CancellationToken cancellationToken)
        {
            // Belirli bir kitaba ait toplam yorum sayısını alıyoruz
            var totalComments = await _context.Comments
                .Where(c => c.BookId == request.BookId)
                .CountAsync(cancellationToken);

            // Sayfalama ile yorumları getiriyoruz
            var comments = await _context.Comments
                .Where(c => c.BookId == request.BookId)         
                .Select(c => new
                {
                    c.Id,
                    c.UserName,
                    c.Content,
                    c.CreateDate
                })
                .ToListAsync(cancellationToken);

            // Response oluşturuyoruz
            return new GetAllCommentsQueryResponse
            {
                Comments = comments,
                Message = "Yorumlar başarıyla getirildi.",
                Success = true,
               
            };
        }
    }
}
