using Alura.Data;
using Alura.Data.DTOs.EnderecoDTOs;
using Alura.Models;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Services
{
    public class EnderecoService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public EnderecoService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public HeadEnderecoDTO CadastrarEndereco(CreateEnderecoDTO enderecoDTO)
        {
            Endereco e = _mapper.Map<Endereco>(enderecoDTO);
            _context.Enderecos.Add(e);
            _context.SaveChanges();
            return _mapper.Map<HeadEnderecoDTO>(e);
        }

        public List<HeadEnderecoDTO> ListarEndereco()
        {
            List<Endereco> enderecoList = _context.Enderecos.ToList();
            if (enderecoList == null)
            {
                return null;
            }
            return _mapper.Map<List<HeadEnderecoDTO>>(enderecoList);
        }

        public HeadEnderecoDTO BuscarEnderecoId(int id)
        {
            Endereco e = _context.Enderecos.FirstOrDefault(x => x.EnderecoId == id);
            if (e != null)
            {
                HeadEnderecoDTO enderecoDTO = _mapper.Map<HeadEnderecoDTO>(e);
                return enderecoDTO;
            }
            return null;
        }

        public Result AtualizarEndereco(int id, UpdateEnderecoDTO enderecoDTO)
        {
            Endereco e = _context.Enderecos.FirstOrDefault(x => x.EnderecoId == id);
            if (e == null)
            {
                return Result.Fail("Endereco nao encontrado");
            }
            _mapper.Map(enderecoDTO, e); 
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result RemoverEndereco(int id)
        {
            Endereco e = _context.Enderecos.FirstOrDefault(x => x.EnderecoId == id);
            if (e == null)
            {
                return Result.Fail("Endereco nao encontrado");
            }
            _context.Enderecos.Remove(e);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
