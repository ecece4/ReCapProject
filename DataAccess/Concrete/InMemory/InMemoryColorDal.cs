﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>() {
            new Color{ColorId=1,ColorName="KIRMIZI"},
            new Color{ColorId=2,ColorName="SİYAH"},
            new Color{ColorId=3,ColorName="BEYAZ"}
            };  
        }

        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(Color color) 
        {
            Color colorToDelete = colorToDelete = _colors.SingleOrDefault(p => p.ColorId == color.ColorId);
            _colors.Remove(colorToDelete);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAllById(int ColorId)
        {
            return _colors.Where(p=>p.ColorId == ColorId).ToList();
        }

        public void Update(Color color)
        {
            Color colorToUpdate = colorToUpdate = _colors.SingleOrDefault(p => p.ColorId == color.ColorId);

                colorToUpdate.ColorId = color.ColorId;
                colorToUpdate.ColorName = color.ColorName;
            
        }

        
    }
}
