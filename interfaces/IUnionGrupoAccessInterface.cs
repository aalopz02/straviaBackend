﻿using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.interfaces
{
    public interface IUnionGrupoAccessInterface
    {
        public void AddUnion(ModelUnionUsuarioGrupo union);
        public void DeleteUnion(string idelemento);
    }
}
