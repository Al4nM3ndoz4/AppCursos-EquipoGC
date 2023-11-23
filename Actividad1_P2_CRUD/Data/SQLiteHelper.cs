using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Actividad1_P2_CRUD.Models;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Actividad1_P2_CRUD.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        SQLiteAsyncConnection bdSeguimiento;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Empleado>().Wait();
            db.CreateTableAsync<Cursos>().Wait();
            db.CreateTableAsync<Users>().Wait();

            bdSeguimiento = new SQLiteAsyncConnection(dbPath);
            bdSeguimiento.CreateTableAsync<Seguimientos>().Wait();
        }



        // BD Cursos
        public Task<int> SaveCursosAsync(Cursos cursos)
        {
            if (cursos.IdCurso == 0)
            {
                return db.InsertAsync(cursos);
            }
            else
            {
                return null;
            }
        }
        public Task<int> DeleteCursoAsync(Cursos curso)
        {
            return db.DeleteAsync(curso);
        }

        public Task<List<Cursos>> GetCursosAsync()
        {
            return db.Table<Cursos>().ToListAsync();
        }

        public Task<Cursos> GetCursoByIdAsync(int id)
        {
            return db.Table<Cursos>().Where(a => a.IdCurso == id).FirstOrDefaultAsync();
        }

        // BD de Usuarios //
        public Task<int>SaveUserModelAsync(Users user)
        {
            if (user.UserId != 0)
            {
                return db.UpdateAsync(user);
            }
            else
            {
                return db.InsertAsync(user);
            }
        }

        public Task<List<Users>>GetUsersValidate(string email, string password)
        {
            return db.QueryAsync<Users>("SELECT * FROM Users WHERE Email='" + email + "' AND Emailpassword='" + password + "' ");
        }

        // BD de Empleados //
        public Task<int>SaveEmpleadosAsync(Empleado emple)
        {
            if (emple.IdEmp != 0)
            {
                return db.UpdateAsync(emple);
            }
            else
            {
                return db.InsertAsync(emple);
            }
        }
        public Task<List<Empleado>> GetEmpleadosAsync()
        {
            return db.Table<Empleado>().ToListAsync();
        }
        public Task<Empleado> GetEmpleadoByIdAsync(int IdEmp)
        {
            return db.Table<Empleado>().Where(a => a.IdEmp == IdEmp).FirstOrDefaultAsync();
        }

        public Task<int> DeleteEmpleadoAsync(Empleado empleado)
        {
            return db.DeleteAsync(empleado);
        }


        // BD de Seguimiento de Cursos //

        // Guardar el seguimiento //
        public Task<int> SaveSeguimientoAsync(Seguimientos seguimiento)
        {
            if (seguimiento.Id != 0)
            {
                return bdSeguimiento.UpdateAsync(seguimiento);
            }
            else
            {
                return bdSeguimiento.InsertAsync(seguimiento);
            }
        }

        //Obtener el registro //
        public Task<Seguimientos> GetSeguimientoByIdAsync(int id)
        {
            return bdSeguimiento.Table<Seguimientos>().Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Seguimientos>> GetSeguimientoAsync()
        {
            return bdSeguimiento.Table<Seguimientos>().ToListAsync();
        }


        // Eliminar el registro de seguimiento //
        public Task<int> DeleteSeguimientoAsync(Seguimientos seguimiento)
        {
            return bdSeguimiento.DeleteAsync(seguimiento);
        }
    }
}
