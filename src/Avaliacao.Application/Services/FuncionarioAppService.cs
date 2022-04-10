using Avaliacao.Application.ViewModels;
using Avaliacao.Domain.RH;
using Avaliacao.Domain.RH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Application.Services
{
    public class FuncionarioAppService : IFuncionarioAppService
    {

        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly IEscalaRepository _escalaRepository;

        public FuncionarioAppService(
             IFuncionarioRepository funcionarioRepository,
             ICargoRepository cargoRepository,
             IEscalaRepository escalaRepository
             )
        {
            _funcionarioRepository = funcionarioRepository;
            _cargoRepository = cargoRepository;
            _escalaRepository = escalaRepository;
        }

        public async Task<FuncionarioViewModel> ObterPorId(int Id)
        {
            var funcionario = await _funcionarioRepository.ObterPorId(Id);

            return FuncionarioViewModel.ParaFuncionarioViewModel(funcionario);
        }

        public async Task<IEnumerable<FuncionarioViewModel>> ObterTodos()
        {
            var funcionarios = await _funcionarioRepository.ObterTodos();
            var funcionariosViewModels = funcionarios.Select(FuncionarioViewModel.ParaFuncionarioViewModel).ToList();
            return funcionariosViewModels;
        }

        public async Task AdicionarFuncionario(FuncionarioViewModel funcionario)
        {
            var funcionarioDomain = await PreencherFuncionarioDominio(funcionario);
            _funcionarioRepository.Adicionar(funcionarioDomain);
            await _funcionarioRepository.UnitOfWork.Commit();
        }

        public async Task AlterarFuncionario(FuncionarioViewModel funcionario)
        {
             var funcionarioDomain = await PreencherFuncionarioDominio(funcionario, funcionario.Id);

            _funcionarioRepository.Atualizar(funcionarioDomain);
            await _funcionarioRepository.UnitOfWork.Commit();
        }

        public async Task RemoverFuncionario(int funcionarioId)
        {
            var funcionarioDomain = await _funcionarioRepository.ObterPorId(funcionarioId);

            _funcionarioRepository.Remover(funcionarioDomain);
            await _funcionarioRepository.UnitOfWork.Commit();
        }

        public async Task<IEnumerable<CargoViewModel>> ObterCargos()
        {
            var cargos = await _cargoRepository.ObterTodos();
            return cargos.Select(CargoViewModel.ParaCargoViewModel);

        }
        public async Task AdicionarEscala(EscalaViewModel escalaViewModel)
        {
            var funcionario = await _funcionarioRepository.ObterPorId(escalaViewModel.FuncionarioId);
            var escala = new Escala(escalaViewModel.Id,
                                                (DiasDaSemana)Enum.Parse(typeof(DiasDaSemana), escalaViewModel.DiaDaSemana.ToString()),
                                                escalaViewModel.HoraInicio,
                                                escalaViewModel.HoraTermino,
                                                escalaViewModel.TempoDescanso);
            funcionario.AdiconarEscala(escala);
            _funcionarioRepository.Atualizar(funcionario);

            await _funcionarioRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarEscala(EscalaViewModel escalaViewModel)
        {
            await RemoverEscala(escalaViewModel);
            await AdicionarEscala(escalaViewModel);
        }

        public async Task RemoverEscala(EscalaViewModel escalaViewModel)
        {
            var funcionario = await _funcionarioRepository.ObterPorId(escalaViewModel.FuncionarioId);
            var escala = await _escalaRepository.ObterPorId(escalaViewModel.Id);

            if (escala == null) return;

            funcionario.RemoverEscala(escala);
            _funcionarioRepository.Atualizar(funcionario);

            await _funcionarioRepository.UnitOfWork.Commit();
        }

        public async Task<EscalaViewModel> ObterEscalaPorId(int Id)
        {
            var escalaDominio = await _escalaRepository.ObterPorId(Id);

            return EscalaViewModel.ParaEscalaViewModel(escalaDominio);
        }

        public void Dispose()
        {
            _funcionarioRepository?.Dispose();
            _cargoRepository?.Dispose();
        }

        private async Task<Funcionario> PreencherFuncionarioDominio(FuncionarioViewModel funcionarioModel, int? IdFuncionario = null)
        {
            Funcionario funcionarioDomain;

            if (IdFuncionario == null)
            {
                funcionarioDomain = new Funcionario(funcionarioModel.Nome,
                                      funcionarioModel.Cpf,
                                      funcionarioModel.Email,
                                      funcionarioModel.Telefone,
                                      funcionarioModel.CargoId,
                                      funcionarioModel.Salario);
            }
            else
            {
                funcionarioDomain = await _funcionarioRepository.ObterPorId(funcionarioModel.Id);

                funcionarioDomain.Atualizar(
                                funcionarioModel.Nome,
                                funcionarioModel.Cpf,
                                funcionarioModel.Email,
                                funcionarioModel.Telefone,
                                funcionarioModel.CargoId,
                                funcionarioModel.Salario);
            }

            funcionarioDomain.AtribuirEndereco(new Endereco
            {
                Logradouro = funcionarioModel.Logradouro,
                Numero = funcionarioModel.Numero,
                Complemento = funcionarioModel.Complemento,
                Bairro = funcionarioModel.Bairro,
                Cep = funcionarioModel.Cep,
                Estado = funcionarioModel.Estado,
                Cidade = funcionarioModel.Cidade
            });

            if (funcionarioModel.Habilitacao)
                funcionarioDomain.AtribuirHabilitacao(
                    (HabilitacaoCategoria)Enum.Parse(typeof(HabilitacaoCategoria), funcionarioModel.Categoria.ToString()));
            else
                funcionarioDomain.LimparHabilitacao();



            funcionarioDomain.AtribuirLinguaEstrageira(new LinguaEstrangeira
            {
                Ingles = funcionarioModel.Ingles,
                Espanhol = funcionarioModel.Espanhol,
                Frances = funcionarioModel.Frances
            });

            return funcionarioDomain;
        }
    }
}
