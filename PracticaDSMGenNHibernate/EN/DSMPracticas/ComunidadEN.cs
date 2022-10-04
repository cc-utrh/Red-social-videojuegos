
using System;
// Definición clase ComunidadEN
namespace PracticaDSMGenNHibernate.EN.DSMPracticas
{
public partial class ComunidadEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo fechaCreacion
 */
private Nullable<DateTime> fechaCreacion;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> usuario;



/**
 *	Atributo post
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> post;



/**
 *	Atributo juego
 */
private PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN juego;



/**
 *	Atributo id
 */
private int id;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual Nullable<DateTime> FechaCreacion {
        get { return fechaCreacion; } set { fechaCreacion = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> Post {
        get { return post; } set { post = value;  }
}



public virtual PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN Juego {
        get { return juego; } set { juego = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}





public ComunidadEN()
{
        usuario = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN>();
        post = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN>();
}



public ComunidadEN(int id, string nombre, string descripcion, Nullable<DateTime> fechaCreacion, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> usuario, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> post, PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN juego
                   )
{
        this.init (Id, nombre, descripcion, fechaCreacion, usuario, post, juego);
}


public ComunidadEN(ComunidadEN comunidad)
{
        this.init (Id, comunidad.Nombre, comunidad.Descripcion, comunidad.FechaCreacion, comunidad.Usuario, comunidad.Post, comunidad.Juego);
}

private void init (int id
                   , string nombre, string descripcion, Nullable<DateTime> fechaCreacion, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> usuario, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> post, PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN juego)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.FechaCreacion = fechaCreacion;

        this.Usuario = usuario;

        this.Post = post;

        this.Juego = juego;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComunidadEN t = obj as ComunidadEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
