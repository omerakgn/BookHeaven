using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookHeaven.Core.Features.Commands.ProductImage.ChangeShowCaseImage
{
    public class ChangeShowCaseImageCommandRequest : IRequest<ChangeShowCaseImageCommandResponse>
    {
        public string imageId { get; set; }
        public string productId { get; set; }
    }
}
