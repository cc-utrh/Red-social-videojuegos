
using System;
using PracticaDSMGenNHibernate.EN.DSMPracticas;

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial interface INotificacionCAD
{
NotificacionEN ReadOIDDefault (int id
                               );

void ModifyDefault (NotificacionEN notificacion);

System.Collections.Generic.IList<NotificacionEN> ReadAllDefault (int first, int size);



int New_ (NotificacionEN notificacion);

void Modify (NotificacionEN notificacion);


void Destroy (int id
              );


NotificacionEN ReadOID (int id
                        );


System.Collections.Generic.IList<NotificacionEN> ReadAll (int first, int size);



System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN> GetNotificacionesUsuario (int p_usuario);


void AddUsuarios (int p_Notificacion_OID, System.Collections.Generic.IList<int> p_usuario_OIDs);

void DeleteUsuarios (int p_Notificacion_OID, System.Collections.Generic.IList<int> p_usuario_OIDs);
}
}
