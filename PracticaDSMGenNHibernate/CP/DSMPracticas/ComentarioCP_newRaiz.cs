
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;



/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CP.DSMPracticas_Comentario_newRaiz) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CP.DSMPracticas
{
public partial class ComentarioCP : BasicCP
{
public PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN NewRaiz (string p_contenido, int p_usuario, int p_post, Nullable<DateTime> p_hora)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CP.DSMPracticas_Comentario_newRaiz) ENABLED START*/

        IComentarioCAD comentarioCAD = null;
        ComentarioCEN comentarioCEN = null;

        PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN result = null;


        try
        {
                SessionInitializeTransaction ();
                comentarioCAD = new ComentarioCAD (session);
                comentarioCEN = new  ComentarioCEN (comentarioCAD);




                int oid;
                //Initialized ComentarioEN
                ComentarioEN comentarioEN;
                comentarioEN = new ComentarioEN ();
                comentarioEN.Contenido = p_contenido;
                comentarioEN.Likes = 0;


                if (p_usuario != -1) {
                        comentarioEN.Usuario = new PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN ();
                        comentarioEN.Usuario.Id = p_usuario;
                }


                if (p_post != -1) {
                        comentarioEN.Post = new PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN ();
                        comentarioEN.Post.Id = p_post;
                }

                comentarioEN.Hora = p_hora;

                //Call to ComentarioCAD

                oid = comentarioCAD.NewRaiz (comentarioEN);
                result = comentarioCAD.ReadOIDDefault (oid);



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
