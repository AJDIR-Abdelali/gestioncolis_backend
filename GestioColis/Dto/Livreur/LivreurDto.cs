﻿using System.ComponentModel.DataAnnotations;

namespace GestioColis.Dto.Livreur
{
    public class LivreurDto
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } = "";
        public string Prenom { get; set; } = "";
        public string Email { get; set; } = "";
        public string Telephone { get; set; } = "";
    }
}
