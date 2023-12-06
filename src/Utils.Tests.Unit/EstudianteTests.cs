namespace Utils.Tests.Unit
{
    public class EstudianteTests
    {
        public class TheProperty_Edad : EstudianteTests
        {
            [Theory]
            [InlineData("1995-08-19", 28)]
            [InlineData("1995-12-05", 28)]
            [InlineData("1995-12-06", 27)]
            [InlineData("1996-02-29", 27)]
            public void Should_return_correct_age(string dateOfBirth, int expected)
            {
                // arrange
                var estudiante = new Estudiante()
                {
                    FechaNacimiento = DateOnly.ParseExact(dateOfBirth, "yyyy-MM-dd")
                };

                // act
                int edad = estudiante.Edad;

                // assert
                edad.Should().Be(expected);
            }
        }

        public class TheMethod_CalcularEdad : EstudianteTests
        {
            [Theory]
            [InlineData("1995-08-19", "2023-12-05", 28)]
            [InlineData("1995-12-05", "2023-12-05", 28)]
            [InlineData("1995-12-06", "2023-12-05", 27)]
            [InlineData("1996-02-29", "2023-12-05", 27)]
            [InlineData("1996-02-29", "1997-02-28",  0)]
            [InlineData("1996-02-29", "1997-03-01",  1)]
            [InlineData("1996-02-29", "2000-02-29",  4)]
            public void Should_return_correct_age(string dateOfBirth, string ageAt, int expected)
            {
                // arrange
                var estudiante = new Estudiante()
                {
                    FechaNacimiento = DateOnly.ParseExact(dateOfBirth, "yyyy-MM-dd")
                };

                // act
                int edad = estudiante.CalcularEdad(aLaFecha: DateOnly.ParseExact(ageAt, "yyyy-MM-dd"));

                // assert
                edad.Should().Be(expected);
            }
        }
    }
}
