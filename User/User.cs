using System;
using System.Collections.Generic;


namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Information> Informations { get; set; }

    }
}
