namespace Utils
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public DateOnly FechaNacimiento { get; set; }

        // La propiedad Edad queda como ejemplo, es preferible dejar solamente el método CalcularEdad
        public int Edad
        {
            get
            {
                // Primera implementación: falla cuando aún no cumplió años este año
                //int anioActual = DateTime.Today.Year;
                //int anioNacimiento = this.FechaNacimiento.Year;

                //return anioActual - anioNacimiento;


                // Segunda implementación: falla cuando nació un 29-feb
                //var hoy = DateOnly.FromDateTime(DateTime.Today);
                //int anioActual = hoy.Year;
                //int anioNacimiento = this.FechaNacimiento.Year;

                //int edad = anioActual - anioNacimiento;

                //var cumpleaniosEsteAnio = new DateOnly(anioActual, this.FechaNacimiento.Month, this.FechaNacimiento.Day);

                //if (cumpleaniosEsteAnio > hoy)
                //    edad--;

                //return edad;


                // Tercera implementación: funciona OK pero no me permite que los tests sean repetibles en el tiempo sin que fallen
                var hoy = DateOnly.FromDateTime(DateTime.Today);
                int anioActual = hoy.Year;
                int anioNacimiento = this.FechaNacimiento.Year;

                int edad = anioActual - anioNacimiento;

                DateOnly diaDeHoyAlAnioNacimiento = hoy.AddYears(-edad);

                if (this.FechaNacimiento > diaDeHoyAlAnioNacimiento)
                    edad--;

                return edad;
            }
        }

        // Cuarta implementación: transformamos la propiedad en un método para que nos permita repetitividad y ejercitar casos de borde
        public int CalcularEdad(DateOnly aLaFecha)
        {
            int anio = aLaFecha.Year;
            int anioNacimiento = this.FechaNacimiento.Year;

            int edad = anio - anioNacimiento;

            DateOnly fechaAlAnioNacimiento = aLaFecha.AddYears(-edad);

            if (this.FechaNacimiento > fechaAlAnioNacimiento)
                edad--;

            return edad;
        }
    }
}
