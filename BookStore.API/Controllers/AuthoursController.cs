using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.API.Data;
using BookStoreApp.API.DTO.Author;
using AutoMapper;
using Humanizer;
using BookStoreApp.API.Static;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthoursController : ControllerBase
    {
        private readonly BookstoredbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthoursController> _logger;

        public AuthoursController(BookstoredbContext context, IMapper mapper, ILogger<AuthoursController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/Authours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthourReadOnlyDTO>>> GetAuthours()
        {
            try
            {
                var authours = await _context.Authours.ToListAsync();
                var authourDTOs = _mapper.Map<IEnumerable<AuthourReadOnlyDTO>>(authours);

                return Ok(authourDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing Ge in {nameof(GetAuthours)}");
                return StatusCode(500, Messages.HttpErrorCode500Msg);
            }
        }

        // GET: api/Authours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Authour>> GetAuthour(int id)
        {
            try
            {
                var authour = await _context.Authours.FindAsync(id);

                if (authour == null)
                {
                    _logger.LogWarning($"Record with id {id} not found: {nameof(GetAuthour)}");
                    return NotFound();
                }

                var authourDTO = _mapper.Map<AuthourReadOnlyDTO>(authour);
                return Ok(authourDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Performing Ge in {nameof(GetAuthours)} by Id");
                return StatusCode(500, Messages.HttpErrorCode500Msg);
            }

        }

        // PUT: api/Authours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutAuthour(int id, AuthourUpdateDTO authourDTO)
        {
            if (id != authourDTO.Id)
            {
                return BadRequest();
            }

            var authour = await _context.Authours.FindAsync(id);

            if (authour == null)
            {
                return NotFound();
            }

            _mapper.Map(authourDTO, authour);
            _context.Entry(authour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AuthourExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Authours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<AuthourDTO>> PostAuthour(AuthourDTO authourDTO)
        {
            var authour = _mapper.Map<Authour>(authourDTO);
            await _context.Authours.AddAsync(authour);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAuthour), new { id = authour.Id }, authour);
        }

        // DELETE: api/Authours/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAuthour(int id)
        {
            var authour = await _context.Authours.FindAsync(id);
            if (authour == null)
            {
                return NotFound();
            }

            _context.Authours.Remove(authour);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> AuthourExists(int id)
        {
            return await _context.Authours.AnyAsync(e => e.Id == id);
        }
    }
}
