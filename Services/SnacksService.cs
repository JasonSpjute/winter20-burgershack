using System;
using System.Collections.Generic;
using burgershack_winter20.Models;
using burgershack_winter20.Repositories;

namespace burgershack_winter20
{
    public class SnackService
    {
        private readonly SnackRepository _repo;
        public SnackService(SnackRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Snack> Get()
        {
            return _repo.GetAll();
        }
        internal Snack Get(int id)
        {
            Snack snack = _repo.GetById(id);
            if (snack == null)
            {
                throw new Exception("invalid Id");
            }
            return snack;
        }
        internal Snack Create(Snack newSnack)
        {
            return _repo.Create(newSnack);
        }
        internal Snack Edit(Snack editSnack)
        {
            Snack original = Get(editSnack.Id);

            original.Name = editSnack.Name != null ? editSnack.Name : original.Name;
            original.Description = editSnack.Description != null ? editSnack.Description : original.Description;
            original.Price = editSnack.Price > 0 ? editSnack.Price : original.Price;

            return _repo.Edit(original);
        }

        internal Snack Delete(int id)
        {
            Snack snack = Get(id);
            _repo.Delete(snack);
            return snack;
        }

    }
}