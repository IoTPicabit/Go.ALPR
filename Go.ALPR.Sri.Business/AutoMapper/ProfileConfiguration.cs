using AutoMapper;
using Entities = Go.ALPR.Sri.SqlServer.Entities;
using X.PagedList;
using System.Collections.Generic;


namespace Go.ALPR.Sri.Business.AutoMapper
{
    public class ProfileConfiguration: Profile
    {
        public ProfileConfiguration()
        {
            //AllowNullCollections = true;

            ForAllMaps((map, exp) =>
            {
                foreach (var unmappedPropertyName in map.GetUnmappedPropertyNames())
                    exp.ForMember(unmappedPropertyName, opt => opt.Ignore());
            });

            CreateMap<Entities.TVision, IdentificacionDto>()
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.Tipo, s => s.MapFrom(m => m.Tipo))
                .ForMember(d => d.Estado, s => s.MapFrom(m => m.Estado))
                .ForMember(d => d.MatriculaC, s => s.MapFrom(m => m.MatriculaC))
                .ForMember(d => d.MatriculaR, s => s.MapFrom(m => m.MatriculaR))
                .ForMember(d => d.Path, s => s.MapFrom(m => m.Path))
                .PreserveReferences();

            CreateMap<Entities.TVisionAcceso, IdentificacionDto>()
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.Tipo, s => s.MapFrom(m => m.Tipo))
                .ForMember(d => d.Estado, s => s.MapFrom(m => m.Estado))
                .ForMember(d => d.MatriculaC, s => s.MapFrom(m => m.MatriculaC))
                .ForMember(d => d.MatriculaR, s => s.MapFrom(m => m.MatriculaR))
                .ForMember(d => d.Path, s => s.MapFrom(m => m.Path))
                .PreserveReferences();

            CreateMap<Entities.Usuario, UsuarioDto>()
                .ForMember(d => d.IdUsuario, s => s.MapFrom(m => m.IdUsuario))
                .ForMember(d => d.Nombre, s => s.MapFrom(m => m.Nombre))
                .ForMember(d => d.Login, s => s.MapFrom(m => m.Login))
                .ForMember(d => d.Clave, s => s.MapFrom(m => m.Clave))
                .ForMember(d => d.Tipo, s => s.MapFrom(m => m.Tipo))
                .ForMember(d => d.TipoNombre, s => s.Ignore());

            CreateMap<Entities.TipoOperacion, TipoOperacionDto>();

            CreateMap<Entities.Localizacion, LocalizacionDto>()
                .ForMember(d => d.IdLocalizacion, s => s.MapFrom(m => m.IdLocalizacion))
                .ForMember(d => d.Nombre, s => s.MapFrom(m => m.Nombre))
                .ForMember(d => d.IdTipoOperacion, s => s.MapFrom(m => m.IdTipoOperacion))
                .ForMember(d => d.NombreTipoOperacion, s => s.MapFrom(m => m.IdTipoOperacionNavigation.Nombre))
                .ForMember(d => d.Cif, s => s.MapFrom(m => m.Cif))
                .ForMember(d => d.Direccion, s => s.MapFrom(m => m.Direccion))
                .ForMember(d => d.Nima, s => s.MapFrom(m => m.Nima))
                .ForMember(d => d.Habilitado, s => s.MapFrom(m => m.Habilitado))
                .PreserveReferences()
                .ReverseMap();
             
            CreateMap<Entities.Empresa, EmpresaDto>();

            CreateMap<Entities.TipoCarga, TipoCargaDto>()
                .ForMember(d => d.NombreTipoOperacion, s => s.MapFrom(m => m.IdTipoOperacionNavigation.Nombre))
                .ForMember(d => d.NombrePadre, s => s.MapFrom(m => m.IdTipoCargaPadreNavigation.Nombre))
                .ForMember(d => d.Subproductos, s => s.MapFrom(m => m.InverseIdTipoCargaPadreNavigation))
                .ForMember(d => d.NombreEmpresaExpedicion, s => s.MapFrom(m => m.IdEmpresaExpedicionNavigation.Nombre));

                       
            CreateMap<Entities.Transporte, TransporteDto>()
                .ForMember(d => d.NombreTipoOperacion, s => s.MapFrom(m => m.IdTipoOperacionNavigation.Nombre))
                .ForMember(d => d.NombreEmpresa, s => s.MapFrom(m => m.IdEmpresaNavigation.Nombre))               
                .ForMember(d => d.NombreTipoCarga, s => s.MapFrom(m => m.IdTipoCargaNavigation.Nombre));


            CreateMap<Entities.Transporte, TransporteCompletoDto>()
               .ForMember(d => d.TipoOperacion, s => s.MapFrom(m => m.IdTipoOperacionNavigation))
               .ForMember(d => d.Empresa, s => s.MapFrom(m => m.IdEmpresaNavigation))
               .ForMember(d => d.TipoCarga, s => s.MapFrom(m => m.IdTipoCargaNavigation))
               .ForMember(d => d.Expedidor, s => s.MapFrom(m => m.IdTipoCargaNavigation.IdEmpresaExpedicionNavigation));


            CreateMap<Entities.Operacion, OperacionDto>()
                .ForMember(d => d.NombreTipoOperacion, s => s.MapFrom(m => m.IdTipoOperacionNavigation.Nombre));

            CreateMap<OperacionDto, Entities.Operacion>();


