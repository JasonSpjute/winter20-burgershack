using System.Collections.Generic;
using System.Data;
using System;
using Dapper;
using burgershack_winter20.Models;

namespace burgershack_winter20.Repositories
{
    public class SnackRepository
    {
        public readonly IDbConnection _db;
        public SnackRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Snack> GetAll()
        {
            string sql = "SELECT * FROM snacks;";
            return _db.Query<Snack>(sql);
        }

        public Snack GetById(int id)
        {
            string sql = "SELECT * FROM snacks WHERE id = @id;";
            return _db.QueryFirstOrDefault<Snack>(sql, new { id });
        }
        internal Snack Create(Snack newSnack)
        {
            string sql = @"
            INSERT INTO snacks
            (name, description, price)
            VALUES
            (@Name, @Description, @Price);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newSnack);
            newSnack.Id = id;
            return newSnack;
        }

        internal Snack Edit(Snack original)
        {
            string sql = @"
            UPDATE snacks
            SET
                description = @Description,
                price = @Price
            WHERE id = @Id;
            SELECT * FROM snacks WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Snack>(sql, original);
        }

        internal void Delete(Snack snack)
        {
            string sql = "DELETE FROM snacks WHERE id = @Id";
            _db.Execute(sql, snack);
        }

    }
}