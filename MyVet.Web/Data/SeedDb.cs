using MyVet.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _contexto;

        public SeedDb(DataContext contexto)
        {
            _contexto = contexto;
        }

        public async Task SeedAsync()
        {
            await _contexto.Database.EnsureCreatedAsync();
            await CheckPetTypesAsync();
            await CheckServiceTypesAsync();
            await CheckOwnersAsync();
            await CheckPetsAsync();
            await CheckAgendasAsync();
        }

        private async Task CheckAgendasAsync()
        {
            if (!_contexto.Agendas.Any())
            {
                var initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                var finalDate = initialDate.AddYears(1);
                while (initialDate < finalDate)
                {
                    if (initialDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        var finalDate2 = initialDate.AddHours(10);
                        while (initialDate < finalDate2)
                        {
                            _contexto.Agendas.Add(new Agenda
                            {
                                Date = initialDate.ToUniversalTime(),
                                IsAvailable = true
                            });
                            initialDate = initialDate.AddMinutes(30);
                        }
                        initialDate = initialDate.AddHours(14);
                    }
                    else
                    {
                        initialDate = initialDate.AddDays(1);
                    }
                }
                await _contexto.SaveChangesAsync();
            }
        }

        private async Task CheckPetsAsync()
        {
            var owner = _contexto.Owners.FirstOrDefault();
            var petType = _contexto.PetTypes.FirstOrDefault();
            if (!_contexto.Pets.Any())
            {
                AddPet("Otto", owner, petType, "Shih Tzu");
                AddPet("Killer", owner, petType, "Doberman");
                await _contexto.SaveChangesAsync();
            }
        }

        private void AddPet(string name, Owner owner, PetType petType, string race)
        {
            _contexto.Pets.Add(new Pet
            {
                Born = DateTime.Now.AddYears(-2),
                Name = name.Trim(),
                Owner = owner,
                PetType = petType,
                Race = race.Trim(),
            });
        }

        private async Task CheckOwnersAsync()
        {
            if (!_contexto.Owners.Any())
            {
                AddOwner("3200051", "Mario", "Riveros", "366 855", "0981728813", "Calle Nro. 12");
                AddOwner("3200052", "Juan", "Perez", "366 889", "0981728000", "Calle Nro. 13");
                AddOwner("3200053", "Gerardo", "Britez", "366 998", "0981728699", "Calle Nro. 14");
                await _contexto.SaveChangesAsync();
            }
        }

        private void AddOwner(string document, string firstName, string lastName, string fixedPhone, string cellPhone, string address)
        {
            _contexto.Owners.Add(new Owner
            {
                Address = address.Trim(),
                CellPhone = cellPhone.Trim(),
                Document = document.Trim(),
                FirstName = firstName.Trim(),
                FixedPhone = fixedPhone.Trim(),
                LastName = lastName.Trim(),
            });
        }

        private async Task CheckServiceTypesAsync()
        {
            if (!_contexto.ServiceTypes.Any())
            {
                _contexto.ServiceTypes.Add(new ServiceType { Name = "Consulta" });
                _contexto.ServiceTypes.Add(new ServiceType { Name = "Urgencia" });
                _contexto.ServiceTypes.Add(new ServiceType { Name = "Vacunación" });
                await _contexto.SaveChangesAsync();
            }

        }

        private async Task CheckPetTypesAsync()
        {
            if (!_contexto.PetTypes.Any())
            {
                _contexto.PetTypes.Add(new PetType { Name = "Perro" });
                _contexto.PetTypes.Add(new PetType { Name = "Gato" });
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
