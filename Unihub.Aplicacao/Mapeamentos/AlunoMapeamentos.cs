using AutoMapper;
using Unihub.Aplicacao.DTOs;
using unihub_api.Dominio.Entidades;

namespace Unihub.Aplicacao.Mapeamentos
{
    public class AlunoMapeamentos : Profile
    {
        public AlunoMapeamentos()
        {
            CreateMap<Aluno, AlunoDto>();

            // Mapeamento para criação:
            // AlunoCreateDto => Aluno
            // Note que o construtor do Aluno exige parâmetros.
            CreateMap<AlunoAlteracaoDto, Aluno>()
                .ConstructUsing(dto => new Aluno(dto.Nome, dto.Email, dto.Senha));

            // Mapeamento para atualização:
            // AlunoUpdateDto => Aluno
            //CreateMap<AlunoUpdateDto, Aluno>()
            //    .ConstructUsing((dto, context) =>
            //    {
            //        // O objeto "Aluno" original será obtido via EF, então aqui
            //        // podemos apenas criar uma instância para injetar e depois
            //        // sobrescrever propriedades ou utilizar a atualização de domínio.
            //        // Porém, normalmente usamos .Map(dto, entidadeExistente) no serviço.
            //        return new Aluno(dto.Nome, dto.Email, dto.Senha);
            //    })
            //    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
