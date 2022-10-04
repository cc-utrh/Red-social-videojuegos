
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



/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CP.DSMPracticas_Notificacion_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CP.DSMPracticas
{
public partial class NotificacionCP : BasicCP
{
public PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN New_ (int p_post)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CP.DSMPracticas_Notificacion_new_) ENABLED START*/

        INotificacionCAD notificacionCAD = null;
        NotificacionCEN notificacionCEN = null;

        PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN result = null;


        try
        {
                SessionInitializeTransaction ();
                notificacionCAD = new NotificacionCAD (session);
                notificacionCEN = new  NotificacionCEN (notificacionCAD);

                PostCAD postCAD = new PostCAD (session);
                PostCEN postCEN = new PostCEN (postCAD);
                PostEN postEN = postCEN.ReadOID (p_post);
                UsuarioCAD usuarioCAD = new UsuarioCAD ();
                UsuarioEN usuarioEN = usuarioCAD.ReadOID (postEN.UsuarioCreador.Id);
                ComunidadCAD comunidadCAD = new ComunidadCAD ();
                ComunidadEN comunidadEN = comunidadCAD.ReadOID (postEN.Comunidad.Id);

                String autor = usuarioEN.Nickname;
                String comunidad = comunidadEN.Nombre;
                int oid;
                //Initialized NotificacionEN
                NotificacionEN notificacionEN;
                notificacionEN = new NotificacionEN ();

                if (p_post != -1) {
                        notificacionEN.Post = new PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN ();
                        notificacionEN.Post.Id = p_post;
                }

                notificacionEN.Hora = DateTime.Now;
                notificacionEN.Texto = "El usuario " + autor + " ha subido un nuevo post a la comunidad de " + comunidad + ". No te lo pierdas!";


                //Call to NotificacionCAD

                oid = notificacionCAD.New_ (notificacionEN);
                result = notificacionCAD.ReadOIDDefault (oid);



                // Obtenemos una lista con las OIDs de los usuarios y las volcamos en el relationer
                IList<int> usuariosOID = new List<int>();
                IList<UsuarioEN> usuariosEN = usuarioCAD.GetUsuariosComunidad (postEN.Comunidad.Id);
                for (int i = 0; i < usuariosEN.Count; i++) {
                        // Guarda en un array las OIDs los usuarios que forman parte de la comunidad a la que han subido un post y que ademas siguen al autor del post que se ha subido
                        IList<UsuarioEN> usuariosSiguenAlAutor = usuarioCAD.GetFollowed (postEN.UsuarioCreador.Id);
                        if (usuariosSiguenAlAutor.Contains (usuariosEN [i])) {
                                usuariosOID.Add (usuariosEN [i].Id);
                        }
                }
                notificacionCAD.AddUsuarios (oid, usuariosOID);
                Console.WriteLine ("Mandamos la notificacion creada...");



                // EnviarNotificacion (oid);



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
