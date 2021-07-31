using HairdressingServices.Api.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.Api.Models.Global.Repositories
{
    public interface IImageRepository
    {
        Image Get(int id);
        IEnumerable<Image> GetImageByUser(int userId);
        IEnumerable<Image> GetImageByUserAndAvis(int userId, int avisId);
        void Insert(Image image);
        void Delete(int userId, int id);
    }
}
