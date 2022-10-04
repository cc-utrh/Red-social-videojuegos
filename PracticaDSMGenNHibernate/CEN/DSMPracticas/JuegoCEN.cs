

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaDSMGenNHibernate.Exceptions;

using PracticaDSMGenNHibernate.EN.DSMPracticas;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;


namespace PracticaDSMGenNHibernate.CEN.DSMPracticas
{
/*
 *      Definition of the class JuegoCEN
 *
 */
public partial class JuegoCEN
{
private IJuegoCAD _IJuegoCAD;

public JuegoCEN()
{
        this._IJuegoCAD = new JuegoCAD ();
}

public JuegoCEN(IJuegoCAD _IJuegoCAD)
{
        this._IJuegoCAD = _IJuegoCAD;
}

public IJuegoCAD get_IJuegoCAD ()
{
        return this._IJuegoCAD;
}

public int New_ (string p_nombre, string p_descripcion, string p_portada, System.Collections.Generic.IList<int> p_genero)
{
        JuegoEN juegoEN = null;
        int oid;

        //Initialized JuegoEN
        juegoEN = new JuegoEN ();
        juegoEN.Nombre = p_nombre;

        juegoEN.Descripcion = p_descripcion;

        juegoEN.Portada = p_portada;


        juegoEN.Genero = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN>();
        if (p_genero != null) {
                foreach (int item in p_genero) {
                        PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN en = new PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN ();
                        en.Id = item;
                        juegoEN.Genero.Add (en);
                }
        }

        else{
                juegoEN.Genero = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN>();
        }

        //Call to JuegoCAD

        oid = _IJuegoCAD.New_ (juegoEN);
        return oid;
}

public void Destroy (int id
                     )
{
        _IJuegoCAD.Destroy (id);
}

public JuegoEN ReadOID (int id
                        )
{
        JuegoEN juegoEN = null;

        juegoEN = _IJuegoCAD.ReadOID (id);
        return juegoEN;
}

public System.Collections.Generic.IList<JuegoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<JuegoEN> list = null;

        list = _IJuegoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> Busqueda (string p_nombre)
{
        return _IJuegoCAD.Busqueda (p_nombre);
}
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> GetJuegosPorUsuario (int p_usuario)
{
        return _IJuegoCAD.GetJuegosPorUsuario (p_usuario);
}
public void AddGenero (int p_Juego_OID, System.Collections.Generic.IList<int> p_genero_OIDs)
{
        //Call to JuegoCAD

        _IJuegoCAD.AddGenero (p_Juego_OID, p_genero_OIDs);
}
public void DeleteGenero (int p_Juego_OID, System.Collections.Generic.IList<int> p_genero_OIDs)
{
        //Call to JuegoCAD

        _IJuegoCAD.DeleteGenero (p_Juego_OID, p_genero_OIDs);
}
public void AddComunidad (int p_Juego_OID, int p_comunidad_OID)
{
        //Call to JuegoCAD

        _IJuegoCAD.AddComunidad (p_Juego_OID, p_comunidad_OID);
}
public void DeleteComunidad (int p_Juego_OID, int p_comunidad_OID)
{
        //Call to JuegoCAD

        _IJuegoCAD.DeleteComunidad (p_Juego_OID, p_comunidad_OID);
}
}
}