            CreateMap<Entities.Operacion, AlbaranDto>()
                .ForMember(d => d.IdOperacion, s => s.MapFrom(m => m.IdOperacion))
                .ForMember(d => d.IdTipoOperacion, s => s.MapFrom(m => m.IdTipoOperacion))
                .ForMember(d => d.Matricula, s => s.MapFrom(m => m.Matricula))
                .ForMember(d => d.MatriculaEntradaManual, s => s.MapFrom(m => m.MatriculaEntradaManual))
                .ForMember(d => d.MotivoMatriculaEntradaManual, s => s.MapFrom(m => m.MotivoMatriculaEntradaManual))
                .ForMember(d => d.MatriculaSalidaManual, s => s.MapFrom(m => m.MatriculaSalidaManual))
                .ForMember(d => d.MotivoMatriculaSalidaManual, s => s.MapFrom(m => m.MotivoMatriculaSalidaManual))
                .ForMember(d => d.Remolque, s => s.MapFrom(m => m.Remolque))
                .ForMember(d => d.FechaHoraEntrada, s => s.MapFrom(m => m.FechaHoraEntrada))
                .ForMember(d => d.PesoEntrada, s => s.MapFrom(m => m.PesoEntrada))
                .ForMember(d => d.PesoEntradaManual, s => s.MapFrom(m => m.PesoEntradaManual))
                .ForMember(d => d.MotivoPesoEntradaManual, s => s.MapFrom(m => m.MotivoPesoEntradaManual))
                .ForMember(d => d.FechaHoraSalida, s => s.MapFrom(m => m.FechaHoraSalida))
                .ForMember(d => d.PesoSalida, s => s.MapFrom(m => m.PesoSalida))
                .ForMember(d => d.PesoSalidaManual, s => s.MapFrom(m => m.PesoSalidaManual))
                .ForMember(d => d.MotivoPesoSalidaManual, s => s.MapFrom(m => m.MotivoPesoSalidaManual))
                .ForMember(d => d.Empresa, s => s.MapFrom(m => m.Empresa))
                .ForMember(d => d.EmpresaDireccion, s => s.MapFrom(m => m.EmpresaDireccion))
                .ForMember(d => d.EmpresaCIF, s => s.MapFrom(m => m.EmpresaCif))
                .ForMember(d => d.EmpresaNIMA, s => s.MapFrom(m => m.EmpresaNima))
                .ForMember(d => d.Conductor, s => s.MapFrom(m => m.Conductor))
                .ForMember(d => d.TipoCarga, s => s.MapFrom(m => m.TipoCarga))
                .ForMember(d => d.CodigoLER, s => s.MapFrom(m => m.CodigoLer))
                .ForMember(d => d.DenominacionADR, s => s.MapFrom(m => m.DenominacionAdr))
                .ForMember(d => d.Origen, s => s.MapFrom(m => m.Origen))
                .ForMember(d => d.OrigenDireccion, s => s.MapFrom(m => m.OrigenDireccion))
                .ForMember(d => d.OrigenCIF, s => s.MapFrom(m => m.OrigenCif))
                .ForMember(d => d.OrigenNIMA, s => s.MapFrom(m => m.OrigenNima))
                .ForMember(d => d.Destino, s => s.MapFrom(m => m.Destino))
                .ForMember(d => d.DestinoDireccion, s => s.MapFrom(m => m.DestinoDireccion))
                .ForMember(d => d.DestinoCIF, s => s.MapFrom(m => m.DestinoCif))
                .ForMember(d => d.DestinoNIMA, s => s.MapFrom(m => m.DestinoNima))
                .ForMember(d => d.FirmaProductor, s => s.MapFrom(m => m.FirmaProductor))
                .ForMember(d => d.FirmaProductorImagen, s => s.MapFrom(m => m.FirmaProductorImagen))
                .ForMember(d => d.FirmaConductor, s => s.MapFrom(m => m.FirmaConductor))
                .ForMember(d => d.FirmaConductorImagen, s => s.MapFrom(m => m.FirmaConductorImagen))
                .ForMember(d => d.Camara1Entrada, s => s.Ignore())
                .ForMember(d => d.Camara2Entrada, s => s.Ignore())
                .ForMember(d => d.Camara3Entrada, s => s.Ignore())
                .ForMember(d => d.Camara1Salida, s => s.Ignore())
                .ForMember(d => d.Camara2Salida, s => s.Ignore())
                .ForMember(d => d.Camara3Salida, s => s.Ignore())
                .ForMember(d => d.NombreInstalacion, s => s.Ignore())
                .PreserveReferences();


            CreateMap<Entities.Operacion, CartaDto>()               
                .ForMember(d => d.EmpresaCIF, s => s.MapFrom(m => m.EmpresaCif))
                .ForMember(d => d.EmpresaNIMA, s => s.MapFrom(m => m.EmpresaNima))
                .ForMember(d => d.CodigoLER, s => s.MapFrom(m => m.CodigoLer))
                .ForMember(d => d.DenominacionADR, s => s.MapFrom(m => m.DenominacionAdr))
                .ForMember(d => d.OrigenCIF, s => s.MapFrom(m => m.OrigenCif))
                .ForMember(d => d.OrigenNIMA, s => s.MapFrom(m => m.OrigenNima))
                .ForMember(d => d.DestinoCIF, s => s.MapFrom(m => m.DestinoCif))
                .ForMember(d => d.DestinoNIMA, s => s.MapFrom(m => m.DestinoNima));


            CreateMap<Entities.Contacto, ContactoDto>()
                .ForMember(d => d.NombreEmpresa, s => s.MapFrom(m => m.IdEmpresaNavigation.Nombre))
                .ForMember(d => d.NombreTipoCarga, s => s.MapFrom(m => m.IdTipoCargaNavigation.Nombre));


            CreateMap<Entities.Acceso, AccesoDto>()
                .ForMember(d => d.EstadoNombre, s => s.Ignore())
                .ForMember(d => d.ResultadoNombre, s => s.MapFrom(m => (m.Resultado ? "Permitido" : "No permitido") ));

        }
    }
}