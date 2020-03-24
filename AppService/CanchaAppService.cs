using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiProyecto.Models;

namespace apiProyecto
{
    public class CanchaAppService
    {
        private readonly DBContext _dB;
        private readonly CanchasDomain _canchasDomain;
        public CanchaAppService(DBContext db, CanchasDomain canchasDomain)
        {
            _dB = db;
            _canchasDomain = canchasDomain;
        }

        public async Task<string> AgregarCancha(Cancha cancha)
        {

            var respuesta = _canchasDomain.AgregarCancha(cancha);

            bool hayError = respuesta != null;

            if (hayError)
            {
                return respuesta;
            }

            try
            {
                _dB.Canchas.Add(cancha);
                await _dB.SaveChangesAsync();

                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }


        }
    }
}