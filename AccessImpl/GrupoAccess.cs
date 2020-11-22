﻿using models;
using straviaBackend.interfaces;
using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.AccessImpl
{
    public class GrupoAccess : IGrupoAccessInterface
    {
        private readonly StravaContext _context;

        public GrupoAccess(StravaContext context)
        {
            _context = context;
        }

        public void AddGrupo(ModelGrupo grupo)
        {
            _context.grupos.Add(grupo);
            _context.SaveChanges();
        }

        public void DeleteGrupo(string idGrupo)
        {
            var entity = _context.grupos.FirstOrDefault(t => t.idgrupo == idGrupo);
            _context.grupos.Remove(entity);
            _context.SaveChanges();
        }

        public List<ModelGrupo> GetGrupo(string nombreGrupo)
        {
            return _context.grupos.Where(t => t.nombregrupo== nombreGrupo).OrderBy(t => t.nombregrupo).ToList();
        }

        public List<ModelGrupo> GetGrupos()
        {
            return _context.grupos.ToList();
        }

        public List<ModelGrupoView> GetGruposForUser(string username)
        {
            List<ModelGrupo> allgroups = _context.grupos.ToList();
            List<ModelGrupoView> models = new List<ModelGrupoView>();

            foreach (ModelGrupo grupo in allgroups) {
                bool estasuscrito = false;
                if (_context.unionusuariogrupo.Where(t => t.idunion == username + grupo.idgrupo).ToList().Count() != 0) {
                    estasuscrito = true;
                }
                if (grupo.nombreusuario.Equals(username)) {
                    estasuscrito = true;
                }
                models.Add(new ModelGrupoView
                {
                    nombregrupo = grupo.nombregrupo,
                    admin = grupo.nombreusuario,
                    key = grupo.idgrupo,
                    suscrito = estasuscrito
                }) ;
            }
            return models;
        }

        public void UpdateGrupo(ModelGrupo grupo)
        {
            _context.grupos.Update(grupo);
            _context.SaveChanges();
        }

    
    }
}
