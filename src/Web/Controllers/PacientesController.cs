using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModel;

namespace Web.Controllers
{
    public class PacientesController : BaseController
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public PacientesController(IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<PacienteViewModel>>(await _pacienteRepository.ObterTodos()));
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var pacienteViewModel = await ObterPacienteEndereco(id);
                
            if (pacienteViewModel == null)
            {
                return NotFound();
            }

            return View(pacienteViewModel);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PacienteViewModel pacienteViewModel)
        {
            if (!ModelState.IsValid) return View(pacienteViewModel);

            var paciente = _mapper.Map<Paciente>(pacienteViewModel);
            await _pacienteRepository.Adicionar(paciente);
            
            return RedirectToAction("Index");
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteViewModel = await ObterPacienteEndereco(id);
            if (pacienteViewModel == null)
            {
                return NotFound();
            }
            return View(pacienteViewModel);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PacienteViewModel pacienteViewModel)
        {
            if (id != pacienteViewModel.Id) return NotFound();

            //falta inserir todos os campos para edição.
            var pacienteAtualizacao = await ObterPacienteEndereco(id);
            pacienteAtualizacao.Nome = pacienteViewModel.Nome;
            pacienteAtualizacao.Sexo = pacienteViewModel.Sexo;
            pacienteAtualizacao.Idade = pacienteViewModel.Idade;
            pacienteAtualizacao.IndicadoPor = pacienteViewModel.IndicadoPor;
            pacienteAtualizacao.Nascimento = pacienteViewModel.Nascimento;
            pacienteAtualizacao.Endereco.Bairro = pacienteViewModel.Endereco.Bairro;
            pacienteAtualizacao.Endereco.Cep = pacienteViewModel.Endereco.Cep;
            pacienteAtualizacao.Endereco.Cidade = pacienteViewModel.Endereco.Cidade;
            pacienteAtualizacao.Endereco.Estado = pacienteViewModel.Endereco.Estado;
            if (!ModelState.IsValid) return View(pacienteAtualizacao);

           



            await _pacienteRepository.Atualizar(_mapper.Map<Paciente>(pacienteAtualizacao));
                
                return RedirectToAction("Index");
            
          
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            

            var pacienteViewModel = await ObterPacienteEndereco(id);
            if (pacienteViewModel == null) 
            {
                return NotFound();
            }

            return View(pacienteViewModel);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pacienteViewModel = await ObterPacienteEndereco(id);
            if (pacienteViewModel == null) return NotFound();

            await _pacienteRepository.Remover(id);
            return RedirectToAction("Index");
        }

       

        private async Task<PacienteViewModel> ObterPacienteEndereco(Guid id)
        {
            return _mapper.Map<PacienteViewModel>(await _pacienteRepository.ObterPacienteEndereco(id));
        }
    }
}
