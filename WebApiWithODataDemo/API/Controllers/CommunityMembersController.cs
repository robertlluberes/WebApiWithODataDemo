using API.Core;
using API.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityMembersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommunityMembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CommunityMembers
        [HttpGet]
        public IEnumerable<CommunityMember> GetCommunityMembers()
        {
            return _context.CommunityMembers;
        }

        // GET: api/CommunityMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommunityMember>> GetCommunityMember(int id)
        {
            var communityMember = await _context.CommunityMembers.FindAsync(id);

            if (communityMember == null)
            {
                return NotFound();
            }

            return communityMember;
        }

        // PUT: api/CommunityMembers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommunityMember(int id, CommunityMember communityMember)
        {
            if (id != communityMember.CommunityId)
            {
                return BadRequest();
            }

            _context.Entry(communityMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityMemberExists(id))
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

        // POST: api/CommunityMembers
        [HttpPost]
        public async Task<ActionResult<CommunityMember>> PostCommunityMember(CommunityMember communityMember)
        {
            _context.CommunityMembers.Add(communityMember);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CommunityMemberExists(communityMember.CommunityId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCommunityMember", new { id = communityMember.CommunityId }, communityMember);
        }

        // DELETE: api/CommunityMembers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommunityMember>> DeleteCommunityMember(int id)
        {
            var communityMember = await _context.CommunityMembers.FindAsync(id);
            if (communityMember == null)
            {
                return NotFound();
            }

            _context.CommunityMembers.Remove(communityMember);
            await _context.SaveChangesAsync();

            return communityMember;
        }

        private bool CommunityMemberExists(int id)
        {
            return _context.CommunityMembers.Any(e => e.CommunityId == id);
        }
    }
}