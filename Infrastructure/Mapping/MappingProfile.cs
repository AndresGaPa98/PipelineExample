using AutoMapper;
using CargaDescarga;
using Scm.Controllers.Dtos;
using Scm.Domain;



namespace Scm.Infrastructure.Mapping
{
    
    public class MappingProfile : Profile {
    public MappingProfile() {
            CreateMap<AppUser, RegisterUserResponseDto>();
            CreateMap<Empleado, EmpleadoDtos>();
            CreateMap<EmpleadoDtos,Empleado>();
            CreateMap<EmpleadoResponseDto,Empleado>();
            CreateMap<Empleado,EmpleadoResponseDto>();
            CreateMap<EmpleadoUpdateDto,Empleado>();
            CreateMap<Empleado,EmpleadoUpdateDto>();
            CreateMap<ValeDto, Vale>();
             CreateMap<AppUser, RegisterUserResponseDto>();
             CreateMap<AppUser, UsserAccountUpdateDto>();
              CreateMap<UsserAccountUpdateDto, AppUser>();
             CreateMap<User,UsserAccountUpdateDto>();
             CreateMap<UsserAccountUpdateDto,User>();
             CreateMap<Empleado, EmpleadoDtos>();
             CreateMap<EmpleadoDtos,Empleado>();
             CreateMap<EmpleadoResponseDto,Empleado>();
             CreateMap<Empleado,EmpleadoResponseDto>();
             CreateMap<EmpleadoUpdateDto,Empleado>();
             CreateMap<Empleado,EmpleadoUpdateDto>();
             CreateMap<ValeDto, Vale>()
                .ForMember(dest=> dest.FechaExpedicionVale, 
                          opt=>opt.MapFrom(src=>src.Fecha))
                .ForMember(dest=> dest.FolioVale, 
                         opt=>opt.MapFrom(src=>src.Folio)).ReverseMap();

            CreateMap<RegisterValesDto, RegistroVale>();
            CreateMap<RegistroVale, RegisterValesDto>();

            
            
            CreateMap<Caja,CajaDtosOpen>();
            CreateMap<CajaDtosOpen,Caja>(); 
            CreateMap<Caja,CajaDtosClouse>();
            CreateMap<CajaDtosClouse,Caja>();
            

            CreateMap<RegistroVale, RegisterValesResponseDto>();
            CreateMap<Retenciones,RetencionesDto>().ReverseMap();
            CreateMap<RegisterFacturaDto,Factura>().ReverseMap();
            CreateMap<RegisterFacturaResponseDto,Factura>().ReverseMap();
            CreateMap<RegisterFacturaDateDto,Factura>().ReverseMap();
            CreateMap<EmpresaDtos, Empresa>().ReverseMap();
            CreateMap<EmpresaResponseDto, Empresa>().ReverseMap();
            CreateMap<ReporteMovimientosDtos,RegistroVale>().ReverseMap();
            CreateMap<MontoMovientosDtos,RegistroVale>().ReverseMap();
            CreateMap<ReporteMovFacDtos,Factura>().ReverseMap();
            CreateMap<MovimientosFacturas,Factura>().ReverseMap();
            
        }
    }
}