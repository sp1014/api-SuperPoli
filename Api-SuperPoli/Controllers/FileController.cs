using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Api_SuperPoli.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.AspNetCore.Authorization;
using Api_SuperPoli.Core.LoginManager;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using File = Api_SuperPoli.Models.File;
using Api_SuperPoli.Data;
using Api_SuperPoli.Helpers;
using System.Collections.Generic;

namespace Api_Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        private readonly IWebHostEnvironment _env;
        private readonly UsersContext _context;

        public FileController(IWebHostEnvironment env, UsersContext context)
        {
            _env = env;
            _context = context;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string _OK = "data not exist";
        [HttpPost, Route("cargar-archivo")]
        public async Task<ActionResult> UploadFile()
        {
            var file = Request.Form.Files[0];
            string NombreCarpeta = "/Archivos/";
            //string RutaRaiz = "C:\\";
             string RutaRaiz = _env.ContentRootPath;

            string RutaCompleta = RutaRaiz + NombreCarpeta;
            if (!Directory.Exists(RutaCompleta))
            {
                Directory.CreateDirectory(RutaCompleta);
            }

            if (file.Length > 0)
            {
                string NombreArchivo = file.FileName;

                string RutaFullCompleta = Path.Combine(RutaCompleta, NombreArchivo);
                using (var stream = new FileStream(RutaFullCompleta, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                await Post(NombreArchivo, RutaCompleta);
            }
            return Ok(_OK);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NombreArchivo"></param>
        /// <param name="RutaCompleta"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult> Post(string NombreArchivo, string RutaCompleta)
        {

            var resultado = new ResultHelper<File>();
            try
            {
                File nuevaDoc = new File

                {                   
                    Name = NombreArchivo,
                    Archivo = RutaCompleta
                };
                _context.Files.Add(nuevaDoc);
                await _context.SaveChangesAsync();
                resultado.Value = nuevaDoc;

      
            }
            catch (Exception e)
            {
                resultado.AddError(e.Message);
            }
            _OK= resultado.Value.Id.ToString();
            return Ok(resultado.Value.Id);
        }

        [HttpGet]
        public async Task<ActionResult> get()
        {
            var resultado = new ResultHelper<IEnumerable<File>>();
            var nots = await _context.Files.ToListAsync();

            if (nots.Count > 0)
            {
                resultado.Value = nots;
            }
            else
            {
                string error = "No hay data";
                resultado.AddError(error);
            }
            return Ok(resultado);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> get(int idFile)
        {
            var resultado = new ResultHelper<IEnumerable<File>>();
            var user = await _context.Files.ToListAsync();
            if (user != null)
            {
                resultado.Value = (IEnumerable<File>)user;
            }
            else
            {
                string error = "No hay data";
                resultado.AddError(error);
            }
            return Ok(resultado);
        }


    }
}
