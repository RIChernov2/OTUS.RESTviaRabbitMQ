using System.Collections.Generic;
using System.Text.Json.Serialization;
using Data.Entities.Interfaces;

namespace Data.Entities
{
    public class User : IPerson
    {
        public long UserId { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public byte? Age { get; set; }

    }
}