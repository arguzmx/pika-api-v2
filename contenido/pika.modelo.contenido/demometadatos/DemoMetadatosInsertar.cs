﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.modelo.contenido.demometadatos;

public class DemoMetadatosInsertar
{

    public string Nombre { get; set; }

    public int Experiencia { get; set; }

    public decimal PrecioPorHora { get; set; }

    public string Curriculum { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public DateOnly HoraDeLunch { get; set; }

    public DateTime FechaCreacion { get; set; }

    public bool Activo { get; set; }

    public string Genero { get; set; }

    //public List<string> Especialidades { get; set; }
}
