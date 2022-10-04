
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



/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CP.DSMPracticas_Juego_recomendarJuego) ENABLED START*/
//  references to other libraries
using System.Linq;
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CP.DSMPracticas
{
public partial class JuegoCP : BasicCP
{
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> RecomendarJuego (int p_usu)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CP.DSMPracticas_Juego_recomendarJuego) ENABLED START*/

        IJuegoCAD juegoCAD = null;
        JuegoCEN juegoCEN = null;
        UsuarioCEN usuarioCEN = null;

        try
        {
                SessionInitializeTransaction ();
                juegoCAD = new JuegoCAD (session);
                juegoCEN = new JuegoCEN (juegoCAD);
                usuarioCEN = new UsuarioCEN ();

                IList<UsuarioEN> seguidos = usuarioCEN.GetFollowed (p_usu);

                List<int> juegos = new List<int>();
                foreach (UsuarioEN seguido in seguidos) { //recuperamos todos los juegos de los seguidos del usuario
                        IList<JuegoEN> juegosSeguido = juegoCEN.GetJuegosPorUsuario (seguido.Id);
                        foreach (JuegoEN juego in juegosSeguido) {
                                juegos.Add (juego.Id);
                        }
                }


                var dict = new Dictionary<int, int>(); //estas lineas cuentan cuantas veces se repiten los juegos
                foreach (int juego in juegos) {
                        if (dict.ContainsKey (juego))
                                dict [juego]++;
                        else
                                dict [juego] = 1;
                }


                var lista = dict.ToList ();
                lista.Sort ((pair1, pair2) => pair2.Value.CompareTo (pair1.Value)); //volcamos el diccionario en una lista para ordenarlo de mas a menos veces repetido
                IList<JuegoEN> listaJuegos = new List<JuegoEN>();
                int salir = 0;
                int maxJuegosRecomendados = 5;
                foreach (var value in lista) {
                        listaJuegos.Add (juegoCEN.ReadOID (value.Key));
                        Console.WriteLine (listaJuegos.Last ().Nombre);

                        if (salir >= maxJuegosRecomendados)
                                break;
                        salir++;
                }

                SessionCommit ();
                return listaJuegos;
        }
        catch (Exception ex) {
                SessionRollBack ();
                throw ex;
        }
        finally{
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
