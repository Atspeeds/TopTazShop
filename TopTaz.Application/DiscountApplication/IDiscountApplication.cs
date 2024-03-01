using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTaz.Application.DiscountApplication.Dto;

namespace TopTaz.Application.DiscountApplication
{
    public interface IDiscountApplication
    {
        void Create(AddNewDiscountDto command);
    }

}
