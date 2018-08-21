using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstract
{
    public interface IEquipo
    {
        List<EquipoEntity> GetAll();
    }
}
