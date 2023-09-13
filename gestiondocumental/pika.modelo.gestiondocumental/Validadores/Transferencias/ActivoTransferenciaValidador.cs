namespace pika.modelo.gestiondocumental
{
    // public class ActivoTransferenciaValidador : AbstractValidator<ActivoTransferencia>
    public class ActivoTransferenciaValidador 
    {
        public ActivoTransferenciaValidador(/*IStringLocalizer<ActivoTransferencia> localizer*/)
        {

            //RuleFor(x => x.ActivoId)
            //    .NotNull().WithMessage(x => localizer["El activo es obligatorio"])
            //    .NotEmpty().WithMessage(x => localizer["El activo es obligatorio"])
            //    .MinimumLength(1).WithMessage(x => localizer["El activo debe tener entre {0} y {1} caracteres", 1, LongitudDatos.GUID])
            //    .MaximumLength(LongitudDatos.GUID).WithMessage(x => localizer["El activo debe tener entre {0} y {1} caracteres", 1, LongitudDatos.GUID]);

            /*
            RuleFor(x => x.TransferenciaId)
                .NotNull().WithMessage(x => localizer["La transferencia es obligatorio"])
                .NotEmpty().WithMessage(x => localizer["La transferencia  es obligatorio"])
                .MinimumLength(1).WithMessage(x => localizer["La transferencia debe tener entre {0} y {1} caracteres", 1, LongitudDatos.GUID])
                .MaximumLength(LongitudDatos.GUID).WithMessage(x => localizer["La transferencia debe tener entre {0} y {1} caracteres", 1, LongitudDatos.GUID]);
        */
            }
    }
}
