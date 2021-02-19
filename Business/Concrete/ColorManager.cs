using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {

            _colorDal.Add(color);
            Console.WriteLine(color.ColorId
               + " Numaralı renk eklendi.");
        }

        public void Delete(Color color)
        {

            _colorDal.Delete(color);
            
            Console.WriteLine(color.ColorId
               + " Numaralı renk silindi.");
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }


        public Color GetColorByColorId(int id)
        {
            return _colorDal.Get(p=>p.ColorId==id);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine(color.ColorId
               + " Numaralı renk güncellendi.");
        }
    }
}
