using System;
using System.Collections.Generic;
using System.Text;

namespace Cv.Models.Enums
{
    public enum UserTypeEnum
    {
        /// <summary>
        /// super user, hace todo y puede crear y editar usuarios
        /// </summary>
        Administrator = 0,
        /// <summary>
        /// administra solo las configuraciones de la compañia,
        /// y puede crear y editar usuarios Supervisor, Publisher, Consultant
        /// </summary>
        Configuration = 1,
        /// <summary>
        /// consulta, edita, crea busquedas, ve todo, y asigna usuarios a busquedas
        /// </summary>
        Supervisor = 2,
        /// <summary>
        /// consulta, edita candidatos, 
        /// y asigna candidatos a busquedas, 
        /// ve solo las busquedas que se le asignaron
        /// </summary>
        Publisher = 3,
        /// <summary>
        /// consulta solo los candidatos asignados de todas las busquedas activas
        /// </summary>
        Consultant = 4 
    }
}
