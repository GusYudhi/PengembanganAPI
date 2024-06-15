using Microsoft.AspNetCore.Mvc;
using PengembanganAPI.Models;
using PengembanganAPI.Repository;

namespace PengembanganAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdukController : ControllerBase
    {
        private readonly IProdukRepository _produkRepository;

        public ProdukController(IProdukRepository produkRepository)
        {
            _produkRepository = produkRepository;
        }

        // GET: api/Produk
        [HttpGet]
        public async Task<IActionResult> GetProduks()
        {
            var produks = await _produkRepository.GetProduksAsync();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(produks);
        }

        // GET: api/Produk/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProduk([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produk = await _produkRepository.GetProdukAsync(id);

            if (produk == null)
            {
                return NotFound();
            }

            return Ok(produk);
        }

        // POST: api/Produk
        [HttpPost]
        public async Task<IActionResult> CreateProduk([FromBody] AddData produk)
        {
            if (produk == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produkNew = new Produk
            {
                Name = produk.Nama,
                Harga = produk.Harga
            };

            await _produkRepository.AddProdukAsync(produkNew);

            return CreatedAtAction(nameof(GetProduk), new { id = produkNew.Id }, produkNew);
        }

        // PUT: api/Produk/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduk([FromRoute] int id, [FromBody] AddData produk)
        {
            if (produk == null)
            {
                return BadRequest(ModelState);
            }

            var existingProduk = await _produkRepository.GetProdukAsync(id);
            if (existingProduk == null)
            {
                return NotFound();
            }

            existingProduk.Name = produk.Nama;
            existingProduk.Harga = produk.Harga;

            await _produkRepository.UpdateProdukAsync(existingProduk);

            return Ok(existingProduk);
        }

        // DELETE: api/Produk/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduk([FromRoute] int id)
        {
            var produk = await _produkRepository.GetProdukAsync(id);

            if (produk == null)
            {
                return NotFound();
            }

            await _produkRepository.DeleteProdukAsync(produk);

            return Ok(produk);
        }
    }
}
