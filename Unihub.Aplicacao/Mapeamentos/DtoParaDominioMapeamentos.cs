using AutoMapper;
using Unihub.Aplicacao.DTOs;
using Unihub.Dominio.Entidades;

namespace Unihub.Aplicacao.Mapeamentos
{
    public class DtoParaDominioMapeamentos : Profile
    {
        public DtoParaDominioMapeamentos()
        {
            CreateMap<Aluno, AlunoDto>();

            CreateMap<AlunoAlteracaoDto, Aluno>()
                .ConstructUsing(dto => new Aluno(dto.Nome, dto.Email, dto.Matricula, dto.Senha));

            CreateMap<Disciplina, DisciplinaDto>();

            CreateMap<DisciplinaAlteracaoDto, Disciplina>()
                .ConstructUsing(dto => new Disciplina(dto.Professor, dto.Nome, dto.Codigo, dto.Descricao, dto.Sala, dto.TotalHoras));

            CreateMap<Disciplina, DisciplinaDto>();
            CreateMap<Disciplina, DisciplinaDetalheDto>();

            CreateMap<Falta, FaltaDto>();

            CreateMap<HorarioAula, HorarioAulaDto>();
            CreateMap<HorarioAula, HorarioAulaAlteracaoDto>();
            CreateMap<HorarioAulaAlteracaoDto, HorarioAula>()
                .ConstructUsing(dto => new HorarioAula(dto.HoraInicio, dto.HoraTermino, dto.Dia));

            CreateMap<Atividade, AtividadeDto>();
            CreateMap<Atividade, AtividadeDetalhesDto>();

            CreateMap<AtividadeAlteracaoDto, Atividade>()
                .ConstructUsing(dto =>
                    new Atividade(
                        dto.AlunoId,
                        dto.DisciplinaId,
                        dto.NotaId,
                        dto.Nome,
                        dto.Descricao ?? string.Empty,
                        dto.DataEntrega,
                        dto.Status
                    )
                );

            CreateMap<Nota, NotaDto>();
            CreateMap<AlunosDisciplina, AlunosDisciplinaDto>();
        }
    }
}
