using AthelasAPI.Entites;
using AthelasAPI.Exceptions;
using AthelasAPI.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace AthelasAPI.Services
{
    public interface IClientService
    {
        int Add(ClientAddDto addDto);
        void Delete(int clientId);
        ClientDto GetById(int clientId);
        void UpdateNotes(int id, string notes);
        void Update(int id, ClientUpdateDto updateDto);
        IEnumerable<ClientDto> GetAll();
    }

    public class ClientSerivce : IClientService
    {
        private readonly AthelasDbContext   mAthelasDbContext;
        private readonly IMapper            mMapper;

        public ClientSerivce(AthelasDbContext athelasDbContext, IMapper mapper)
        {
            mAthelasDbContext   = athelasDbContext;
            mMapper             = mapper;
        }

        public int Add(ClientAddDto addDto)
        {
            var clientEntity = mMapper.Map<Client>(addDto);
            clientEntity.Notes = "";
            mAthelasDbContext.Clients.Add(clientEntity);

            mAthelasDbContext.SaveChanges();

            return clientEntity.Id;
        }

        public void Delete(int clientId)
        {
            var client = mAthelasDbContext.Clients.FirstOrDefault(c => c.Id == clientId);


            if (client is null)
                throw new NotFoundException("Client with provided `id` does not exist!");


            mAthelasDbContext.Clients.Remove(client);
            mAthelasDbContext.SaveChanges();
        }

        public ClientDto GetById(int clientId)
        {
            var client = mAthelasDbContext.Clients.FirstOrDefault(c => c.Id == clientId);

            if (client is null)
                throw new NotFoundException("Client with provided `id` does not exist!");

            return mMapper.Map<ClientDto>(client);
        }

        public IEnumerable<ClientDto> GetAll()
        {
            return mMapper.Map<IEnumerable<ClientDto>>(mAthelasDbContext.Clients.ToArray());
        }

        public void UpdateNotes(int id, string notes)
        {
            var client = mAthelasDbContext.Clients.FirstOrDefault(c => c.Id == id);

            if (client is null)
                throw new NotFoundException("Client with provided `id` does not exist!");

            client.Notes = notes;
            mAthelasDbContext.SaveChanges();
        }

        public void Update(int id, ClientUpdateDto updateDto)
        {
            var client = mAthelasDbContext.Clients.FirstOrDefault(c => c.Id == id);

            if (client is null)
                throw new NotFoundException("Client with provided `id` does not exist!");

            client.FirstName    = updateDto.FirstName;
            client.LastName     = updateDto.LastName;
            client.PhoneNumber   = updateDto.PhoneNumber;

            mAthelasDbContext.SaveChanges();
        }
    }
}
